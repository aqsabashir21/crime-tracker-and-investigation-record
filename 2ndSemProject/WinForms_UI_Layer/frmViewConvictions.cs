using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmViewConvictions : Form
    {
        private readonly CriminalRepository _criminalRepo = new CriminalRepository();
        private List<Criminal> _allCriminals = new List<Criminal>();

        public frmViewConvictions()
        {
            InitializeComponent();
            LoadCriminalsIntoDropdown();
        }
        private void btnNewConviction_Click(object sender, EventArgs e)
        {
            using (frmAddConviction linkWizard = new frmAddConviction())
            {
                if (linkWizard.ShowDialog() == DialogResult.OK)
                {
                    // 🔥 FIX: Explicitly break out and force a re-query from SQL Server
                    if (cmbCriminals.SelectedIndex >= 0)
                    {
                        Criminal selected = _allCriminals[cmbCriminals.SelectedIndex];

                        // Clear out the old cached DataGridView binding state entirely
                        dgvConvictions.DataSource = null;

                        // Force a fresh execution pass down to your repository layer
                        LoadConvictionGrid(selected.GetCriminalID());
                    }
                }
            }
        }

        // 1. Populate the dropdown list with active profile entities
        private void LoadCriminalsIntoDropdown()
        {
            try
            {
                // Pulling everyone down to fill the profile selector
                _allCriminals = _criminalRepo.SearchCriminals("");

                cmbCriminals.Items.Clear();
                foreach (Criminal c in _allCriminals)
                {
                    cmbCriminals.Items.Add(c.GetName() + " (" + c.GetCNIC() + ")");
                }

                if (cmbCriminals.Items.Count > 0)
                {
                    cmbCriminals.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load profiles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Trigger the historic record lookup when a profile is selected
        private void cmbCriminals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriminals.SelectedIndex >= 0)
            {
                Criminal selected = _allCriminals[cmbCriminals.SelectedIndex];
                LoadConvictionGrid(selected.GetCriminalID()); //
            }
        }

        // 3. Bind the resulting database records straight to your UI grid component
        private void LoadConvictionGrid(int criminalID)
        {
            try
            {
                // Calls your repository's DataTable retrieval block directly
                DataTable historyTable = _criminalRepo.GetCrimeHistory(criminalID); //

                dgvConvictions.DataSource = historyTable;

                // UI Polish: Tell the user if the individual has a clean record
                if (historyTable == null || historyTable.Rows.Count == 0)
                {
                    lblRecordStatus.Text = "Status: No prior convictions found on record for this profile.";
                    lblRecordStatus.ForeColor = System.Drawing.Color.FromArgb(50, 205, 50); // Lime Green
                }
                else
                {
                    lblRecordStatus.Text = $"Status: Found {historyTable.Rows.Count} recorded offense conviction(s).";
                    lblRecordStatus.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40); // Warning Crimson
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to pull history ledger parameters: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}