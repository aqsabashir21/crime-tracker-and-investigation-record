using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmUpdateStatus : Form
    {
        private readonly CriminalRepository _criminalRepo = new CriminalRepository();
        private List<Criminal> _allCriminals = new List<Criminal>();

        public frmUpdateStatus()
        {
            InitializeComponent();
            LoadCriminalsIntoDropdown();
        }

        // 1. Fetch records live from the database to populate our selection list
        private void LoadCriminalsIntoDropdown()
        {
            try
            {
                // Passing an empty string pulls every criminal record down
                _allCriminals = _criminalRepo.SearchCriminals("");

                cmbCriminals.Items.Clear();
                foreach (Criminal c in _allCriminals)
                {
                    // Displaying Name alongside CNIC keeps individual identification distinct
                    cmbCriminals.Items.Add(c.GetName() + " (" + c.GetCNIC() + ")");
                }

                if (cmbCriminals.Items.Count > 0)
                {
                    cmbCriminals.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load criminal records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Automatically show their current status flag when a suspect is selected
        private void cmbCriminals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriminals.SelectedIndex >= 0)
            {
                Criminal selected = _allCriminals[cmbCriminals.SelectedIndex];
                lblCurrentStatusValue.Text = selected.GetStatus(); // Shows 'In Custody', 'Released', etc.
            }
        }

        // 3. Save the updated parameters back down to your database
        private void btnUpdate_Click(object sender, EventArgs e) //
        {
            if (cmbCriminals.SelectedIndex < 0 || cmbNewStatus.SelectedIndex < 0) //
            {
                MessageBox.Show("Please select both a criminal profile and their updated status value.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //
                return; //
            }

            try
            {
                Criminal selectedCriminal = _allCriminals[cmbCriminals.SelectedIndex]; //
                string newStatus = cmbNewStatus.SelectedItem.ToString(); //

 

                // Call your repository layer method to process the SQL command update
                bool success = _criminalRepo.UpdateCriminalStatus(selectedCriminal.GetCriminalID(), newStatus); //

                if (success) //
                {
                    MessageBox.Show("Custody status updated successfully to: " + newStatus, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                    this.DialogResult = DialogResult.OK; //
                    this.Close(); //
                }
                else //
                {
                    MessageBox.Show("The database engine rejected the status transaction update.", "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Error); //
                }
            }
            catch (Exception ex) //
            {
                MessageBox.Show("Pipeline transaction error: " + ex.Message, "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}