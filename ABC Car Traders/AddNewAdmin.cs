using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class AddNewAdmin : Form
    {
        public AddNewAdmin()
        {
            InitializeComponent();
        }

        // Function to clear all textboxes
        private void ClearFields()
        {
            txtFullNameAD.Clear();
            textUserNameAD.Clear();
            txtPhoneNumAD.Clear();
            txtAddressAD.Clear();
            txtUemailAD.Clear();
            txtPasswordAD.Clear();
            txtCpasswordAD.Clear();
            cBox_RoleAD.Items.Clear();
        }

        private void cBox_RoleAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assuming you have added a ComboBox named 'cBox_Role'
            cBox_RoleAD.Items.Add("User");
            cBox_RoleAD.Items.Add("Admin");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPasswordAD.UseSystemPasswordChar = false;
                txtCpasswordAD.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordAD.UseSystemPasswordChar = true;
                txtCpasswordAD.UseSystemPasswordChar = true;
            }
        }

        private void btn_SaveSignUpAD_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(txtFullNameAD.Text) ||
                string.IsNullOrWhiteSpace(textUserNameAD.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumAD.Text) ||
                string.IsNullOrWhiteSpace(txtAddressAD.Text) ||
                string.IsNullOrWhiteSpace(txtUemailAD.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordAD.Text) ||
                string.IsNullOrWhiteSpace(txtCpasswordAD.Text) ||
                string.IsNullOrWhiteSpace(cBox_RoleAD.Text))
            {
                // Show a message box if any field is empty
                MessageBox.Show("Please fill in the blank box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Check if passwords match
            if (txtPasswordAD.Text != txtCpasswordAD.Text)
            {
                // Show a message box if passwords do not match
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }

            // Check if the password is at least 8 characters long
            if (txtPasswordAD.Text.Length < 8)
            {
                // Show a message box if the password is too short
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }
            // Check if role is selected
            if (string.IsNullOrWhiteSpace(cBox_RoleAD.Text))
            {
                MessageBox.Show("Please select a role", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If all validations pass, proceed with saving to the database

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            String InsertQuery = "INSERT INTO Registration_Table VALUES (@Full_Name,@Username,@Phone_Number,@Address,@Email,@Password,@Confirm_Password,@AdminOrUser)";
            SqlCommand cmd = new SqlCommand(InsertQuery, con);
            cmd.Parameters.AddWithValue("@Full_Name", txtFullNameAD.Text);
            cmd.Parameters.AddWithValue("@Username", textUserNameAD.Text);
            cmd.Parameters.AddWithValue("@Phone_Number", txtPhoneNumAD.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddressAD.Text);
            cmd.Parameters.AddWithValue("@Email", txtUemailAD.Text);
            cmd.Parameters.AddWithValue("@Password", txtPasswordAD.Text);
            cmd.Parameters.AddWithValue("@Confirm_Password", txtCpasswordAD.Text);
            cmd.Parameters.AddWithValue("@AdminOrUser", cBox_RoleAD.Text);
            cmd.ExecuteNonQuery();

            // Show a success message after saving to the database
            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally, clear the fields after successful registration
            ClearFields();

            con.Close();
        }
    }
}
