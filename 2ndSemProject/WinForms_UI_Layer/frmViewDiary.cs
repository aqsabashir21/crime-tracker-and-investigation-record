using _2ndSemProject.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmViewDiary : Form
    {
        private readonly ProgressRepository _progressRepo = new ProgressRepository();
        private DataTable _activeCrimesTable = new DataTable();

        public frmViewDiary()
        {
            InitializeComponent();
            LoadCaseDropdown();
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
                    MessageBox.Show("No active case files found to view history logs for.", "Empty Manifest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load crime indices: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCases.SelectedIndex >= 0)
            {
                int selectedCrimeID = Convert.ToInt32(_activeCrimesTable.Rows[cmbCases.SelectedIndex]["CrimeID"]);
                LoadHistoryGrid(selectedCrimeID);
            }
        }

        private void LoadHistoryGrid(int crimeID)
        {
            try
            {
                dgvDiaryHistory.DataSource = null;
                DataTable historyData = _progressRepo.GetCaseDiaryHistory(crimeID);
                dgvDiaryHistory.DataSource = historyData;

                // UI Polish: Update status note string based on timeline entries
                if (historyData == null || historyData.Rows.Count == 0)
                {
                    lblStatus.Text = "Status: Clean ledger. No history logs recorded yet for this case file.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
                }
                else
                {
                    lblStatus.Text = $"Status: Successfully parsed {historyData.Rows.Count} chronological audit log row entries.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); // Blue Accent
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error streaming database timeline matrix: " + ex.Message, "Grid Mapping Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}