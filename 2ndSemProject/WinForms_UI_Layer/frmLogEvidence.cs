using _2ndSemProject.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmLogEvidence : Form
    {
        private readonly EvidenceRepository _evidenceRepo = new EvidenceRepository();
        private DataTable _activeCrimesTable = new DataTable();

        public frmLogEvidence()
        {
            InitializeComponent();
            LoadActiveCases();

            // Force fire initial index states to build lists cleanly
            if (cmbEvidenceType.Items.Count > 0) cmbEvidenceType.SelectedIndex = 0;
        }

        private void LoadActiveCases()
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
                    MessageBox.Show("No active case files found in infrastructure nodes. Please report a crime first.", "Missing Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to synchronize active crime indices: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔥 CRITICAL: Dynamic List Matrix Generation based on Selection
        private void cmbEvidenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEvidenceType.SelectedIndex < 0) return;

            string selectedCategory = cmbEvidenceType.SelectedItem.ToString();
            cmbItemName.Items.Clear();
            cmbLocation.Items.Clear();

            // Populate Item Names & Storage Locations dynamically based on selected index string
            if (selectedCategory.Contains("Digital"))
            {
                cmbItemName.Items.AddRange(new object[] { "Server Log Dump File", "Hard Drive Clone Image", "CCTV MP4 Export Clip", "Encrypted SQL Backup", "Mobile Phone Extraction Report" });
                cmbLocation.Items.AddRange(new object[] { "Cyber-Forensics SAN Server (Partition D)", "Encrypted Network Share NAS-02", "Secure Vault Offline Flash Bay" });
            }
            else if (selectedCategory.Contains("Physical"))
            {
                cmbItemName.Items.AddRange(new object[] { "Firearm/Weapon Asset", "Bladed Tool/Knife", "Forced Entry Crowbar", "Suspect Personal Belongings", "Counterfeit Currency Pack" });
                cmbLocation.Items.AddRange(new object[] { "Main Evidence Room Locker A-1", "Heavy Security Weapon Locker B-4", "High-Value Safe Vault 01" });
            }
            else if (selectedCategory.Contains("Biological"))
            {
                cmbItemName.Items.AddRange(new object[] { "Latent Fingerprint Lift", "DNA Swab Specimen", "Clothing Fiber Collection", "Hair Sample Vial", "Blood Splatter Card" });
                cmbLocation.Items.AddRange(new object[] { "Forensics Lab Cold Storage Unit 2", "Biomaterial Cabinet C-3", "Main Evidence Room Locker Alpha" });
            }
            else if (selectedCategory.Contains("Documentary"))
            {
                cmbItemName.Items.AddRange(new object[] { "Signed Financial Contract", "Bank Transaction Statement", "Forged Identification Card", "Handwritten Threat Note", "Corporate Ledger Spreadsheet" });
                cmbLocation.Items.AddRange(new object[] { "Document File Cabinet Drawer 1", "Fireproof Document Safe Room", "Digital Archive Node-04" });
            }
            else if (selectedCategory.Contains("Media"))
            {
                cmbItemName.Items.AddRange(new object[] { "Dashcam Audio Recording", "Security Perimeter CCTV Feed", "Bodycam Footage Archive", "Intercepted Audio WAV File" });
                cmbLocation.Items.AddRange(new object[] { "Media Server Storage Node-A", "Secure Vault Offline Flash Bay", "Digital Archive Node-01" });
            }

            // Default select the first item generated inside both lists
            if (cmbItemName.Items.Count > 0) cmbItemName.SelectedIndex = 0;
            if (cmbLocation.Items.Count > 0) cmbLocation.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCases.SelectedIndex < 0 || cmbItemName.SelectedIndex < 0 ||
                cmbEvidenceType.SelectedIndex < 0 || cmbLocation.SelectedIndex < 0)
            {
                MessageBox.Show("Please select all item dropdown metrics to properly validate this item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedCrimeID = Convert.ToInt32(_activeCrimesTable.Rows[cmbCases.SelectedIndex]["CrimeID"]);

                // Pull names cleanly from your active selections
                string itemName = cmbItemName.SelectedItem.ToString();
                string evidenceType = cmbEvidenceType.SelectedItem.ToString();
                string location = cmbLocation.SelectedItem.ToString();
                string description = txtDescription.Text.Trim();

                bool success = _evidenceRepo.SaveEvidence(selectedCrimeID, itemName, evidenceType, location, description);

                if (success)
                {
                    MessageBox.Show("Evidence item successfully cataloged and mapped to the case log manifest!", "Item Secured", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pipeline error processing evidence entry: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}