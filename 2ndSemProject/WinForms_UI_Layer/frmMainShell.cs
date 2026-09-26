using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmMainShell : Form
    {
        private int _userID;
        private string _userName;
        private string _role;
        private bool _isLoggingOut = false;

        public frmMainShell(int userID, string userName, string role)
        {
            InitializeComponent();
            _userID = userID;
            _userName = userName;
            _role = role;

            lblWelcome.Text = "Welcome, " + userName;
            lblRole.Text = "Role: " + role;

            ApplyRoleBasedAccess();

            // Dynamic header layout calculation for perfect scaling
            int paddingRight = 40;
            lblWelcome.Left = pnlHeader.Width - lblWelcome.Width - paddingRight;
            lblRole.Left = pnlHeader.Width - lblRole.Width - paddingRight;

            lblWelcome.BringToFront();
            lblRole.BringToFront();

            // =====================================================================
            // ✅ UNDONE: ROLE-SPECIFIC AUTO-MOUNT AT STARTUP RESTORED
            // =====================================================================
            if (_role == "Admin")
            {
                LoadUserControl(new ucAdminDashboard());
            }
            else if (_role == "Investigator")
            {
                _2ndSemProject.Data_Access_Layer.InvestigatorRepository invRepo = new _2ndSemProject.Data_Access_Layer.InvestigatorRepository();
                int realInvestigatorID = invRepo.GetInvestigatorIDByUserID(this._userID);

                if (realInvestigatorID != -1)
                {
                    LoadUserControl(new ucInvestigatorDashboard(realInvestigatorID));
                }
            }
        }

        private void ApplyRoleBasedAccess()
        {
            if (_role == "Admin")
            {
                btnDashboard.Visible = true;
                btnCriminals.Visible = true;
                btnCrimes.Visible = true;
                btnAssign.Visible = true;

                // 🛑 REMOVED FROM SIDEBAR: Turn visibility off to hide the button completely
                btnCloseCase.Visible = false;
                btnMyCase.Visible = false;

                // Hardcoded layouts matching your perfect alignments
                btnDashboard.Location = new System.Drawing.Point(0, 25);
                btnCriminals.Location = new System.Drawing.Point(0, 77);
                btnCrimes.Location = new System.Drawing.Point(0, 129);
                btnAssign.Location = new System.Drawing.Point(0, 181);

                // ✅ SHIFTED UP: Moves the red logout frame up into the old Close Case slot smoothly!
                btnLogout.Location = new System.Drawing.Point(15, 238);
            }
            else if (_role == "Investigator")
            {
                btnDashboard.Visible = true;
                btnCriminals.Visible = true;
                btnCrimes.Visible = true;
                btnAssign.Visible = false;
                btnCloseCase.Visible = false;
                btnMyCase.Visible = true;

                // Hardcoded clean tight alignments for Investigator view
                btnDashboard.Location = new System.Drawing.Point(0, 25);
                btnCriminals.Location = new System.Drawing.Point(0, 77);
                btnCrimes.Location = new System.Drawing.Point(0, 129);
                btnMyCase.Location = new System.Drawing.Point(0, 181);

                btnLogout.Location = new System.Drawing.Point(15, 245);
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlWorkspace.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlWorkspace.Controls.Add(uc);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // =====================================================================
            // ✅ UNDONE: ROLE-SPECIFIC ROUTING ON CLICK RESTORED
            // =====================================================================
            if (_role == "Admin")
            {
                LoadUserControl(new ucAdminDashboard());
            }
            else if (_role == "Investigator")
            {
                _2ndSemProject.Data_Access_Layer.InvestigatorRepository invRepo = new _2ndSemProject.Data_Access_Layer.InvestigatorRepository();
                int realInvestigatorID = invRepo.GetInvestigatorIDByUserID(this._userID);

                if (realInvestigatorID != -1)
                {
                    LoadUserControl(new ucInvestigatorDashboard(realInvestigatorID));
                }
                else
                {
                    MessageBox.Show("Operational Error: Your user login account is not linked to an active Investigator profile.",
                                    "Mapping Profile Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCriminals_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucCriminals());
        }

        private void btnCrimes_Click(object sender, EventArgs e)
        {
            if (_role == "Investigator")
            {
                // Translate the login token to capture their matching personnel badge identity record reference
                _2ndSemProject.Data_Access_Layer.InvestigatorRepository invRepo = new _2ndSemProject.Data_Access_Layer.InvestigatorRepository();
                int realInvestigatorID = invRepo.GetInvestigatorIDByUserID(this._userID);

                // Load the Crimes control pre-loaded with their unique staff ID parameter trace
                LoadUserControl(new ucCrimes(realInvestigatorID));
            }
            else
            {
                // Admins load a standard unlinked view dashboard container control interface layout
                LoadUserControl(new ucCrimes());
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            // Reverted back to default: Mounts your original functional control panel!
            LoadUserControl(new ucInvestigators());
        }

        private void btnCloseCase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Case Closure coming soon!", "Info");
        }

        private void btnMyCase_Click(object sender, EventArgs e)
        {
            // 1. Instantiate the personnel repository to access the link bridge
            _2ndSemProject.Data_Access_Layer.InvestigatorRepository invRepo = new _2ndSemProject.Data_Access_Layer.InvestigatorRepository();

            // 2. Translate the authenticated UserID token into the actual employee ID
            int realInvestigatorID = invRepo.GetInvestigatorIDByUserID(this._userID);

            if (realInvestigatorID != -1)
            {
                // 3. Load the control using the true InvestigatorID so SQL filters rows perfectly!
                LoadUserControl(new ucMyCases(realInvestigatorID));
            }
            else
            {
                MessageBox.Show("Operational Error: Your user login account is not currently linked to an active Investigator profile record in the database.",
                                "Profile Mapping Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 1. Flip our master safety switch to bypass process termination hooks
                _isLoggingOut = true;

                // 2. Locate the hidden root login instance window
                frmLogin originalLoginForm = null;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is frmLogin loginInstance)
                    {
                        originalLoginForm = loginInstance;
                        break;
                    }
                }

                if (originalLoginForm != null)
                {
                    // 3. PROFESSIONAL CLEANUP: Flush field buffers before showing the form
                    if (originalLoginForm.Controls.Find("txtUsername", true).Length > 0)
                        ((TextBox)originalLoginForm.Controls.Find("txtUsername", true)[0]).Clear();

                    if (originalLoginForm.Controls.Find("txtPassword", true).Length > 0)
                        ((TextBox)originalLoginForm.Controls.Find("txtPassword", true)[0]).Clear();

                    if (originalLoginForm.Controls.Find("lblError", true).Length > 0)
                        ((Label)originalLoginForm.Controls.Find("lblError", true)[0]).Text = "";

                    // 4. Bring the clean login window back to life
                    originalLoginForm.Show();

                    // 5. Close this shell instance completely to wipe active state records
                    this.Close();
                }
                else
                {
                    // Absolute thread fallback safeguard loop
                    frmLogin freshLogin = new frmLogin();
                    freshLogin.Show();
                    this.Close();
                }
            }
        }

        // =====================================================================
        // HOVER EFFECTS - ENHANCED VISUAL GLOW MAPPED TO THEME CONTRASTS
        // =====================================================================
        private void ResetAllNavButtonStyles()
        {
            // ✅ CLEANED: Removed btnCloseCase from the array since it's no longer part of active sidebar operations
            Button[] navButtons = { btnDashboard, btnCriminals, btnCrimes, btnAssign, btnMyCase };

            foreach (Button btn in navButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
                btn.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            }
        }

        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            // 1. Instantly wipe out any stuck highlights across the sidebar
            ResetAllNavButtonStyles();

            // 2. Light up only the single button the user is pointing at
            Button activeBtn = (Button)sender;
            activeBtn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); // Neon Electric Blue text
            activeBtn.BackColor = System.Drawing.Color.FromArgb(38, 38, 52);  // High-contrast slate fill
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            // When the mouse leaves the button zone entirely, snap the whole sidebar back to default
            ResetAllNavButtonStyles();
        }

        private void Logout_MouseEnter(object sender, EventArgs e)
        {
            // Clear nav button states so they don't fight for focus
            ResetAllNavButtonStyles();

            btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 40, 40); // Solid Crimson fill
            btnLogout.ForeColor = System.Drawing.Color.White;
        }

        private void Logout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);  // Revert container backdrop
            btnLogout.ForeColor = System.Drawing.Color.FromArgb(220, 40, 40); // Revert line color stroke
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // If they are logging out intentionally, allow the form window to close safely
            if (_isLoggingOut)
            {
                return;
            }

            // Otherwise, they hit the native Windows title bar Close "X" button. Kill the active background process stack!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        // =====================================================================
        public void SwitchToControl(UserControl uc)
        {
            pnlWorkspace.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlWorkspace.Controls.Add(uc);
        }
    }
}