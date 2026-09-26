namespace _2ndSemProject
{
    partial class frmLogDiary
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
            this.lblSummary = new System.Windows.Forms.Label();
            this.cmbSummaryTag = new System.Windows.Forms.ComboBox(); // Integrated Dropdown Component
            this.lblLog = new System.Windows.Forms.Label();
            this.txtEntryText = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form Canvas Overlays
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Text = "Append Field Progress Diary Ledger";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Selector Case Label
            this.lblCase.Text = "Select Target Case File:";
            this.lblCase.Location = new System.Drawing.Point(25, 25); this.lblCase.Width = 200;

            // Dropdown List Box
            this.cmbCases.Location = new System.Drawing.Point(25, 50); this.cmbCases.Size = new System.Drawing.Size(450, 25);
            this.cmbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCases.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbCases.ForeColor = System.Drawing.Color.White;

            // Summary Title Short Field Tag Label
            this.lblSummary.Text = "Select Activity Tag Category:";
            this.lblSummary.Location = new System.Drawing.Point(25, 95); this.lblSummary.Width = 350;

            // Activity Tag Dropdown Combo Box Setup
            this.cmbSummaryTag.Location = new System.Drawing.Point(25, 120); this.cmbSummaryTag.Size = new System.Drawing.Size(450, 25);
            this.cmbSummaryTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSummaryTag.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbSummaryTag.ForeColor = System.Drawing.Color.White;

            // Standardizing uniform tracking items
            this.cmbSummaryTag.Items.AddRange(new object[] {
                "Initial Scene Processing",
                "Witness Interview",
                "Suspect Interrogation",
                "Evidence Collection",
                "Forensic Analysis Sync",
                "Field Surveillance Log",
                "Legal Warrant Execution",
                "Case Status Note"
            });

            // Detailed Journal Text Label
            this.lblLog.Text = "Enter Detailed Chronological Field Log Entry:";
            this.lblLog.Location = new System.Drawing.Point(25, 165); this.lblLog.Width = 350;

            // Journal Entry Multiline Text area box
            this.txtEntryText.Location = new System.Drawing.Point(25, 190); this.txtEntryText.Size = new System.Drawing.Size(450, 140);
            this.txtEntryText.Multiline = true;
            this.txtEntryText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEntryText.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.txtEntryText.ForeColor = System.Drawing.Color.White;
            this.txtEntryText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Execute Commit Button Control Control
            this.btnSave.Text = "Commit Diary Log";
            this.btnSave.Location = new System.Drawing.Point(60, 355); this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255); // Neon Accent
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Cancel Button Control
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(280, 355); this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Append onto Main Window Control Canvas List
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCase, this.cmbCases, this.lblSummary, this.cmbSummaryTag, this.lblLog, this.txtEntryText, this.btnSave, this.btnCancel
            });
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Cleaned up component declarations
        private System.Windows.Forms.Label lblCase, lblSummary, lblLog;
        private System.Windows.Forms.ComboBox cmbCases;
        private System.Windows.Forms.ComboBox cmbSummaryTag;
        private System.Windows.Forms.TextBox txtEntryText;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}