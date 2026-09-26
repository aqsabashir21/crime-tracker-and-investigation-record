using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using _2ndSemProject.Data_Access_Layer;

namespace _2ndSemProject
{
    public partial class ucInvestigatorDashboard : UserControl
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
        private readonly int _investigatorID;

        private readonly Color COLOR_PANEL_BG = Color.FromArgb(22, 22, 32);
        private readonly Color COLOR_BG_DARK = Color.FromArgb(14, 14, 20);
        private readonly Color COLOR_ACCENT_BLUE = Color.FromArgb(0, 150, 255);
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(140, 140, 160);

        // Constructor accepting the translated live Investigator ID token
        public ucInvestigatorDashboard(int investigatorID)
        {
            InitializeComponent();
            this._investigatorID = investigatorID;
            this.BackColor = COLOR_BG_DARK;
            this.Dock = DockStyle.Fill;
            this.Load += ucInvestigatorDashboard_Load;
        }

        private void ucInvestigatorDashboard_Load(object sender, EventArgs e)
        {
            BuildDashboardUI();
        }

        private void BuildDashboardUI()
        {
            this.Controls.Clear();

            // Fetch metrics from our Data Access Layer pass filtering by ID
            DataTable metricsTable = _dbHelper.GetInvestigatorDashboardMetrics(_investigatorID);
            string myActiveCases = "0";
            string unassignedCases = "0";
            string myClosedCases = "0";

            if (metricsTable != null && metricsTable.Rows.Count > 0)
            {
                myActiveCases = metricsTable.Rows[0]["MyActiveCases"].ToString();
                unassignedCases = metricsTable.Rows[0]["UnassignedCases"].ToString();
                myClosedCases = metricsTable.Rows[0]["MyClosedCases"].ToString();
            }

            // 1. HEADER TITLE
            Label lblTitle = new Label
            {
                Text = "FIELD OPERATIONS DASHBOARD",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                Size = new Size(400, 30)
            };
            this.Controls.Add(lblTitle);

            // 2. COUNTER METRIC CARDS
            this.Controls.Add(CreateMetricCard("MY ACTIVE INVESTIGATIONS", myActiveCases, COLOR_ACCENT_BLUE, 20, 70));
            this.Controls.Add(CreateMetricCard("UNASSIGNED INCIDENTS", unassignedCases, Color.FromArgb(254, 194, 0), 240, 70));
            this.Controls.Add(CreateMetricCard("CASES RESOLVED / CLOSED", myClosedCases, Color.FromArgb(0, 200, 100), 460, 70));

            // 3. PERSONAL CASE WORKLIST CONTAINER
            Panel pnlWorklistContainer = new Panel
            {
                Location = new Point(20, 200),
                Size = new Size(840, 260),
                BackColor = COLOR_PANEL_BG,
                Padding = new Padding(15)
            };

            Label lblListHeading = new Label
            {
                Text = "MY ACTIVE CASE ATTRIBUTION LEDGER",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = COLOR_ACCENT_BLUE,
                Location = new Point(15, 15),
                Size = new Size(400, 20)
            };
            pnlWorklistContainer.Controls.Add(lblListHeading);

            DataGridView dgvMyWork = new DataGridView
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
            dgvMyWork.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 45);
            dgvMyWork.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMyWork.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvMyWork.DefaultCellStyle.BackColor = COLOR_BG_DARK;
            dgvMyWork.DefaultCellStyle.SelectionBackColor = COLOR_ACCENT_BLUE;

            try
            {
                // ✅ FIXED: Using your true database columns and filtering by the logged-in investigator!
                DataTable activeCasesData = _dbHelper.ExecuteQuery($@"
                    SELECT CrimeID, Title, Type, DateReported, Location, Status, Description 
                    FROM Crimes 
                    WHERE InvestigatorID = {_investigatorID} AND (Status = 'Open' OR Status = 'Active')");

                if (activeCasesData != null) dgvMyWork.DataSource = activeCasesData;
            }
            catch { /* Protection handler */ }

            pnlWorklistContainer.Controls.Add(dgvMyWork);
            this.Controls.Add(pnlWorklistContainer);
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