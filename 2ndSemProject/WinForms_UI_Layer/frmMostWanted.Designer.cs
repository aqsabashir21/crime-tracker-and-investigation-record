namespace _2ndSemProject
{
    partial class frmMostWanted
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvMostWanted = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.cmbAddSuspect = new System.Windows.Forms.ComboBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostWanted)).BeginInit();
            this.SuspendLayout();

            // Form Canvas Setup
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ClientSize = new System.Drawing.Size(700, 490);
            this.Text = "High-Priority Most Wanted Registry Terminal";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Panel Title Header Label
            this.lblTitle.Text = "MOST WANTED CRIMINAL TARGET INDEX";
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Size = new System.Drawing.Size(400, 25);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40);

            // Profiles Registry Matrix DataGridView Data Binding Grid
            this.dgvMostWanted.Location = new System.Drawing.Point(25, 50);
            this.dgvMostWanted.Size = new System.Drawing.Size(650, 200);
            this.dgvMostWanted.BackgroundColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.dgvMostWanted.ForeColor = System.Drawing.Color.Black;
            this.dgvMostWanted.ReadOnly = true;
            this.dgvMostWanted.AllowUserToAddRows = false;
            this.dgvMostWanted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMostWanted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Operational Intelligence Alert Status Track Label
            this.lblStatus.Text = "Querying database secure matrix files...";
            this.lblStatus.Location = new System.Drawing.Point(25, 265);
            this.lblStatus.Size = new System.Drawing.Size(650, 20);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);

            // --- MANAGEMENT OPERATIONS SECTION CONTAINER INTERFACE ---
            this.lblAddTitle.Text = "Flag New Suspect as High-Priority Target:";
            this.lblAddTitle.Location = new System.Drawing.Point(25, 305);
            this.lblAddTitle.Size = new System.Drawing.Size(300, 20);
            this.lblAddTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);

            // Combobox
            this.cmbAddSuspect.Location = new System.Drawing.Point(25, 335);
            this.cmbAddSuspect.Size = new System.Drawing.Size(450, 25);
            this.cmbAddSuspect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddSuspect.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.cmbAddSuspect.ForeColor = System.Drawing.Color.White;

            // Button Add
            this.btnAddToList.Text = "+ Flag Target";
            this.btnAddToList.Location = new System.Drawing.Point(495, 330);
            this.btnAddToList.Size = new System.Drawing.Size(180, 32);
            this.btnAddToList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 40, 40);
            this.btnAddToList.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40);
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);

            // Button Remove Selection
            this.btnRemoveFromList.Text = "❌ Stand Down Selected Row Target";
            this.btnRemoveFromList.Location = new System.Drawing.Point(25, 395);
            this.btnRemoveFromList.Size = new System.Drawing.Size(300, 38);
            this.btnRemoveFromList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromList.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnRemoveFromList.ForeColor = System.Drawing.Color.Orange;
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);

            // Escape Close Control Button Interface
            this.btnClose.Text = "Close Terminal Screen";
            this.btnClose.Location = new System.Drawing.Point(495, 435);
            this.btnClose.Size = new System.Drawing.Size(180, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Append Structural UI Elements onto Form Controls Container
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvMostWanted, this.lblStatus, this.lblAddTitle,
                this.cmbAddSuspect, this.btnAddToList, this.btnRemoveFromList, this.btnClose
            });
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostWanted)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblAddTitle;
        private System.Windows.Forms.DataGridView dgvMostWanted;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbAddSuspect;
        private System.Windows.Forms.Button btnAddToList, btnRemoveFromList, btnClose;
    }
}