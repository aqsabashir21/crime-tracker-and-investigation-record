namespace _2ndSemProject
{
    partial class frmAddConviction
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
            this.lblCriminal = new System.Windows.Forms.Label();
            this.cmbCriminals = new System.Windows.Forms.ComboBox();
            this.lblCrime = new System.Windows.Forms.Label();
            this.cmbCrimes = new System.Windows.Forms.ComboBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form Canvas Setup
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ClientSize = new System.Drawing.Size(430, 220);
            this.Text = "Log New Conviction Incident File";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Criminal Selection Layout
            this.lblCriminal.Text = "Select Suspect Profile:";
            this.lblCriminal.Location = new System.Drawing.Point(20, 30); this.lblCriminal.Width = 150;

            this.cmbCriminals.Location = new System.Drawing.Point(180, 27); this.cmbCriminals.Size = new System.Drawing.Size(220, 25);
            this.cmbCriminals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriminals.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbCriminals.ForeColor = System.Drawing.Color.White;

            // Crime Incident Selection Layout
            this.lblCrime.Text = "Select Crime Offense:";
            this.lblCrime.Location = new System.Drawing.Point(20, 85); this.lblCrime.Width = 150;

            this.cmbCrimes.Location = new System.Drawing.Point(180, 82); this.cmbCrimes.Size = new System.Drawing.Size(220, 25);
            this.cmbCrimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrimes.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); this.cmbCrimes.ForeColor = System.Drawing.Color.White;

            // Execution Action Button
            this.btnLink.Text = "Record Conviction";
            this.btnLink.Location = new System.Drawing.Point(40, 150); this.btnLink.Size = new System.Drawing.Size(150, 40);
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnLink.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);

            // Cancel Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(230, 150); this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Append Controls
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCriminal, this.cmbCriminals, this.lblCrime, this.cmbCrimes, this.btnLink, this.btnCancel
            });
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblCriminal, lblCrime;
        private System.Windows.Forms.ComboBox cmbCriminals, cmbCrimes;
        private System.Windows.Forms.Button btnLink, btnCancel;
    }
}