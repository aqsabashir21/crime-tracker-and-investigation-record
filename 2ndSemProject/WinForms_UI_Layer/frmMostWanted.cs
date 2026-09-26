using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmMostWanted : Form
    {
        private readonly CriminalRepository _criminalRepo = new CriminalRepository();
        private List<Criminal> _allCriminalsList = new List<Criminal>();

        public frmMostWanted()
        {
            InitializeComponent();
            RefreshInterfaceData();
        }

        // Central method to reload the grid and rebuild the profile selector drop list
        private void RefreshInterfaceData()
        {
            LoadMostWantedGrid();
            PopulateAddDropdown();
        }

        private void LoadMostWantedGrid()
        {
            try
            {
                dgvMostWanted.DataSource = null;
                DataTable mostWantedTable = _criminalRepo.GetMostWantedCriminals();
                dgvMostWanted.DataSource = mostWantedTable;

                if (mostWantedTable == null || mostWantedTable.Rows.Count == 0)
                {
                    lblStatus.Text = "Intelligence Alert: No profiles currently flagged as Most Wanted on server nodes.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(50, 205, 50); // Safe Lime Green
                }
                else
                {
                    lblStatus.Text = $"CRITICAL ALERT: {mostWantedTable.Rows.Count} High-Priority Target(s) Loaded in Manifest.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40); // Threat Crimson
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to sync matrix display grid: " + ex.Message, "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateAddDropdown()
        {
            try
            {
                // Pull down everyone so we can select profiles to flag up
                _allCriminalsList = _criminalRepo.SearchCriminals("");
                cmbAddSuspect.Items.Clear();

                foreach (Criminal c in _allCriminalsList)
                {
                    cmbAddSuspect.Items.Add(c.GetName() + " (" + c.GetCNIC() + ")");
                }

                if (cmbAddSuspect.Items.Count > 0) cmbAddSuspect.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to compile selector synchronization strings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Action 1: Add a profile to the threat list
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (cmbAddSuspect.SelectedIndex >= 0)
            {
                int targetID = _allCriminalsList[cmbAddSuspect.SelectedIndex].GetCriminalID();
                bool success = _criminalRepo.SetMostWantedStatus(targetID, true);

                if (success)
                {
                    MessageBox.Show("Profile successfully flagged up to high-priority target list status!", "Threat Matrix Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshInterfaceData();
                }
            }
        }

        // Action 2: Remove a selected profile from the threat list
        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            if (dgvMostWanted.CurrentRow != null)
            {
                try
                {
                    // Pull the CriminalID right out of the selected row cell index
                    int targetID = Convert.ToInt32(dgvMostWanted.CurrentRow.Cells["CriminalID"].Value);
                    string name = dgvMostWanted.CurrentRow.Cells["Name"].Value.ToString();

                    bool success = _criminalRepo.SetMostWantedStatus(targetID, false);
                    if (success)
                    {
                        MessageBox.Show($"{name} has been successfully downgraded to standard monitoring status.", "Target Stand Down", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshInterfaceData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please select a valid grid entry row: " + ex.Message, "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a row within the grid manifest to stand down.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}