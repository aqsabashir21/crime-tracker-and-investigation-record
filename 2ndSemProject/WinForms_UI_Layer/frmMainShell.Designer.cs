using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    partial class frmMainShell
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnCriminals = new System.Windows.Forms.Button();
            this.btnCrimes = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnCloseCase = new System.Windows.Forms.Button();
            this.btnMyCase = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlWorkspace = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();

            // -----------------------------------------------------------------
            // 🌌 pnlHeader (Obsidian Top Bar Bar)
            // -----------------------------------------------------------------
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblRole);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 65;

            // lblAppTitle
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            this.lblAppTitle.Location = new System.Drawing.Point(20, 22);
            this.lblAppTitle.Text = "CRIME RECORD & INVESTIGATION TRACKER";

            // lblWelcome
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(1000, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Text = "Welcome,";

            // lblRole
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(50, 205, 50);
            this.lblRole.Location = new System.Drawing.Point(1000, 35);
            this.lblRole.Name = "lblRole";
            this.lblRole.Text = "Role:";

            // -----------------------------------------------------------------
            // 🎛️ pnlNav (Side bar panel container)
            // -----------------------------------------------------------------
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.pnlNav.Controls.Add(this.btnDashboard);
            this.pnlNav.Controls.Add(this.btnCriminals);
            this.pnlNav.Controls.Add(this.btnCrimes);
            this.pnlNav.Controls.Add(this.btnAssign);
            this.pnlNav.Controls.Add(this.btnCloseCase);
            this.pnlNav.Controls.Add(this.btnMyCase);
            this.pnlNav.Controls.Add(this.btnLogout);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Width = 220;

            // Stacking standard navigation configurations cleanly[cite: 8]
            System.Windows.Forms.Button[] navButtons = { btnDashboard, btnCriminals, btnCrimes, btnAssign, btnCloseCase, btnMyCase };
            foreach (System.Windows.Forms.Button btn in navButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
                btn.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
                btn.Size = new System.Drawing.Size(220, 48);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;

                btn.MouseEnter += new System.EventHandler(this.NavButton_MouseEnter);
                btn.MouseLeave += new System.EventHandler(this.NavButton_MouseLeave);
            }

            // Custom name mappings matching your precise labels[cite: 8]
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);

            this.btnCriminals.Text = "Criminals";
            this.btnCriminals.Click += new System.EventHandler(this.btnCriminals_Click);

            this.btnCrimes.Text = "Crimes";
            this.btnCrimes.Click += new System.EventHandler(this.btnCrimes_Click);

            this.btnAssign.Text = "Investigators";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);

            this.btnCloseCase.Text = "Close Case";
            this.btnCloseCase.Click += new System.EventHandler(this.btnCloseCase_Click);

            this.btnMyCase.Text = "My Cases";
            this.btnMyCase.Click += new System.EventHandler(this.btnMyCase_Click);

            // -----------------------------------------------------------------
            // 🚨 btnLogout
            // -----------------------------------------------------------------
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 1;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 40, 40);
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 42);
            this.btnLogout.Text = "logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.btnLogout.MouseEnter += new System.EventHandler(this.Logout_MouseEnter);
            this.btnLogout.MouseLeave += new System.EventHandler(this.Logout_MouseLeave);

            // -----------------------------------------------------------------
            // 🖥️ pnlWorkspace
            // -----------------------------------------------------------------
            this.pnlWorkspace.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.pnlWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkspace.Name = "pnlWorkspace";

            // -----------------------------------------------------------------
            // frmMainShell Form Level Setup Configurations
            // -----------------------------------------------------------------
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlWorkspace);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmMainShell";
            this.Text = "Command Console - Core Investigative Infrastructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNav.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCriminals;
        private System.Windows.Forms.Button btnCrimes;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnCloseCase;
        private System.Windows.Forms.Button btnMyCase;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlWorkspace;
    }
}