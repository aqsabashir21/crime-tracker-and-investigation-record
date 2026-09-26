using _2ndSemProject.Data_Access_Layer;
using _2ndSemProject.Core_OOP_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmWorkloadReport : Form
    {
        private readonly InvestigatorRepository _investigatorRepo = new InvestigatorRepository();
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public frmWorkloadReport()
        {
            InitializeComponent();
            LoadInvestigatorsDropdown();
        }

        // 1. Populate the Investigator Selector Dropdown
        private void LoadInvestigatorsDropdown()
        {
            try
            {
                List<Investigator> officers = _investigatorRepo.GetAllInvestigators();
                if (officers != null && officers.Count > 0)
                {
                    DataTable officerTable = new DataTable();
                    officerTable.Columns.Add("InvestigatorID", typeof(int));
                    officerTable.Columns.Add("FullName", typeof(string));

                    foreach (Investigator officer in officers)
                    {
                        officerTable.Rows.Add(officer.GetInvestigatorID(), officer.GetName());
                    }

                    cmbInvestigators.SelectedIndexChanged -= cmbInvestigators_SelectedIndexChanged;
                    cmbInvestigators.DataSource = officerTable;
                    cmbInvestigators.DisplayMember = "FullName";
                    cmbInvestigators.ValueMember = "InvestigatorID";
                    cmbInvestigators.SelectedIndexChanged += cmbInvestigators_SelectedIndexChanged;

                    // Trigger the first load automatically
                    UpdateCasesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading officers dropdown: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbInvestigators_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCasesGrid();
        }

        // 2. Fetch all cases assigned to the selected investigator
        private void UpdateCasesGrid()
        {
            if (cmbInvestigators.SelectedValue == null || cmbInvestigators.SelectedValue is DataRowView) return;

            int selectedInvID = Convert.ToInt32(cmbInvestigators.SelectedValue);
            try
            {
                dgvCases.DataSource = null;
                dgvLogs.DataSource = null; // Clear out old histories

                // Uses your existing repository method to get cases assigned to this ID
                DataTable casesTable = _investigatorRepo.GetAssignedCases(selectedInvID);
                dgvCases.DataSource = casesTable;

                if (casesTable != null && casesTable.Rows.Count > 0)
                {
                    lblStatus.Text = $"Found {casesTable.Rows.Count} active case files assigned to this officer.";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
                }
                else
                {
                    lblStatus.Text = "This officer has no active case assignments.";
                    lblStatus.ForeColor = System.Drawing.Color.DarkGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error pulling cases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateLogsGrid();
        }

        private void dgvCases_SelectionChanged(object sender, EventArgs e)
        {
            UpdateLogsGrid();
        }

        // 3. Dynamic Log Tracker: Pulls progress updates whenever a case row is highlighted
        // 3. Dynamic Log Tracker: Pulls progress updates whenever a case row is highlighted
        // 3. Dynamic Log Tracker: Pulls progress updates whenever a case row is highlighted
        private void UpdateLogsGrid()
        {
            // Safety check: ensure a case row is highlighted in the grid layout
            if (dgvCases.CurrentRow == null || dgvCases.CurrentRow.Cells["CrimeID"].Value == null)
            {
                dgvLogs.DataSource = null;
                return;
            }

            int currentCrimeID = Convert.ToInt32(dgvCases.CurrentRow.Cells["CrimeID"].Value);

            try
            {
                dgvLogs.DataSource = null;

                // ✅ EXACT SQL SCHEMA MATCH: Pulls directly from your True CaseLogs table setup!
                string realLogQuery = $@"SELECT LogID AS [Log ID], 
                                                UpdateTxt AS [Progress Description], 
                                                UpdateDate AS [Timestamp Mapped] 
                                         FROM CaseLogs 
                                         WHERE CrimeID = {currentCrimeID} 
                                         ORDER BY UpdateDate DESC";

                DataTable logsTable = _dbHelper.ExecuteQuery(realLogQuery);
                dgvLogs.DataSource = logsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to link operational tracking streams: {ex.Message}",
                                "System Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}