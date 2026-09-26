using _2ndSemProject.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmLogDiary : Form
    {
        private readonly ProgressRepository _progressRepo = new ProgressRepository();
        private DataTable _activeCrimesTable = new DataTable();

        public frmLogDiary()
        {
            InitializeComponent();
            LoadActiveCases();
            if (cmbSummaryTag.Items.Count > 0) cmbSummaryTag.SelectedIndex = 0; // 🔥 Set default tag index
        }

        private void LoadActiveCases()
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                // We read all active cases so the detective can select which file they are updating
                _activeCrimesTable = dbHelper.ExecuteQuery("SELECT CrimeID, Title, Type FROM Crimes");

                cmbCases.Items.Clear();
                if (_activeCrimesTable != null && _activeCrimesTable.Rows.Count > 0)
                {
                    foreach (DataRow row in _activeCrimesTable.Rows)
                    {
                        string type = row["Type"].ToString();
                        string title = row["Title"].ToString();
                        cmbCases.Items.Add($"{type}: {title} (ID: {row["CrimeID"]})");
                    }
                    cmbCases.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No active case files found in the infrastructure nodes. Please report a crime first.", "Missing Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to synchronize active crime indices: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update validation check to confirm a dropdown choice index is captured cleanly
            if (cmbCases.SelectedIndex < 0 || cmbSummaryTag.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtEntryText.Text))
            {
                MessageBox.Show("Please select a case file, an activity tag, and provide comprehensive operational diary text logs.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedCrimeID = Convert.ToInt32(_activeCrimesTable.Rows[cmbCases.SelectedIndex]["CrimeID"]);
                string entryText = txtEntryText.Text.Trim();

                // 🔥 FIX: Pull the string clean from the dropdown selection choice list
                string summaryTag = cmbSummaryTag.SelectedItem.ToString();

                bool success = _progressRepo.SaveDiaryEntry(selectedCrimeID, entryText, summaryTag);

                if (success)
                {
                    MessageBox.Show("Operational progress log appended into the case file manifest cleanly!", "Diary Log Entry Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pipeline error processing diary log: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}