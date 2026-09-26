using System;
using System.Data;
using System.Windows.Forms;
using _2ndSemProject.Data_Access_Layer; //[cite: 35]
using _2ndSemProject.Core_OOP_Layer; //[cite: 35]

namespace _2ndSemProject
{
    public partial class ucMyCases : UserControl //[cite: 35]
    {
        private readonly InvestigatorRepository _investigatorRepo = new InvestigatorRepository(); //[cite: 35]
        private readonly CrimeRepository _crimeRepo = new CrimeRepository(); //[cite: 35]
        private readonly int _currentInvestigatorID; //[cite: 35]
        private string PromptForDropdownInput(string text, string caption, string[] options)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.FromArgb(18, 18, 24), // Matches obsidian canvas
                ForeColor = System.Drawing.Color.White
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = text, Font = new System.Drawing.Font("Segoe UI", 9F) }; //

            // Create and style the ComboBox control drop-down matrix
            ComboBox comboBox = new ComboBox()
            {
                Left = 20,
                Top = 50,
                Width = 344,
                DropDownStyle = ComboBoxStyle.DropDownList, // Prevents typing custom text strings
                BackColor = System.Drawing.Color.FromArgb(28, 28, 38), // Slate card interior
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Load the string array data entries into the ComboBox container items collection
            comboBox.Items.AddRange(options);
            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = 0; // Default selection to top index item

            Button confirmation = new Button() { Text = "Submit", Left = 214, Width = 150, Top = 90, Height = 30, DialogResult = DialogResult.OK, FlatStyle = FlatStyle.Flat }; //
            confirmation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255); // Neon blue glow stroke
            confirmation.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); //

            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation; //

            return prompt.ShowDialog() == DialogResult.OK ? comboBox.SelectedItem.ToString() : "";
        }

        public ucMyCases(int investigatorID) //[cite: 35]
        {
            InitializeComponent(); //[cite: 35]
            this._currentInvestigatorID = investigatorID; //[cite: 35]
            LoadAssignedCases(); //[cite: 35]
        }

        // =====================================================================
        // 🔥 NATIVE C# INPUT PROMPT BOX (Bypasses VisualBasic Dependency)
        // =====================================================================
        private string PromptForInput(string text, string caption, string defaultResult = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.FromArgb(18, 18, 24),
                ForeColor = System.Drawing.Color.White
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = text, Font = new System.Drawing.Font("Segoe UI", 9F) };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 344, Text = defaultResult, BackColor = System.Drawing.Color.FromArgb(28, 28, 38), ForeColor = System.Drawing.Color.White, BorderStyle = BorderStyle.FixedSingle };

            Button confirmation = new Button() { Text = "Submit", Left = 214, Width = 150, Top = 90, Height = 30, DialogResult = DialogResult.OK, FlatStyle = FlatStyle.Flat };
            confirmation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 255);
            confirmation.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void LoadAssignedCases() //[cite: 35]
        {
            try
            {
                DataTable dt = _investigatorRepo.GetAssignedCases(_currentInvestigatorID); //[cite: 35]
                dgvMyCases.DataSource = dt; //[cite: 35]
            }
            catch (Exception ex) //[cite: 35]
            {
                MessageBox.Show("Error loading assigned cases: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //[cite: 35]
            }
        }

        private int GetSelectedCrimeID() //[cite: 35]
        {
            if (dgvMyCases.SelectedRows.Count > 0) //[cite: 35]
            {
                try
                {
                    return Convert.ToInt32(dgvMyCases.SelectedRows[0].Cells["CrimeID"].Value); //[cite: 35]
                }
                catch
                {
                    return Convert.ToInt32(dgvMyCases.SelectedRows[0].Cells[0].Value);
                }
            }
            return -1; //[cite: 35]
        }

        private void btnViewCaseDetails_Click(object sender, EventArgs e) //[cite: 35]
        {
            int crimeID = GetSelectedCrimeID(); //[cite: 35]
            if (crimeID == -1) //[cite: 35]
            {
                MessageBox.Show("Please select an active case file from the roster grid first.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); //[cite: 35]
                return; //[cite: 35]
            }

            string title = dgvMyCases.SelectedRows[0].Cells["Title"].Value.ToString(); //[cite: 35]
            string type = dgvMyCases.SelectedRows[0].Cells["Type"].Value.ToString(); //[cite: 35]
            string location = dgvMyCases.SelectedRows[0].Cells["Location"].Value.ToString(); //[cite: 35]
            string status = dgvMyCases.SelectedRows[0].Cells["Status"].Value.ToString(); //[cite: 35]

            string dossier = "--- CASE EXPLORER DOSSIER ---\n\n" + //[cite: 35]
                             "Case Reference ID: " + crimeID + "\n" + //[cite: 35]
                             "Incident Classification Title: " + title + "\n" + //[cite: 35]
                             "Crime Type: " + type + "\n" + //[cite: 35]
                             "Primary Scene Location: " + location + "\n" + //[cite: 35]
                             "Current Field Status: " + status; //[cite: 35]

            MessageBox.Show(dossier, "Dossier Explorer View", MessageBoxButtons.OK, MessageBoxIcon.Information); //[cite: 35]
        }

        private void btnLogProgress_Click(object sender, EventArgs e) //[cite: 35]
        {
            int crimeID = GetSelectedCrimeID(); //[cite: 35]
            if (crimeID == -1) //[cite: 35]
            {
                MessageBox.Show("Select a case file first.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); //[cite: 35]
                return; //[cite: 35]
            }

            // Using our fresh native C# prompt text engine instead of VisualBasic strings!
            string fieldNotes = PromptForInput(
                "Enter narrative progress update summary for Case File #" + crimeID + ":",
                "Append Operational Field Log Entry",
                "Investigator field inspection complete."
            );

            if (string.IsNullOrEmpty(fieldNotes.Trim())) return;

            CaseLog newLog = new CaseLog(); //[cite: 35]
            newLog.SetCrimeID(crimeID); //[cite: 35]
            newLog.SetUpdateTxt(fieldNotes.Trim()); //[cite: 35]

            bool success = _crimeRepo.AddCaseLog(newLog); //[cite: 35]
            if (success) //[cite: 35]
            {
                MessageBox.Show("Progress entry successfully synchronized with case timeline.", "Diary Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information); //[cite: 35]
                btnViewTimeline_Click(this, EventArgs.Empty);
            }
        }

        private void btnManageEvidence_Click(object sender, EventArgs e)
        {
            int crimeID = GetSelectedCrimeID(); //
            if (crimeID == -1) //
            {
                MessageBox.Show("Select a case file first.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); //
                return; //
            }

            // 🔄 FIXED: Array of predefined professional forensic evidence classifications
            string[] evidenceOptions = {
                "Digital Trace / CCTV",
                "Forensic DNA/Blood",
                "Ballistics/Weapon",
                "Fingerprint Signature",
                "Documentary Evidence",
                "Narcotics/Contraband"
            };

            // 🔄 CALLS THE DROPDOWN PROMPT: Forces selection instead of raw text entry
            string evidenceType = PromptForDropdownInput(
                "Select forensic item classification type for Case File #" + crimeID + ":",
                "Forensic Locker Classification Station",
                evidenceOptions
            );

            // Safe exit loop if the investigator cancels the operation
            if (string.IsNullOrEmpty(evidenceType)) return;

            // Keeps the standard prompt box for the description logs
            string evidenceDesc = PromptForInput(
                "Enter complete physical descriptor registry log strings for this evidence trace:",
                "Forensic Identity Vault Registry",
                "Recovered electronic surveillance storage block profile string."
            ); //

            if (string.IsNullOrEmpty(evidenceDesc.Trim())) return; //

            Evidence newEvidence = new Evidence(); //
            newEvidence.SetCrimeID(crimeID); //
            newEvidence.SetEvidenceType(evidenceType); //
            newEvidence.SetDescription(evidenceDesc.Trim()); //

            bool success = _crimeRepo.AddEvidence(newEvidence); //
            if (success) //
            {
                MessageBox.Show("Forensic evidence block securely committed to locker manifest repository.", "Evidence Secured", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                btnViewCaseAssets_Click(this, EventArgs.Empty); //
            }
        }

        private void btnViewTimeline_Click(object sender, EventArgs e) //[cite: 35]
        {
            int crimeID = GetSelectedCrimeID(); //[cite: 35]
            if (crimeID == -1) //[cite: 35]
            {
                MessageBox.Show("Select a case file first.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); //[cite: 35]
                return; //[cite: 35]
            }

            DataTable dtLogs = _crimeRepo.GetCaseLogs(crimeID); //[cite: 35]
            dgvSecondaryDetail.DataSource = dtLogs; //[cite: 35]
            lblDetailSectionTitle.Text = "📜 CHRONOLOGICAL CASE TIMELINE LOGS (CASE #" + crimeID + ")"; //[cite: 35]
        }

        private void btnViewCaseAssets_Click(object sender, EventArgs e) //[cite: 35]
        {
            int crimeID = GetSelectedCrimeID(); //[cite: 35]
            if (crimeID == -1) //[cite: 35]
            {
                MessageBox.Show("Select a case file first.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); //[cite: 35]
                return; //[cite: 35]
            }

            DataTable dtEvidence = _crimeRepo.GetCrimeWithEvidence(crimeID); //[cite: 35]
            dgvSecondaryDetail.DataSource = dtEvidence; //[cite: 35]
            lblDetailSectionTitle.Text = "🧬 SECURED EVIDENCE repo MANIFEST (CASE #" + crimeID + ")"; //[cite: 35]
        }

        // =====================================================================
        // 🔥 FIXED: Event handlers match the designer code-behind names verbatim
        // =====================================================================
        public void ActionButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //[cite: 35]
            btn.BackColor = System.Drawing.Color.FromArgb(0, 150, 255); //[cite: 35]
            btn.ForeColor = System.Drawing.Color.FromArgb(18, 18, 24); //[cite: 35]
        }

        public void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //[cite: 35]
            btn.BackColor = System.Drawing.Color.FromArgb(28, 28, 38); //[cite: 35]
            btn.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255); //[cite: 35]
        }
    }
}