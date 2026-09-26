using _2ndSemProject.Core_OOP_Layer;
using _2ndSemProject.Data_Access_Layer;
using System;
using System.Windows.Forms;

namespace _2ndSemProject
{
    public partial class frmRegisterCriminal : Form
    {
        private readonly CriminalRepository _criminalRepo = new CriminalRepository();

        public frmRegisterCriminal()
        {
            InitializeComponent();
            cmbStatus.SelectedIndex = 0; // Default status flag selection
        }

        private void btnSave_Click(object sender, EventArgs e) //
        {
            string cleanName = txtName.Text.Trim(); //
            string cleanCNIC = txtCNIC.Text.Trim(); //

            // 1. Mandatory Parameter Check
            if (string.IsNullOrEmpty(cleanName) || string.IsNullOrEmpty(cleanCNIC)) //
            {
                MessageBox.Show("Criminal Name and CNIC identification number are mandatory parameters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); //
                return; //
            }

            // 2. Strict Pakistani CNIC Formatting Check (Exactly 13 digits, no spaces, no dashes)
            // Uses simple character verification loop to maintain performance without complex overhead
            if (cleanCNIC.Length != 13 || !System.Text.RegularExpressions.Regex.IsMatch(cleanCNIC, "^[0-9]+$"))
            {
                MessageBox.Show("Invalid CNIC Entry! The national identity code must be exactly 13 digits long and contain numerical digits only (no spaces or dashes).",
                                "Input Validation Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Instantiate OOP Model Entity
                Criminal newCriminal = new Criminal(
                    0, //
                    cleanName, //
                    cleanCNIC, //
                    (int)numAge.Value, //
                    rbMale.Checked ? "Male" : "Female", //
                    cmbStatus.SelectedItem.ToString(), //
                    string.IsNullOrEmpty(txtPhotoPath.Text.Trim()) ? "default.jpg" : txtPhotoPath.Text.Trim(), //
                    txtHistory.Text.Trim() //
                );

                // 4. Execute Data Access Layer Transaction
                bool success = _criminalRepo.RegisterCriminal(newCriminal); //

                if (success) //
                {
                    MessageBox.Show("Criminal profile successfully synchronized and recorded in the repository database index.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                    this.DialogResult = DialogResult.OK; //
                    this.Close(); //
                }
            }
            catch (Exception ex) //
            {
                MessageBox.Show("Data translation breakdown: " + ex.Message, "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}