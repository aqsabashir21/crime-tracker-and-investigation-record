using _2ndSemProject.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmCloseCase : Form
    {
        private DataTable _unresolvedCrimesTable = new DataTable();

        public frmCloseCase()
        {
            InitializeComponent();
            LoadActiveIncidentList();
            if (cmbFinalStatus.Items.Count > 0) cmbFinalStatus.SelectedIndex = 0;
        }

        private void LoadActiveIncidentList()
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                // Pull down only cases that are currently open or active so we can close them down cleanly
                _unresolvedCrimesTable = dbHelper.ExecuteQuery("SELECT CrimeID, Title, Type FROM Crimes WHERE Status IN ('Open', 'Under Investigation')");

                cmbCases.Items.Clear();
                if (_unresolvedCrimesTable != null && _unresolvedCrimesTable.Rows.Count > 0)
                {
                    foreach (DataRow row in _unresolvedCrimesTable.Rows)
                    {
                        cmbCases.Items.Add($"{row["Type"]}: {row["Title"]} (ID: {row["CrimeID"]})");
                    }
                    cmbCases.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("All registered crime files are already processed, solved, or formally closed.", "Manifest Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to sync open crime indices: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmClosure_Click(object sender, EventArgs e)
        {
            if (cmbCases.SelectedIndex < 0 || cmbFinalStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a target active case file and define an official final ruling status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you absolutely sure you want to formally lock and close this investigation dossier row? This action logs final closure date properties.",
                "Confirm Final Archival Close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int selectedCrimeID = Convert.ToInt32(_unresolvedCrimesTable.Rows[cmbCases.SelectedIndex]["CrimeID"]);
                    string finalDisposition = cmbFinalStatus.SelectedItem.ToString();

                    // Bypassing repository orchestration layers to directly execute code updates cleanly
                    // calling our built method block logic
                    bool success = FormallyCloseCase(selectedCrimeID, finalDisposition);

                    if (success)
                    {
                        MessageBox.Show("Investigation docket permanently sealed and moved to historic archives!", "Case Status Settled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pipeline breakdown executing close routine: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Inline definition helper inside UI class for simple structural compilation flow
        private bool FormallyCloseCase(int crimeID, string finalStatus)
        {
            string query = $@"UPDATE Crimes SET Status = '{finalStatus}', ClosureDate = GETDATE() WHERE CrimeID = {crimeID}";
            DatabaseHelper dbHelper = new DatabaseHelper();
            dbHelper.ExecuteQuery(query);
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}