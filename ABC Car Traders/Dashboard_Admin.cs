using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class Dashboard_Admin : Form
    {
        public Dashboard_Admin()
        {
            InitializeComponent();
        }

        private void CarsBtn_Click(object sender, EventArgs e)
        {
            CarPage C = new CarPage();
            C.TopLevel = false;
            DashboardPanle1.Controls.Add(C);
            C.BringToFront();
            C.Show();
        }

        private void CarPartsBtn_Click(object sender, EventArgs e)
        {
            CarPartsPage CP = new CarPartsPage();
            CP.TopLevel = false;
            DashboardPanle1.Controls.Add(CP);
            CP.BringToFront();
            CP.Show();
        }

        private void CustomersBtn_Click(object sender, EventArgs e)
        {
            Customers S = new Customers();
            S.TopLevel = false;
            DashboardPanle1.Controls.Add(S);
            S.BringToFront();
            S.Show();
        }

        private void btn_Back_DA_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginpage obj = new Loginpage();
            obj.Show();
        }

        private void btn_Order_Admin_Click(object sender, EventArgs e)
        {
            OrderPage_Admin O = new OrderPage_Admin();
            O.TopLevel = false;
            DashboardPanle1.Controls.Add(O);
            O.BringToFront();
            O.Show();
        }

        private void btn_Order_Report_Click(object sender, EventArgs e)
        {
            ReportPage R = new ReportPage();
            R.TopLevel = false;
            DashboardPanle1.Controls.Add(R);
            R.BringToFront();
            R.Show();
        }
    }
}
