using System;
using System.Data;
using System.Windows.Forms;
using _2ndSemProject.Core_OOP_Layer; // Give access to business entities
using _2ndSemProject.Data_Access_Layer; // Give connectivity to ADO Repositories

namespace _2ndSemProject
{
    public partial class ucCrimes : UserControl
    {
        private readonly CrimeRepository _crimeRepo = new CrimeRepository();
        private int _currentInvestigatorID = 0; // Tracks active logged-in officer tracking token
        private string _activeSubViewMode = "GENERAL"; // Tracks localized operational states

        public ucCrimes()
        {
            InitializeComponent();
            cmbFilterType.SelectedIndex = 0; // Defaults the type dropdown search value to 'ALL'
        }

        public ucCrimes(int investigatorID) : this()
        {
            this._currentInvestigatorID = investigatorID; //
        }

        private void btnReportCrime_Click(object sender, EventArgs e)
        {
            // Opens your law dossier filing popup form modally
            using (frmReportCrime form = new frmReportCrime(_currentInvestigatorID)) //
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (pnlCrimesDataWorkspace.Visible) RefreshCrimesGridView();
                }
            }
        }

        // =====================================================================
        // 📋 MASTER INCIDENT QUERIES & VIEW INTEGRATIONS
        // =====================================================================
        private void btnSearchCrimes_Click(object sender, EventArgs e)
        {
            _activeSubViewMode = "SEARCH";
            lblTabTitle.Text = "MULTI-PARAMETER INCIDENT FILE EXPLORER";
            lblInstructions.Text = "Select specific types or enter locations to query filtered crime rows straight from server disks.";

            // Un-hide filter controls for manual criteria configuration
            SetSearchFiltersVisibility(visible: true);
            ToggleWorkspaceView(showGridData: true);
            ExecuteSearchFilterQuery();
        }

        private void btnViewActive_Click(object sender, EventArgs e)
        {
            _activeSubViewMode = "ACTIVE";
            lblTabTitle.Text = "UNRESOLVED LAW ENFORCEMENT INVESTIGATIONS";
            lblInstructions.Text = "Displaying ongoing investigation files streaming directly from the system's active view matrices.";

            // Hide custom search filters since this pulls an automated system dashboard view
            SetSearchFiltersVisibility(visible: false);
            ToggleWorkspaceView(showGridData: true);
            LoadActiveCasesFromView();
        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            ExecuteSearchFilterQuery();
        }

        private void ExecuteSearchFilterQuery()
        {
            try
            {
                // Extracts selection strings, mapping 'ALL' back to a null parameter state
                string crimeType = cmbFilterType.SelectedItem.ToString() == "ALL" ? "" : cmbFilterType.SelectedItem.ToString();
                string location = txtFilterLocation.Text.Trim();

                // Runs your sp_SearchCrime stored procedure mapping
                DataTable results = _crimeRepo.SearchCrimes(crimeType, location, "");
                dgvCrimesMaster.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing multi-parameter case lookup: " + ex.Message, "Query Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadActiveCasesFromView()
        {
            try
            {
                // Fetches live unresolved case data via vw_ActiveCases endpoint
                DataTable dtActive = _crimeRepo.GetActiveCases();
                dgvCrimesMaster.DataSource = dtActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error streaming from dynamic database views: " + ex.Message, "Query Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCrimesGridView()
        {
            if (_activeSubViewMode == "ACTIVE") LoadActiveCasesFromView();
            else ExecuteSearchFilterQuery();
        }

        // =====================================================================
        // ⚙️ RELATIONAL WORKSPACE PROFILE SUB-COMMAND OPERATIONS
        // =====================================================================
        private int GetSelectedMasterCrimeID()
        {
            if (dgvCrimesMaster.SelectedRows.Count > 0 && pnlCrimesDataWorkspace.Visible)
            {
                try { return Convert.ToInt32(dgvCrimesMaster.SelectedRows[0].Cells["CrimeID"].Value); }
                catch { return Convert.ToInt32(dgvCrimesMaster.SelectedRows[0].Cells[0].Value); }
            }
            return -1;
        }

        private void btnLogProgressDiaryTile_Click(object sender, EventArgs e) //
        {
            // Launch the diary logs registration wizard panel as a modal focused overlay dialog window
            using (frmLogDiary diaryWizard = new frmLogDiary())
            {
                diaryWizard.ShowDialog();
            }
        }

        private void btnLogCaseEvidenceTile_Click(object sender, EventArgs e) //
        {
            // Initialize the evidence filing form wizard as a focused overlay modal dialog window
            using (frmLogEvidence evidenceWizard = new frmLogEvidence())
            {
                evidenceWizard.ShowDialog();
            }
        }

        private void btnFormallyCloseCaseTile_Click(object sender, EventArgs e) //
        {
            // Fire up the transactional closure wizard panel as a focused modal dialogue form overlay
            using (frmCloseCase closureWizard = new frmCloseCase())
            {
                closureWizard.ShowDialog();
            }
        }

        // =====================================================================
        // 📑 ROW-LEVEL CHILD TABLES EXTRACTIONS (SUB-QUERIES)
        // =====================================================================
        private void btnViewCaseHistoryLogsTile_Click(object sender, EventArgs e) //
        {
            // Fire open the timeline history tracking sheet as a modal overlay window
            using (frmViewDiary historyViewer = new frmViewDiary())
            {
                historyViewer.ShowDialog();
            }
        }

        private void btnViewCaseEvidenceTile_Click(object sender, EventArgs e) //
        {
            // Fire open the evidence manifest tracking grid overlay form as a focused modal dialogue
            using (frmViewEvidence manifestViewer = new frmViewEvidence())
            {
                manifestViewer.ShowDialog();
            }
        }

        private void btnViewVictimRecordsTile_Click(object sender, EventArgs e) //
        {
            // Launch the combined interactive victims console panel overlay as a modal dialog focus
            using (frmViewVictims victimsWizard = new frmViewVictims())
            {
                victimsWizard.ShowDialog();
            }
        }

        // =====================================================================
        // 🔙 VISUAL LAYER INTERACTION TRANSLATIONS HELPERS
        // =====================================================================
        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            lblTabTitle.Text = "INCIDENT LOGS & CASE CORE";
            lblInstructions.Text = "Execute case modifications, attach field logs, register forensic proof elements, or query view sheets.";
            ToggleWorkspaceView(showGridData: false);
        }

        private void ToggleWorkspaceView(bool showGridData)
        {
            pnlButtonGrid.Visible = !showGridData;
            pnlCrimesDataWorkspace.Visible = showGridData;
        }

        private void SetSearchFiltersVisibility(bool visible)
        {
            lblFilter1.Visible = visible; cmbFilterType.Visible = visible;
            lblFilter2.Visible = visible; txtFilterLocation.Visible = visible;
            btnRunQuery.Visible = visible;
        }

        private string PromptForTextInput(string message, string headerText)
        {
            Form popup = new Form()
            {
                Width = 420,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = headerText,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.FromArgb(18, 18, 24),
                ForeColor = System.Drawing.Color.White
            };
            Label lbl = new Label() { Left = 20, Top = 15, Width = 370, Text = message, Font = new System.Drawing.Font("Segoe UI", 9F) };
            TextBox box = new TextBox() { Left = 20, Top = 55, Width = 360, Multiline = true, Height = 50, BackColor = System.Drawing.Color.FromArgb(28, 28, 38), ForeColor = System.Drawing.Color.White };
            Button confirm = new Button() { Text = "Submit Execution", Left = 230, Width = 150, Top = 120, Height = 32, DialogResult = DialogResult.OK, FlatStyle = FlatStyle.Flat };
            confirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255); confirm.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);

            popup.Controls.AddRange(new Control[] { lbl, box, confirm });
            popup.AcceptButton = confirm;
            return popup.ShowDialog() == DialogResult.OK ? box.Text : "";
        }

        // Hover Animations System
        private void ActionButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(0, 150, 255);
            btn.ForeColor = System.Drawing.Color.FromArgb(18, 18, 24);
        }

        private void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
        }
    }
}