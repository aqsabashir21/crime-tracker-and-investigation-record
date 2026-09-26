using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class ucAdminDashboard : UserControl
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        // High-Contrast Theme Colors
        private readonly Color COLOR_PANEL_BG = Color.FromArgb(22, 22, 32);
        private readonly Color COLOR_BG_DARK = Color.FromArgb(14, 14, 20);
        private readonly Color COLOR_ACCENT_BLUE = Color.FromArgb(0, 150, 255);
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(140, 140, 160);

        public ucAdminDashboard()
        {
            InitializeComponent();
            this.BackColor = COLOR_BG_DARK;
            this.Dock = DockStyle.Fill;
            this.Load += ucAdminDashboard_Load;
        }

        private void ucAdminDashboard_Load(object sender, EventArgs e)
        {
            BuildDashboardUI();
        }

        private void BuildDashboardUI()
        {
            this.Controls.Clear();

            // Fetch live metrics from our Data Access Layer
            DataTable metricsTable = _dbHelper.GetAdminDashboardMetrics();
            string totalInvestigators = "0";
            string totalCriminals = "0";
            string openCases = "0";
            string revokedTokens = "0";

            if (metricsTable != null && metricsTable.Rows.Count > 0)
            {
                totalInvestigators = metricsTable.Rows[0]["TotalInvestigators"].ToString();
                totalCriminals = metricsTable.Rows[0]["TotalCriminals"].ToString();
                openCases = metricsTable.Rows[0]["OpenCases"].ToString();
                revokedTokens = metricsTable.Rows[0]["RevokedTokens"].ToString();
            }

            // 1. HEADER TITLE
            Label lblTitle = new Label
            {
                Text = "SYSTEM MANAGER CONTROL TOWER",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                Size = new Size(400, 30)
            };
            this.Controls.Add(lblTitle);

            // 2. METRIC CARDS (OOP Row Counters)
            this.Controls.Add(CreateMetricCard("TOTAL PERSONNEL", totalInvestigators, COLOR_ACCENT_BLUE, 20, 70));
            this.Controls.Add(CreateMetricCard("MANAGED CRIMINAL RECORDS", totalCriminals, Color.FromArgb(254, 194, 0), 240, 70));
            this.Controls.Add(CreateMetricCard("ACTIVE INVESTIGATIONS", openCases, Color.FromArgb(0, 200, 100), 460, 70));
            this.Controls.Add(CreateMetricCard("REVOKED LOCK TOKENS", revokedTokens, Color.FromArgb(240, 60, 60), 680, 70));

            // 3. LIVE DATABASE LOGS PANEL (Wired directly to your data structures)
            Panel pnlLogsContainer = new Panel
            {
                Location = new Point(20, 200),
                Size = new Size(840, 260),
                BackColor = COLOR_PANEL_BG,
                Padding = new Padding(15)
            };

            Label lblLogHeading = new Label
            {
                Text = "RECENT DATABASE AUDIT LOG (LIVE READOUT)",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = COLOR_ACCENT_BLUE,
                Location = new Point(15, 15),
                Size = new Size(400, 20)
            };
            pnlLogsContainer.Controls.Add(lblLogHeading);

            // DataGridView showcasing your active tables live state
            DataGridView dgvAudit = new DataGridView
            {
                Location = new Point(15, 45),
                Size = new Size(810, 195),
                BackgroundColor = COLOR_BG_DARK,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                ReadOnly = true
            };
            dgvAudit.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 45);
            dgvAudit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAudit.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvAudit.DefaultCellStyle.BackColor = COLOR_BG_DARK;
            dgvAudit.DefaultCellStyle.SelectionBackColor = COLOR_ACCENT_BLUE;

            // Bind the grid to show the newest active users and cross-verify system visibility
            try
            {
                DataTable logData = _dbHelper.ExecuteQuery(@"
                    SELECT TOP 5 U.UserID, U.Username, U.Role, I.Name AS [Personnel Bound]
                    FROM Users U
                    INNER JOIN Investigators I ON U.UserID = I.UserID
                    ORDER BY U.UserID DESC;");

                if (logData != null) dgvAudit.DataSource = logData;
            }
            catch { /* Protection handler */ }

            pnlLogsContainer.Controls.Add(dgvAudit);
            this.Controls.Add(pnlLogsContainer);
        }

        private Panel CreateMetricCard(string title, string value, Color accentColor, int x, int y)
        {
            Panel card = new Panel
            {
                Size = new Size(200, 100),
                Location = new Point(x, y),
                BackColor = COLOR_PANEL_BG
            };

            // Little neon top border highlight strip
            Panel accentStrip = new Panel
            {
                Size = new Size(200, 4),
                Location = new Point(0, 0),
                BackColor = accentColor
            };
            card.Controls.Add(accentStrip);

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = COLOR_TEXT_MUTED,
                Location = new Point(15, 18),
                Size = new Size(170, 20)
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(12, 38),
                Size = new Size(170, 45)
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            return card;
        }
    }
}