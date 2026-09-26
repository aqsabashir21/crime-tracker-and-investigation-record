using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmAddConviction : Form
    {
        private readonly CriminalRepository _criminalRepo = new CriminalRepository();
        // Temporary lists to hold data models and their internal IDs
        private List<Criminal> _allCriminals = new List<Criminal>();
        private DataTable _allCrimesTable = new DataTable();

        public frmAddConviction()
        {
            InitializeComponent();
            LoadDataSources();
        }

        private void LoadDataSources()
        {
            try
            {
                // 1. Fetch and load all criminal profiles
                _allCriminals = _criminalRepo.SearchCriminals("");
                cmbCriminals.Items.Clear();
                foreach (Criminal c in _allCriminals)
                {
                    cmbCriminals.Items.Add(c.GetName() + " (" + c.GetCNIC() + ")");
                }

                // 2. 🔥 FIX: Use ExecuteQuery instead of ExecuteReader for raw SQL text strings!
                DatabaseHelper dbHelper = new DatabaseHelper();
                _allCrimesTable = dbHelper.ExecuteQuery("SELECT CrimeID, Title, Type FROM Crimes");

                cmbCrimes.Items.Clear();
                if (_allCrimesTable != null && _allCrimesTable.Rows.Count > 0)
                {
                    foreach (DataRow row in _allCrimesTable.Rows)
                    {
                        // Pull out both your Crime Type (Cybercrime, Robbery) and its specific Title
                        string crimeType = row["Type"] != DBNull.Value ? row["Type"].ToString() : "General";
                        string crimeTitle = row["Title"] != DBNull.Value ? row["Title"].ToString() : "Unspecified Title";

                        // Format it perfectly: "Cybercrime: Corporate Espionage (Case ID: 1)"
                        string displayString = $"{crimeType}: {crimeTitle}";

                        // Keep it clean and readable inside the combo dropdown list box boundary
                        if (displayString.Length > 45) displayString = displayString.Substring(0, 42) + "...";

                        cmbCrimes.Items.Add($"{displayString} (Case ID: {row["CrimeID"]})");
                    }
                }
                else
                {
                    // Debug fallback to tell you if the database table itself returned 0 entries
                    Console.WriteLine("System Warning: The SQL Crimes data execution set came back empty.");
                }

                if (cmbCriminals.Items.Count > 0) cmbCriminals.SelectedIndex = 0;
                if (cmbCrimes.Items.Count > 0) cmbCrimes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load registry sync lists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (cmbCriminals.SelectedIndex < 0 || cmbCrimes.SelectedIndex < 0)
            {
                MessageBox.Show("Please select both a suspect profile and a matching crime ledger occurrence.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Get the actual primary key ID of the selected criminal record
                int criminalID = _allCriminals[cmbCriminals.SelectedIndex].GetCriminalID();

                // 2. Get the actual primary key ID of the selected crime record row
                int crimeID = Convert.ToInt32(_allCrimesTable.Rows[cmbCrimes.SelectedIndex]["CrimeID"]);

                // 3. Fire the execution down to your C# Repository logic layer
                bool success = _criminalRepo.LinkCriminalToCrime(criminalID, crimeID);

                if (success)
                {
                    MessageBox.Show("Conviction history record successfully logged and bound in the mapping junction table!", "Link Established", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bridge runtime failure: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}