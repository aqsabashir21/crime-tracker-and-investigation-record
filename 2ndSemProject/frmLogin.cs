using System;
using System.Data;
using System.Windows.Forms;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class frmLogin : Form
    {
        private readonly AuthRepository _authRepo = new AuthRepository();
        private Timer liveClockTimer;

        public frmLogin()
        {
            InitializeComponent();
            InitializeLiveClock();
        }

        private void InitializeLiveClock()
        {
            // Syncs the terminal clock display box to update down to the exact second
            lblLiveTime.Text = "TIMESTAMP: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            liveClockTimer = new Timer { Interval = 1000 };
            liveClockTimer.Tick += (s, e) => {
                lblLiveTime.Text = "TIMESTAMP: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            liveClockTimer.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                lblError.Text = "System Access Denied:\nPlease fill out all authentication credentials fields.";
                return;
            }

            DataRow user = _authRepo.Login(username, password);

            if (user == null)
            {
                lblError.Text = "Security Error: Invalid username or security signature.";
                return;
            }

            int userID = Convert.ToInt32(user["UserID"]);
            string userName = user["Username"].ToString();
            string role = user["Role"].ToString();

            Console.WriteLine("Role detected: " + role);

            frmMainShell mainShell = new frmMainShell(userID, userName, role);
            mainShell.Show();
            this.Hide();
        }

        // =====================================================================
        // 🔄 PROFESSIONAL LOGOUT RESET ROUTINE
        // =====================================================================
        public void ClearCredentialsForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblError.Text = "";
        }

        // =====================================================================
        // ✨ INTERACTIVE NEON GLOW EFFECTS
        // =====================================================================
        private void BtnNeon_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(0, 150, 255); // Solid glow neon fill
            btn.ForeColor = System.Drawing.Color.FromArgb(14, 14, 20);   // Dark ink contrast text
        }

        private void BtnNeon_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(14, 14, 20);   // Drop back to card background
            btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);   // Revert back to cyan edge stroke
        }
    }
}