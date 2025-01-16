using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ABC_Car_Traders
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btn_SaveSignUp_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(textUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNum.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtUemail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtCpassword.Text))
            {
                // Show a message box if any field is empty
                MessageBox.Show("Please fill in the blank box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Check if passwords match
            if (txtPassword.Text != txtCpassword.Text)
            {
                // Show a message box if passwords do not match
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }

            // Check if the password is at least 8 characters long
            if (txtPassword.Text.Length < 8)
            {
                // Show a message box if the password is too short
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }

            // If all validations pass, proceed with saving to the database

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                // Modified SQL INSERT query to include "User" for AdminOrUser column
                String InsertQuery = "INSERT INTO Registration_Table (Full_Name, Username, Phone_Number, Address, Email, Password, Confirm_Password, AdminOrUser) " +
                                     "VALUES (@Full_Name, @Username, @Phone_Number, @Address, @Email, @Password, @Confirm_Password, 'User')";

                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Full_Name", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Username", textUserName.Text);
                    cmd.Parameters.AddWithValue("@Phone_Number", txtPhoneNum.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Email", txtUemail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Confirm_Password", txtCpassword.Text);

                    cmd.ExecuteNonQuery();
                }

                // Show a success message after saving to the database
                MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, clear the fields after successful registration
                ClearFields();
            }
        }


        // Function to clear all textboxes
        private void ClearFields()
        {
            txtFullName.Clear();
            textUserName.Clear();
            txtPhoneNum.Clear();
            txtAddress.Clear();
            txtUemail.Clear();
            txtPassword.Clear();
            txtCpassword.Clear();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtCpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtCpassword.UseSystemPasswordChar = true;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginpage obj = new Loginpage();
            obj.Show();
        }

    }
}
