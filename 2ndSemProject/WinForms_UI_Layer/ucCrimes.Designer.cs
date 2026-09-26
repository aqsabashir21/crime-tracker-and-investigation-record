namespace _2ndSemProject
{
    partial class ucCrimes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle gridStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTabTitle = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnReportCrime = new System.Windows.Forms.Button();
            this.btnAddCaseLog = new System.Windows.Forms.Button();
            this.btnAddEvidence = new System.Windows.Forms.Button();
            this.btnCloseCase = new System.Windows.Forms.Button();
            this.btnSearchCrimes = new System.Windows.Forms.Button();
            this.btnViewActive = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.btnViewEvidence = new System.Windows.Forms.Button();
            this.btnViewVictim = new System.Windows.Forms.Button();
            this.pnlButtonGrid = new System.Windows.Forms.Panel();

            // 🔥 NEW: Extended Operational Sub-workspace Panels Components
            this.pnlCrimesDataWorkspace = new System.Windows.Forms.Panel();
            this.dgvCrimesMaster = new System.Windows.Forms.DataGridView();
            this.lblFilter1 = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.txtFilterLocation = new System.Windows.Forms.TextBox();
            this.btnRunQuery = new System.Windows.Forms.Button();
            this.btnReturnToMenu = new System.Windows.Forms.Button();

            this.pnlButtonGrid.SuspendLayout();
            this.pnlCrimesDataWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrimesMaster)).BeginInit();
            this.SuspendLayout();

            // Style profiles matching your premium dark-mode application shell
            gridStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            gridStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            gridStyle.ForeColor = System.Drawing.Color.White;
            gridStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 150, 255);
            gridStyle.SelectionForeColor = System.Drawing.Color.FromArgb(18, 18, 24);

            headerStyle.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 150, 255);

            // lblTabTitle
            this.lblTabTitle.AutoSize = true;
            this.lblTabTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTabTitle.ForeColor = System.Drawing.Color.White;
            this.lblTabTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTabTitle.Size = new System.Drawing.Size(301, 30);
            this.lblTabTitle.Text = "INCIDENT LOGS & CASE CORE";

            // lblInstructions
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblInstructions.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInstructions.Location = new System.Drawing.Point(33, 60);
            this.lblInstructions.Text = "Execute case modifications, attach field logs, register forensic proof elements, or query view sheets.";

            // pnlButtonGrid
            this.pnlButtonGrid.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlButtonGrid.Controls.Add(this.btnReportCrime);
            this.pnlButtonGrid.Controls.Add(this.btnAddCaseLog);
            this.pnlButtonGrid.Controls.Add(this.btnAddEvidence);
            this.pnlButtonGrid.Controls.Add(this.btnCloseCase);
            this.pnlButtonGrid.Controls.Add(this.btnSearchCrimes);
            this.pnlButtonGrid.Controls.Add(this.btnViewActive);
            this.pnlButtonGrid.Controls.Add(this.btnViewLogs);
            this.pnlButtonGrid.Controls.Add(this.btnViewEvidence);
            this.pnlButtonGrid.Controls.Add(this.btnViewVictim);
            this.pnlButtonGrid.Location = new System.Drawing.Point(35, 110);
            this.pnlButtonGrid.Size = new System.Drawing.Size(900, 450);

            System.Windows.Forms.Button[] actionButtons = {
                this.btnReportCrime, this.btnAddCaseLog, this.btnAddEvidence,
                this.btnCloseCase, this.btnSearchCrimes, this.btnViewActive,
                this.btnViewLogs, this.btnViewEvidence, this.btnViewVictim
            };

            int posX = 20; int posY = 20; int count = 0;
            foreach (System.Windows.Forms.Button btn in actionButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Size = new System.Drawing.Size(260, 90);
                btn.Location = new System.Drawing.Point(posX, posY);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.MouseEnter += new System.EventHandler(this.ActionButton_MouseEnter);
                btn.MouseLeave += new System.EventHandler(this.ActionButton_MouseLeave);

                count++;
                if (count % 3 == 0) { posX = 20; posY += 120; }
                else { posX += 290; }
            }

            // Click Handlers bindings matching your properties
            this.btnReportCrime.Text = "📁  Report New Crime";
            this.btnReportCrime.Click += new System.EventHandler(this.btnReportCrime_Click);
            this.btnAddCaseLog.Text = "✍️  Log Progress Diary";
            this.btnAddCaseLog.Click += new System.EventHandler(this.btnLogProgressDiaryTile_Click);
            this.btnAddEvidence.Text = "🧪  Log Case Evidence";
            this.btnAddEvidence.Click += new System.EventHandler(this.btnLogCaseEvidenceTile_Click);
            this.btnCloseCase.Text = "🔒  Formally Close Case";
            this.btnCloseCase.Click += new System.EventHandler(this.btnFormallyCloseCaseTile_Click);
            this.btnSearchCrimes.Text = "🔍  Search Incident Index";
            this.btnSearchCrimes.Click += new System.EventHandler(this.btnSearchCrimes_Click);
            this.btnViewActive.Text = "📋  View Active Cases";
            this.btnViewActive.Click += new System.EventHandler(this.btnViewActive_Click);
            this.btnViewLogs.Text = "📜  View Case History Logs";
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewCaseHistoryLogsTile_Click);
            this.btnViewEvidence.Text = "🧬  View Case Evidence";
            this.btnViewEvidence.Click += new System.EventHandler(this.btnViewCaseEvidenceTile_Click);
            this.btnViewVictim.Text = "👥  View Victim Records";
            this.btnViewVictim.Click += new System.EventHandler(this.btnViewVictimRecordsTile_Click);

            // -----------------------------------------------------------------
            // 🔥 NEW: pnlCrimesDataWorkspace Layout Structural Map
            // -----------------------------------------------------------------
            this.pnlCrimesDataWorkspace.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlCrimesDataWorkspace.Controls.Add(this.lblFilter1);
            this.pnlCrimesDataWorkspace.Controls.Add(this.cmbFilterType);
            this.pnlCrimesDataWorkspace.Controls.Add(this.lblFilter2);
            this.pnlCrimesDataWorkspace.Controls.Add(this.txtFilterLocation);
            this.pnlCrimesDataWorkspace.Controls.Add(this.btnRunQuery);
            this.pnlCrimesDataWorkspace.Controls.Add(this.dgvCrimesMaster);
            this.pnlCrimesDataWorkspace.Controls.Add(this.btnReturnToMenu);
            this.pnlCrimesDataWorkspace.Location = new System.Drawing.Point(35, 110);
            this.pnlCrimesDataWorkspace.Size = new System.Drawing.Size(950, 450);
            this.pnlCrimesDataWorkspace.Visible = false;

            // Labels & Dropdowns for Search Filtering Layout Bounds
            this.lblFilter1.Text = "Crime Classification:"; this.lblFilter1.Location = new System.Drawing.Point(20, 18); this.lblFilter1.ForeColor = System.Drawing.Color.LightGray;
            this.cmbFilterType.Location = new System.Drawing.Point(150, 15); this.cmbFilterType.Size = new System.Drawing.Size(160, 25);
            this.cmbFilterType.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbFilterType.ForeColor = System.Drawing.Color.White;
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Items.AddRange(new object[] { "ALL", "Robbery", "Murder", "Fraud", "Theft" });

            this.lblFilter2.Text = "Scene Location:"; this.lblFilter2.Location = new System.Drawing.Point(330, 18); this.lblFilter2.ForeColor = System.Drawing.Color.LightGray;
            this.txtFilterLocation.Location = new System.Drawing.Point(430, 15); this.txtFilterLocation.Size = new System.Drawing.Size(180, 25);
            this.txtFilterLocation.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtFilterLocation.ForeColor = System.Drawing.Color.White;
            this.txtFilterLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnRunQuery
            this.btnRunQuery.Text = "Filter Index Rows";
            this.btnRunQuery.Location = new System.Drawing.Point(630, 12); this.btnRunQuery.Size = new System.Drawing.Size(130, 30);
            this.btnRunQuery.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.btnRunQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunQuery.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnRunQuery.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);

            // btnReturnToMenu
            this.btnReturnToMenu.Text = "⬅️ Back to Matrix";
            this.btnReturnToMenu.Location = new System.Drawing.Point(780, 12); this.btnReturnToMenu.Size = new System.Drawing.Size(145, 30);
            this.btnReturnToMenu.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.btnReturnToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnToMenu.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnReturnToMenu.ForeColor = System.Drawing.Color.LightGray;
            this.btnReturnToMenu.Click += new System.EventHandler(this.btnReturnToMenu_Click);

            // dgvCrimesMaster
            this.dgvCrimesMaster.EnableHeadersVisualStyles = false;
            this.dgvCrimesMaster.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvCrimesMaster.DefaultCellStyle = gridStyle;
            this.dgvCrimesMaster.GridColor = System.Drawing.Color.FromArgb(38, 38, 52);
            this.dgvCrimesMaster.RowHeadersVisible = false;
            this.dgvCrimesMaster.BackgroundColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.dgvCrimesMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCrimesMaster.Location = new System.Drawing.Point(20, 60);
            this.dgvCrimesMaster.ReadOnly = true;
            this.dgvCrimesMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCrimesMaster.Size = new System.Drawing.Size(910, 370);

            // ucCrimes Control Construction
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.Controls.Add(this.pnlCrimesDataWorkspace);
            this.Controls.Add(this.pnlButtonGrid);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblTabTitle);
            this.Size = new System.Drawing.Size(1000, 600);
            this.pnlButtonGrid.ResumeLayout(false);
            this.pnlCrimesDataWorkspace.ResumeLayout(false);
            this.pnlCrimesDataWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrimesMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTabTitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Panel pnlButtonGrid;
        private System.Windows.Forms.Button btnReportCrime;
        private System.Windows.Forms.Button btnAddCaseLog;
        private System.Windows.Forms.Button btnAddEvidence;
        private System.Windows.Forms.Button btnCloseCase;
        private System.Windows.Forms.Button btnSearchCrimes;
        private System.Windows.Forms.Button btnViewActive;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.Button btnViewEvidence;
        private System.Windows.Forms.Button btnViewVictim;

        // Workspace Container Objects Reference
        private System.Windows.Forms.Panel pnlCrimesDataWorkspace;
        private System.Windows.Forms.DataGridView dgvCrimesMaster;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.TextBox txtFilterLocation;
        private System.Windows.Forms.Button btnRunQuery;
        private System.Windows.Forms.Button btnReturnToMenu;
    }
}