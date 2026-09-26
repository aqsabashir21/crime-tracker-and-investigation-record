using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class ucWelcomeHub : UserControl
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
        private readonly string _currentUserName;
        private readonly string _currentUserRole;

        private readonly Color COLOR_PANEL_BG = Color.FromArgb(22, 22, 32);
        private readonly Color COLOR_BG_DARK = Color.FromArgb(14, 14, 20);
        private readonly Color COLOR_ACCENT_BLUE = Color.FromArgb(0, 150, 255);
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(140, 140, 160);

        public ucWelcomeHub(string userName, string role)
        {
            InitializeComponent();
            this._currentUserName = userName;
            this._currentUserRole = role;
            this.BackColor = COLOR_BG_DARK;
            this.Dock = DockStyle.Fill;
            this.Load += ucWelcomeHub_Load;
        }

        private void ucWelcomeHub_Load(object sender, EventArgs e)
        {
            BuildHubUI();
        }

        private void BuildHubUI()
        {
            this.Controls.Clear();

            // Fetch global counts
            DataTable dt = _dbHelper.GetGlobalHubMetrics();
            string staffCount = "0";
            string criminalCount = "0";
            string crimeCount = "0";

            if (dt != null && dt.Rows.Count > 0)
            {
                staffCount = dt.Rows[0]["TotalStaff"].ToString();
                criminalCount = dt.Rows[0]["TotalCriminals"].ToString();
                crimeCount = dt.Rows[0]["TotalCrimes"].ToString();
            }

            // 1. WELCOME BANNER CARD
            Panel pnlBanner = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(840, 110),
                BackColor = COLOR_PANEL_BG
            };

            Panel blueStrip = new Panel { Size = new Size(4, 110), Location = new Point(0, 0), BackColor = COLOR_ACCENT_BLUE };
            pnlBanner.Controls.Add(blueStrip);

            Label lblGreeting = new Label
            {
                Text = $"WELCOME TO CORE COMMAND, {_currentUserName.ToUpper()}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 25),
                Size = new Size(700, 35)
            };

            Label lblSubGreeting = new Label
            {
                Text = $"Clearance Level: Active System Security Matrix // Assigned Node Role: {_currentUserRole}",
                Font = new Font("Consolas", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 180, 100),
                Location = new Point(20, 65),
                Size = new Size(700, 20)
            };
            pnlBanner.Controls.Add(lblGreeting);
            pnlBanner.Controls.Add(lblSubGreeting);
            this.Controls.Add(pnlBanner);

            // 2. GLOBAL METRIC CARDS
            this.Controls.Add(CreateMetricCard("TOTAL SYSTEM CRIMES", crimeCount, COLOR_ACCENT_BLUE, 20, 150));
            this.Controls.Add(CreateMetricCard("TRACKED CRIMINAL PROFILES", criminalCount, Color.FromArgb(254, 194, 0), 240, 150));
            this.Controls.Add(CreateMetricCard("ACTIVE PERSONNEL NODES", staffCount, Color.FromArgb(0, 200, 100), 460, 150));

            // 3. SYSTEM PROTOCOLS BULLETIN BOARD
            Panel pnlInstructions = new Panel
            {
                Location = new Point(20, 275),
                Size = new Size(840, 185),
                BackColor = COLOR_PANEL_BG,
                Padding = new Padding(20)
            };

            Label lblInstTitle = new Label
            {
                Text = "STANDARD OPERATIONAL SECURITY PROTOCOLS",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = COLOR_ACCENT_BLUE,
                Location = new Point(20, 15),
                Size = new Size(500, 20)
            };

            Label lblGuidelines = new Label
            {
                Text = "1. DATA INTEGRITY: Ensure all criminal data mapping points have verified record inputs.\n" +
                       "2. SESSION POLICY: Always click the designated manual logout link before terminating application execution.\n" +
                       "3. SECURE TERMINAL: Unauthorized credentials mapping shifts are instantly flagged in the central audit logs.\n" +
                       "4. SYSTEM MAINTENANCE: Database connections auto-sync on local ports via encrypted SSL channels.",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(180, 185, 200),
                Location = new Point(20, 45),
                Size = new Size(800, 110),
                //LineSpacing = 8 // Adds professional spacing
            };

            pnlInstructions.Controls.Add(lblInstTitle);
            pnlInstructions.Controls.Add(lblGuidelines);
            this.Controls.Add(pnlInstructions);
        }

        private Panel CreateMetricCard(string title, string value, Color accentColor, int x, int y)
        {
            Panel card = new Panel { Size = new Size(200, 100), Location = new Point(x, y), BackColor = COLOR_PANEL_BG };
            Panel accentStrip = new Panel { Size = new Size(200, 4), Location = new Point(0, 0), BackColor = accentColor };
            card.Controls.Add(accentStrip);

            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = COLOR_TEXT_MUTED, Location = new Point(15, 18), Size = new Size(170, 20) };
            Label lblValue = new Label { Text = value, Font = new Font("Segoe UI", 26, FontStyle.Bold), ForeColor = Color.White, Location = new Point(12, 38), Size = new Size(170, 45) };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            return card;
        }
    }
}