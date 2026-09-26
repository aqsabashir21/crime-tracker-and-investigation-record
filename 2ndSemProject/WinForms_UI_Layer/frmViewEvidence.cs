using _2ndSemProject.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmViewEvidence : Form
    {
        private readonly EvidenceRepository _evidenceRepo = new EvidenceRepository();
        private DataTable _activeCrimesTable = new DataTable();

        public frmViewEvidence()
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
                    MessageBox.Show("No active case files found to view evidence manifests for.", "Empty Manifest", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                LoadEvidenceGrid(selectedCrimeID);
            }
        }

        private void LoadEvidenceGrid(int crimeID)
        {
            try
            {
                dgvEvidenceGrid.DataSource = null;
                DataTable evidenceData = _evidenceRepo.GetCaseEvidenceManifest(crimeID);
                dgvEvidenceGrid.DataSource = evidenceData;

                // Update operational alert line based on items found
                if (evidenceData == null || evidenceData.Rows.Count == 0)
                {
                    lblStatus.Text = "Status: Clear locker vault. No evidence items cataloged for this case file.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
                }
                else
                {
                    lblStatus.Text = $"SECURE MANIFEST: Successfully parsed {evidenceData.Rows.Count} items from locker storage nodes.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); // Blue Accent
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mapping database evidence matrix: " + ex.Message, "Grid Mapping Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}