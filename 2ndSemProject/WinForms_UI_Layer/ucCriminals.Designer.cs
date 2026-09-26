namespace _2ndSemProject
{
    partial class ucCriminals
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
            this.btnAddCriminal = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnSearchCriminals = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnMostWanted = new System.Windows.Forms.Button();
            this.pnlButtonGrid = new System.Windows.Forms.Panel();

            // 🔥 NEW Search & Grid Layout UI Component Extensions
            this.pnlDataViewWorkspace = new System.Windows.Forms.Panel();
            this.dgvCriminalsResult = new System.Windows.Forms.DataGridView();
            this.txtSearchInput = new System.Windows.Forms.TextBox();
            this.btnExecuteSearch = new System.Windows.Forms.Button();
            this.btnBackToMenu = new System.Windows.Forms.Button();

            this.pnlButtonGrid.SuspendLayout();
            this.pnlDataViewWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminalsResult)).BeginInit();
            this.SuspendLayout();

            // Premium Visual Typography Styles
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
            this.lblTabTitle.Size = new System.Drawing.Size(340, 30);
            this.lblTabTitle.Text = "CRIMINALS MANAGEMENT CORE";

            // lblInstructions
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblInstructions.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInstructions.Location = new System.Drawing.Point(33, 60);
            this.lblInstructions.Text = "Select an operational command option below to execute database profile tasks.";

            // pnlButtonGrid
            this.pnlButtonGrid.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlButtonGrid.Controls.Add(this.btnAddCriminal);
            this.pnlButtonGrid.Controls.Add(this.btnUpdateStatus);
            this.pnlButtonGrid.Controls.Add(this.btnSearchCriminals);
            this.pnlButtonGrid.Controls.Add(this.btnViewHistory);
            this.pnlButtonGrid.Controls.Add(this.btnMostWanted);
            this.pnlButtonGrid.Location = new System.Drawing.Point(35, 110);
            this.pnlButtonGrid.Size = new System.Drawing.Size(900, 450);

            System.Windows.Forms.Button[] actionButtons = {
                this.btnAddCriminal, this.btnUpdateStatus, this.btnSearchCriminals,
                this.btnViewHistory, this.btnMostWanted
            };

            int posX = 20; int posY = 20; int count = 0;
            foreach (System.Windows.Forms.Button btn in actionButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
                btn.Size = new System.Drawing.Size(260, 100);
                btn.Location = new System.Drawing.Point(posX, posY);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.MouseEnter += new System.EventHandler(this.ActionButton_MouseEnter);
                btn.MouseLeave += new System.EventHandler(this.ActionButton_MouseLeave);

                count++;
                if (count % 3 == 0) { posX = 20; posY += 130; }
                else { posX += 290; }
            }

            this.btnAddCriminal.Text = "➕  Register New Criminal";
            this.btnAddCriminal.Click += new System.EventHandler(this.btnRegisterCriminal_Click);

            this.btnUpdateStatus.Text = "🔄  Update Custody Status";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateCustodyStatusTile_Click);

            this.btnSearchCriminals.Text = "🔍  Search Criminal Index";
            this.btnSearchCriminals.Click += new System.EventHandler(this.btnSearchCriminals_Click);

            this.btnViewHistory.Text = "📜  View Prior Convictions";
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewPriorConvictionsTile_Click);

            this.btnMostWanted.Text = "🚨  Load Most Wanted";
            this.btnMostWanted.Click += new System.EventHandler(this.btnLoadMostWantedTile_Click);

            // -----------------------------------------------------------------
            // 🔥 NEW: pnlDataViewWorkspace Layout Definitions
            // -----------------------------------------------------------------
            this.pnlDataViewWorkspace.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlDataViewWorkspace.Controls.Add(this.txtSearchInput);
            this.pnlDataViewWorkspace.Controls.Add(this.btnExecuteSearch);
            this.pnlDataViewWorkspace.Controls.Add(this.dgvCriminalsResult);
            this.pnlDataViewWorkspace.Controls.Add(this.btnBackToMenu);
            this.pnlDataViewWorkspace.Location = new System.Drawing.Point(35, 110);
            this.pnlDataViewWorkspace.Size = new System.Drawing.Size(950, 450);
            this.pnlDataViewWorkspace.Visible = false; // Hidden by default menu rules

            // txtSearchInput
            this.txtSearchInput.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.txtSearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearchInput.ForeColor = System.Drawing.Color.White;
            this.txtSearchInput.Location = new System.Drawing.Point(20, 15);
            this.txtSearchInput.Size = new System.Drawing.Size(420, 27);

            // btnExecuteSearch
            this.btnExecuteSearch.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.btnExecuteSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnExecuteSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExecuteSearch.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnExecuteSearch.Location = new System.Drawing.Point(455, 12);
            this.btnExecuteSearch.Size = new System.Drawing.Size(150, 32);
            this.btnExecuteSearch.Text = "Run Search Query";
            this.btnExecuteSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecuteSearch.Click += new System.EventHandler(this.btnExecuteSearch_Click);

            // btnBackToMenu
            this.btnBackToMenu.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToMenu.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBackToMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBackToMenu.ForeColor = System.Drawing.Color.LightGray;
            this.btnBackToMenu.Location = new System.Drawing.Point(780, 12);
            this.btnBackToMenu.Size = new System.Drawing.Size(150, 32);
            this.btnBackToMenu.Text = "⬅️ Back to Menu";
            this.btnBackToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);

            // dgvCriminalsResult
            this.dgvCriminalsResult.EnableHeadersVisualStyles = false;
            this.dgvCriminalsResult.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvCriminalsResult.DefaultCellStyle = gridStyle;
            this.dgvCriminalsResult.GridColor = System.Drawing.Color.FromArgb(38, 38, 52);
            this.dgvCriminalsResult.RowHeadersVisible = false;
            this.dgvCriminalsResult.BackgroundColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.dgvCriminalsResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCriminalsResult.Location = new System.Drawing.Point(20, 60);
            this.dgvCriminalsResult.ReadOnly = true;
            this.dgvCriminalsResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCriminalsResult.Size = new System.Drawing.Size(910, 370);

            // ucCriminals Container Construction
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.Controls.Add(this.pnlDataViewWorkspace);
            this.Controls.Add(this.pnlButtonGrid);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblTabTitle);
            this.Size = new System.Drawing.Size(1000, 600);

            this.pnlButtonGrid.ResumeLayout(false);
            this.pnlDataViewWorkspace.ResumeLayout(false);
            this.pnlDataViewWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminalsResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTabTitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Panel pnlButtonGrid;
        private System.Windows.Forms.Button btnAddCriminal;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnSearchCriminals;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnMostWanted;

        // Extended Workspace Components Objects References
        private System.Windows.Forms.Panel pnlDataViewWorkspace;
        private System.Windows.Forms.DataGridView dgvCriminalsResult;
        private System.Windows.Forms.TextBox txtSearchInput;
        private System.Windows.Forms.Button btnExecuteSearch;
        private System.Windows.Forms.Button btnBackToMenu;
    }
}