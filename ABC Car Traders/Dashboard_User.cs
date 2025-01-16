using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class Dashboard_User : Form
    {
        private UserOrderPage orderPage;
        private User_CarPage carPage;
        private CarPartsPage_User carPartsPage;
        private OrderStatusForm orderStatusForm;
        private string fullName;
        private string username; // Declare username

        // Updated constructor to accept fullName and username
        public Dashboard_User(string fullName, string username)
        {
            InitializeComponent();
            this.fullName = fullName;
            this.username = username; // Initialize username
            SetWelcomeMessage();
        }

        // Public property to access the DashboardUser panel
        public Panel DashboardUserPanel
        {
            get { return DashboardUser; }
        }

        private void SetWelcomeMessage()
        {
            lblWelcome.Text = fullName;
        }

        private void CarsBtn_User_Click(object sender, EventArgs e)
        {
            if (carPage == null)
            {
                carPage = new User_CarPage(orderPage); // Pass the orderPage to maintain state
                carPage.TopLevel = false;
                carPage.FormBorderStyle = FormBorderStyle.None;
                carPage.Dock = DockStyle.Fill;
                DashboardUserPanel.Controls.Add(carPage);
            }
            carPage.BringToFront();
            carPage.Show();
        }

        private void CarPartsBtn_User_Click(object sender, EventArgs e)
        {
            if (carPartsPage == null)
            {
                carPartsPage = new CarPartsPage_User(orderPage);
                carPartsPage.TopLevel = false;
                carPartsPage.FormBorderStyle = FormBorderStyle.None;
                carPartsPage.Dock = DockStyle.Fill;
                DashboardUserPanel.Controls.Add(carPartsPage);
            }
            carPartsPage.BringToFront();
            carPartsPage.Show();
        }

        private void BtnOrders_User_Click(object sender, EventArgs e)
        {
            if (orderPage == null)
            {
                orderPage = new UserOrderPage(); // No username needed here
                orderPage.TopLevel = false;
                orderPage.FormBorderStyle = FormBorderStyle.None;
                orderPage.Dock = DockStyle.Fill;
                DashboardUserPanel.Controls.Add(orderPage);
            }
            orderPage.BringToFront();
            orderPage.Show();
        }
        

        private void btn_Back_DUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginpage loginPage = new Loginpage();
            loginPage.Show();
        }

        private void BtnSatsus__User_Click(object sender, EventArgs e)
        {
            if (orderStatusForm == null)
            {
                orderStatusForm = new OrderStatusForm(username); // Pass username to OrderStatusForm
                orderStatusForm.TopLevel = false;
                orderStatusForm.FormBorderStyle = FormBorderStyle.None;
                orderStatusForm.Dock = DockStyle.Fill;
                DashboardUserPanel.Controls.Add(orderStatusForm);
            }
            orderStatusForm.BringToFront();
            orderStatusForm.Show();
        }
    }
}
