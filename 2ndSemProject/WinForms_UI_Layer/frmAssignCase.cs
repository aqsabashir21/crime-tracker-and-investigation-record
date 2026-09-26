using _2ndSemProject.Data_Access_Layer;
using _2ndSemProject.Core_OOP_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmAssignCase : Form
    {
        private readonly InvestigatorRepository _investigatorRepo = new InvestigatorRepository();
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public frmAssignCase()
        {
            InitializeComponent();
            PopulateDropdownOptions();
        }

        private void PopulateDropdownOptions()
        {
            try
            {
                // 1. POPULATE ACTIVE CRIMES DROPDOWN
                // Pulls open records directly from your active cases database view layer
                DataTable activeCrimes = _dbHelper.ExecuteQuery("SELECT CrimeID, Title FROM vw_ActiveCases");

                if (activeCrimes != null && activeCrimes.Rows.Count > 0)
                {
                    cmbCrimes.DataSource = activeCrimes;
                    cmbCrimes.DisplayMember = "Title";    // What the Administrator sees
                    cmbCrimes.ValueMember = "CrimeID";     // The hidden underlying Primary Key ID
                }
                else
                {
                    MessageBox.Show("No active open cases require allocation at this time.", "Operational Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // 2. POPULATE ACTIVE OFFICERS DROPDOWN
                List<Investigator> officers = _investigatorRepo.GetAllInvestigators();

                if (officers != null && officers.Count > 0)
                {
                    // Convert strongly-typed OOP list into a display table for data binding
                    DataTable officerTable = new DataTable();
                    officerTable.Columns.Add("InvestigatorID", typeof(int));
                    officerTable.Columns.Add("FullName", typeof(string));

                    foreach (Investigator officer in officers)
                    {
                        officerTable.Rows.Add(officer.GetInvestigatorID(), officer.GetName());
                    }

                    cmbInvestigators.DataSource = officerTable;
                    cmbInvestigators.DisplayMember = "FullName";
                    cmbInvestigators.ValueMember = "InvestigatorID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to index dropdown operational buffers: " + ex.Message, "System Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbCrimes.SelectedValue == null || cmbInvestigators.SelectedValue == null)
            {
                MessageBox.Show("Please ensure an open case file and assignment officer are designated.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int targetedCrimeID = Convert.ToInt32(cmbCrimes.SelectedValue);
            int targetedInvestigatorID = Convert.ToInt32(cmbInvestigators.SelectedValue);

            try
            {
                // 3. DUPLICATE CHECK: Verify if this pair relationship link is already active
                string duplicateCheckQuery = $@"SELECT COUNT(*) FROM CrimeInvestigator 
                                                WHERE CrimeID = {targetedCrimeID} AND InvestigatorID = {targetedInvestigatorID}";

                DataTable checkTable = _dbHelper.ExecuteQuery(duplicateCheckQuery);
                if (checkTable != null && checkTable.Rows.Count > 0 && Convert.ToInt32(checkTable.Rows[0][0]) > 0)
                {
                    MessageBox.Show("This law enforcement officer is already actively assigned to manage this specific case file.", "Allocation Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. CALL YOUR REPOSITORY: Commit transaction records cleanly to the database
                bool success = _investigatorRepo.AssignToCase(targetedCrimeID, targetedInvestigatorID);

                if (success)
                {
                    MessageBox.Show("Case allocation records securely updated! This file will now populate on the officer's personal desk.", "Assignment Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Allocation transaction failed. Check database validation limits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pipeline transaction error executing case allocation: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}