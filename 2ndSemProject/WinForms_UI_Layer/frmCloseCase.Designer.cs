namespace _2ndSemProject
{
    partial class frmCloseCase
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbFinalStatus = new System.Windows.Forms.ComboBox();
            this.btnConfirmClosure = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form Canvas Setup
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Text = "Formal Investigation Closure Console Execution";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Selector Case File Label
            this.lblCase.Text = "Select Active Docket Target:";
            this.lblCase.Location = new System.Drawing.Point(25, 25); this.lblCase.Width = 250;

            // Cases ComboBox
            this.cmbCases.Location = new System.Drawing.Point(25, 50); this.cmbCases.Size = new System.Drawing.Size(450, 25);
            this.cmbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCases.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbCases.ForeColor = System.Drawing.Color.White;

            // Final Status Designation Label
            this.lblStatus.Text = "Select Official Final Disposition Status:";
            this.lblStatus.Location = new System.Drawing.Point(25, 95); this.lblStatus.Width = 300;

            // Final Status Designation Dropdown
            this.cmbFinalStatus.Location = new System.Drawing.Point(25, 120); this.cmbFinalStatus.Size = new System.Drawing.Size(450, 25);
            this.cmbFinalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinalStatus.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbFinalStatus.ForeColor = System.Drawing.Color.White;
            // These choices map perfectly to your CHECK constraints on the column string entries!
            this.cmbFinalStatus.Items.AddRange(new object[] { "Solved", "Closed" });

            // Execute Confirm Close Button Control
            this.btnConfirmClosure.Text = "🔒 Seal Dossier File";
            this.btnConfirmClosure.Location = new System.Drawing.Point(60, 185); this.btnConfirmClosure.Size = new System.Drawing.Size(160, 40);
            this.btnConfirmClosure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmClosure.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 40, 40); // Threat Crimson Accent
            this.btnConfirmClosure.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40);
            this.btnConfirmClosure.Click += new System.EventHandler(this.btnConfirmClosure_Click);

            // Abort Control Button
            this.btnCancel.Text = "Abort Operation";
            this.btnCancel.Location = new System.Drawing.Point(280, 185); this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Append Structural components to display canvas hierarchy list
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCase, this.cmbCases, this.lblStatus, this.cmbFinalStatus, this.btnConfirmClosure, this.btnCancel
            });
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblCase, lblStatus;
        private System.Windows.Forms.ComboBox cmbCases;
        private System.Windows.Forms.ComboBox cmbFinalStatus;
        private System.Windows.Forms.Button btnConfirmClosure, btnCancel;
    }
}