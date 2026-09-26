namespace _2ndSemProject
{
    partial class frmLogEvidence
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
            this.lblCase = new System.Windows.Forms.Label();
            this.cmbCases = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbEvidenceType = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cmbItemName = new System.Windows.Forms.ComboBox(); // Changed to ComboBox
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox(); // Changed to ComboBox
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form Canvas Overlays
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ClientSize = new System.Drawing.Size(500, 485);
            this.Text = "Register Forensic Evidence Metadata Entry";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Selector Case Label
            this.lblCase.Text = "Select Associated Case File:";
            this.lblCase.Location = new System.Drawing.Point(25, 20); this.lblCase.Width = 200;

            // Cases ComboBox Dropdown
            this.cmbCases.Location = new System.Drawing.Point(25, 45); this.cmbCases.Size = new System.Drawing.Size(450, 25);
            this.cmbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCases.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbCases.ForeColor = System.Drawing.Color.White;

            // Evidence Classification Category Label (Moved up to drive the item list!)
            this.lblType.Text = "Select Evidence Classification Category:";
            this.lblType.Location = new System.Drawing.Point(25, 90); this.lblType.Width = 300;

            // Classification Dropdown ComboBox
            this.cmbEvidenceType.Location = new System.Drawing.Point(25, 115); this.cmbEvidenceType.Size = new System.Drawing.Size(450, 25);
            this.cmbEvidenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvidenceType.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbEvidenceType.ForeColor = System.Drawing.Color.White;
            this.cmbEvidenceType.Items.AddRange(new object[] {
                "Digital (Storage Drive, Log Scan)",
                "Physical Object (Weapon, Tool)",
                "Biological Sample (DNA, Print)",
                "Documentary (Contract, Statement)",
                "Media Capture (CCTV, Audio)"
            });
            this.cmbEvidenceType.SelectedIndexChanged += new System.EventHandler(this.cmbEvidenceType_SelectedIndexChanged);

            // Evidence Item Title Label
            this.lblItemName.Text = "Evidence Item Name/Label:";
            this.lblItemName.Location = new System.Drawing.Point(25, 160); this.lblItemName.Width = 200;

            // Evidence Item ComboBox Dropdown
            this.cmbItemName.Location = new System.Drawing.Point(25, 185); this.cmbItemName.Size = new System.Drawing.Size(450, 25);
            this.cmbItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemName.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbItemName.ForeColor = System.Drawing.Color.White;

            // Locker Storage Vault Location Label
            this.lblLocation.Text = "Locker Storage/Vault Location Identifier:";
            this.lblLocation.Location = new System.Drawing.Point(25, 230); this.lblLocation.Width = 300;

            // Locker Storage ComboBox Dropdown
            this.cmbLocation.Location = new System.Drawing.Point(25, 255); this.cmbLocation.Size = new System.Drawing.Size(450, 25);
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbLocation.ForeColor = System.Drawing.Color.White;

            // Summary Explanatory Description Notes Label
            this.lblDescription.Text = "Enter Summary Condition Explanatory Notes (Optional):";
            this.lblDescription.Location = new System.Drawing.Point(25, 300); this.lblDescription.Width = 380;

            // Description Notes TextBox
            this.txtDescription.Location = new System.Drawing.Point(25, 325); this.txtDescription.Size = new System.Drawing.Size(450, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Execute Commit Button
            this.btnSave.Text = "Secure Evidence Item";
            this.btnSave.Location = new System.Drawing.Point(60, 425); this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Abort Control Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(280, 425); this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Mount Component Structs
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCase, this.cmbCases, this.lblType, this.cmbEvidenceType,
                this.lblItemName, this.cmbItemName, this.lblLocation, this.cmbLocation,
                this.lblDescription, this.txtDescription, this.btnSave, this.btnCancel
            });
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCase, lblItemName, lblType, lblLocation, lblDescription;
        private System.Windows.Forms.ComboBox cmbCases;
        private System.Windows.Forms.ComboBox cmbEvidenceType;
        private System.Windows.Forms.ComboBox cmbItemName;  // Dropdown reference
        private System.Windows.Forms.ComboBox cmbLocation;  // Dropdown reference
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}