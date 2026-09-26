using _2ndSemProject.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmViewVictims : Form
    {
        private readonly VictimRepository _victimRepo = new VictimRepository();
        private DataTable _activeCrimesTable = new DataTable();

        public frmViewVictims()
        {
            InitializeComponent();
            LoadCaseDropdown();
            if (cmbImpactType.Items.Count > 0) cmbImpactType.SelectedIndex = 0;
        }

        private void LoadCaseDropdown()
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                _activeCrimesTable = dbHelper.ExecuteQuery("SELECT CrimeID, Title, Type FROM Crimes");

                cmbCases.Items.Clear();
                if (_activeCrimesTable != null && _activeCrimesTable.Rows.Count > 0)
                {
                    foreach (DataRow row in _activeCrimesTable.Rows)
                    {
                        cmbCases.Items.Add($"{row["Type"]}: {row["Title"]} (ID: {row["CrimeID"]})");
                    }
                    cmbCases.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No active case records found to associate victim profiles with.", "Empty Manifest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to map crime registry indices: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshVictimGrid();
        }

        private void RefreshVictimGrid()
        {
            if (cmbCases.SelectedIndex >= 0)
            {
                int selectedCrimeID = Convert.ToInt32(_activeCrimesTable.Rows[cmbCases.SelectedIndex]["CrimeID"]);
                DataTable victimData = _victimRepo.GetVictimsByCrime(selectedCrimeID);
                dgvVictims.DataSource = victimData;

                if (victimData == null || victimData.Rows.Count == 0)
                {
                    lblStatus.Text = "Status: No civilian or corporate victim entities logged for this incident.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
                }
                else
                {
                    lblStatus.Text = $"Status: Formatted {victimData.Rows.Count} linked victim profile rows successfully.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
                }
            }
        }

        private void btnAddVictim_Click(object sender, EventArgs e)
        {
            string name = txtVictimName.Text.Trim();
            string cnic = txtCNIC.Text.Trim();
            string contact = txtContact.Text.Trim();
            int age = Convert.ToInt32(numAge.Value); // Reads directly from picker control

            // 1. Mandatory Parameter Integrity Check
            if (cmbCases.SelectedIndex < 0 || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cnic))
            {
                MessageBox.Show("Operational Halt: You must select a valid case file and fill out the Name and CNIC parameters.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. STRICTOR RULES: Ensure CNIC contains exactly 13 numeric characters with no dashes or spaces
            // Using a simple check: is it a number, and is the string length exactly 13 digits long?
            long parsedCnicVal;
            if (cnic.Length != 13 || !long.TryParse(cnic, out parsedCnicVal))
            {
                MessageBox.Show("Operational Halt: Identity input token violation.\n\nCNIC must be exactly 13 digits long containing only numbers (No dashes, spaces, or letters allowed).", "Invalid CNIC Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. DUPLICATE CHECK LAYER: Confirming uniqueness across database server records
            if (_victimRepo.IsCnicDuplicate(cnic))
            {
                MessageBox.Show($"Operational Halt: Critical Identity Collision.\n\nAnother victim profile record with the CNIC '{cnic}' is already registered in the system index files.", "Identity Conflict Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Age Validation Safety Bounds
            if (age <= 0)
            {
                MessageBox.Show("Operational Halt: Age property parameters must be greater than zero.", "Invalid Parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedCrimeID = Convert.ToInt32(_activeCrimesTable.Rows[cmbCases.SelectedIndex]["CrimeID"]);
                string impact = cmbImpactType.SelectedItem.ToString();

                // Pass the real age parameter down cleanly instead of the hardcoded '0' placeholder value!
                bool success = SaveVictimWithAge(selectedCrimeID, name, cnic, contact, impact, age);

                if (success)
                {
                    MessageBox.Show("Victim entity profile cleanly locked and bound to the case folder!", "Record Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clean inputs safely for rapid sequential logging entries
                    txtVictimName.Clear();
                    txtCNIC.Clear();
                    txtContact.Clear();
                    numAge.Value = 25; // Reset back down to safe default state baseline

                    RefreshVictimGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error streaming record entry: " + ex.Message, "Execution Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Inline execution block mapping the data rows cleanly down to your database tables using your validated parameters
        private bool SaveVictimWithAge(int crimeID, string name, string cnic, string contact, string impactType, int age)
        {
            string cleanName = name.Replace("'", "''");
            string cleanContact = contact.Replace("'", "''");
            string cleanImpact = impactType.Replace("'", "''");
            string contactCombined = $"CNIC: {cnic} | Ph: {cleanContact}".Replace("'", "''");

            string query = $@"INSERT INTO Victims (CrimeID, Name, Contact, ContactNumber, PrimaryImpact, Age) 
                             VALUES ({crimeID}, '{cleanName}', '{cleanContact}', '{contactCombined}', '{cleanImpact}', {age})";

            DatabaseHelper dbHelper = new DatabaseHelper();
            dbHelper.ExecuteQuery(query);
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}