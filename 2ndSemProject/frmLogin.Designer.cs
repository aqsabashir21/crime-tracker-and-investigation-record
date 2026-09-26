namespace _2ndSemProject
{
    partial class frmLogin
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
            this.pnlSecurityConsole = new System.Windows.Forms.Panel();
            this.lblTerminalTitle = new System.Windows.Forms.Label();
            this.lblTerminalLogs = new System.Windows.Forms.Label();
            this.lblLiveTime = new System.Windows.Forms.Label();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.pnlLoginCard = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblUserTag = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassTag = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlSecurityConsole.SuspendLayout();
            this.pnlLoginCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSecurityConsole
            // 
            this.pnlSecurityConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(26)))));
            this.pnlSecurityConsole.Controls.Add(this.lblTerminalTitle);
            this.pnlSecurityConsole.Controls.Add(this.lblTerminalLogs);
            this.pnlSecurityConsole.Controls.Add(this.lblLiveTime);
            this.pnlSecurityConsole.Controls.Add(this.lblDbStatus);
            this.pnlSecurityConsole.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSecurityConsole.Location = new System.Drawing.Point(0, 0);
            this.pnlSecurityConsole.Name = "pnlSecurityConsole";
            this.pnlSecurityConsole.Size = new System.Drawing.Size(340, 481);
            this.pnlSecurityConsole.TabIndex = 1;
            // 
            // lblTerminalTitle
            // 
            this.lblTerminalTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTerminalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblTerminalTitle.Location = new System.Drawing.Point(25, 35);
            this.lblTerminalTitle.Name = "lblTerminalTitle";
            this.lblTerminalTitle.Size = new System.Drawing.Size(290, 60);
            this.lblTerminalTitle.TabIndex = 0;
            this.lblTerminalTitle.Text = "CRIME TRACKER\r\nSECURITY MATRIX";
            // 
            // lblTerminalLogs
            // 
            this.lblTerminalLogs.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblTerminalLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.lblTerminalLogs.Location = new System.Drawing.Point(25, 120);
            this.lblTerminalLogs.Name = "lblTerminalLogs";
            this.lblTerminalLogs.Size = new System.Drawing.Size(290, 148);
            this.lblTerminalLogs.TabIndex = 1;
            this.lblTerminalLogs.Text = "SYSTEM STATUS: ACTIVE\r\nENCRYPTION: AES-256\r\nPORT NODE: SECURE SSL\r\nLOCATION: LAHO" +
    "RE CORE\r\n\r\nINITIALIZING IDENTITY CHECK...";
            // 
            // lblLiveTime
            // 
            this.lblLiveTime.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblLiveTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(155)))));
            this.lblLiveTime.Location = new System.Drawing.Point(25, 410);
            this.lblLiveTime.Name = "lblLiveTime";
            this.lblLiveTime.Size = new System.Drawing.Size(290, 20);
            this.lblLiveTime.TabIndex = 2;
            this.lblLiveTime.Text = "TIMESTAMP: --";
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblDbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.lblDbStatus.Location = new System.Drawing.Point(25, 435);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(290, 20);
            this.lblDbStatus.TabIndex = 3;
            this.lblDbStatus.Text = "DB CONTEXT: CONNECTED";
            // 
            // pnlLoginCard
            // 
            this.pnlLoginCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.pnlLoginCard.Controls.Add(this.lblHeading);
            this.pnlLoginCard.Controls.Add(this.lblUserTag);
            this.pnlLoginCard.Controls.Add(this.txtUsername);
            this.pnlLoginCard.Controls.Add(this.lblPassTag);
            this.pnlLoginCard.Controls.Add(this.txtPassword);
            this.pnlLoginCard.Controls.Add(this.lblError);
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Location = new System.Drawing.Point(395, 50);
            this.pnlLoginCard.Name = "pnlLoginCard";
            this.pnlLoginCard.Size = new System.Drawing.Size(420, 380);
            this.pnlLoginCard.TabIndex = 2;
            // 
            // lblHeading
            // 
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(30, 30);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(360, 35);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "AUTHENTICATION PORTAL";
            // 
            // lblUserTag
            // 
            this.lblUserTag.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUserTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(155)))));
            this.lblUserTag.Location = new System.Drawing.Point(30, 85);
            this.lblUserTag.Name = "lblUserTag";
            this.lblUserTag.Size = new System.Drawing.Size(360, 20);
            this.lblUserTag.TabIndex = 1;
            this.lblUserTag.Text = "OPERATIONAL USERNAME";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(20)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.Location = new System.Drawing.Point(30, 110);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(360, 32);
            this.txtUsername.TabIndex = 2;
            // 
            // lblPassTag
            // 
            this.lblPassTag.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPassTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(155)))));
            this.lblPassTag.Location = new System.Drawing.Point(30, 165);
            this.lblPassTag.Name = "lblPassTag";
            this.lblPassTag.Size = new System.Drawing.Size(360, 20);
            this.lblPassTag.TabIndex = 3;
            this.lblPassTag.Text = "SECURITY ACCESS PIN / PASSWORD";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(20)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(30, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(360, 32);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblError.Location = new System.Drawing.Point(30, 235);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(360, 40); this.lblError.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(20)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnLogin.Location = new System.Drawing.Point(30, 295);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(360, 45);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "ACCESS SYSTEM";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.BtnNeon_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.BtnNeon_MouseLeave);
            // 
            // frmLogin
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(864, 481);
            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.pnlSecurityConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure Core - Login Identity";
            this.pnlSecurityConsole.ResumeLayout(false);
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlSecurityConsole;
        private System.Windows.Forms.Label lblTerminalTitle;
        private System.Windows.Forms.Label lblTerminalLogs;
        private System.Windows.Forms.Label lblLiveTime;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Panel pnlLoginCard;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblUserTag;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassTag;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
    }
}