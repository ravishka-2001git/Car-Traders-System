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
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // SQL query to check the username and password, and retrieve the full name and role
                    string query = "SELECT Full_Name, Username, AdminOrUser FROM Registration_Table WHERE Username=@username AND Password=@password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUName.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the user's full name, username, and role
                                string fullName = reader["Full_Name"].ToString();
                                string username = reader["Username"].ToString(); // Retrieve the username
                                string role = reader["AdminOrUser"].ToString();

                                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();

                                // Redirect based on the role
                                if (role == "Admin")
                                {
                                    Dashboard_Admin adminDashboard = new Dashboard_Admin();
                                    adminDashboard.Show();
                                }
                                else if (role == "User")
                                {
                                    Dashboard_User userDashboard = new Dashboard_User(fullName, username); // Pass fullName and username to the Dashboard_User
                                    userDashboard.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void btnSingup_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage obj = new RegisterPage();
            obj.Show();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            from1 obj = new from1();
            obj.Show();
        }

        private void checkBox_Login_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Login.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;

            }
        }
    }
}
