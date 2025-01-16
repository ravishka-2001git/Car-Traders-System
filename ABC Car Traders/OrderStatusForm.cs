using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class OrderStatusForm : Form
    {
        private string loggedInUsername;

        public OrderStatusForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            SetUserNameLabel();
            LoadOrders();
        }

        private void SetUserNameLabel()
        {
            lblUserName.Text = "Name:  " + loggedInUsername;
        }

        private void LoadOrders()
        {
            ordersPanel.Controls.Clear(); // Clear existing controls

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                string query = @"
                    SELECT O.OrderID, O.Orders, O.TotalPrice, O.CustomerName, O.CustomerPhone, O.O_Status
                    FROM Orders O
                    INNER JOIN Registration_Table R ON O.CustomerName = R.Full_Name
                    WHERE R.Username = @Username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", loggedInUsername);

                SqlDataReader reader = cmd.ExecuteReader();

                int yPos = 10;

                while (reader.Read())
                {
                    // Extract necessary data from the reader
                    string orderID = reader["OrderID"].ToString();
                    string orderItems = reader["Orders"].ToString();
                    string customerName = reader["CustomerName"].ToString();
                    string customerPhone = reader["CustomerPhone"].ToString();
                    string totalPrice = reader["TotalPrice"].ToString();
                    string orderStatus = reader["O_Status"].ToString(); // Store the status here

                    // Create a panel for each order
                    Panel orderPanel = new Panel
                    {
                        Width = ordersPanel.Width - 40,
                        Height = 120,
                        Top = yPos,
                        Left = 10,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.FromArgb(155, Color.Black),
                        ForeColor = Color.White
                    };

                    PictureBox statusImage = new PictureBox
                    {
                        Width = 150,
                        Height = 100,
                        Top = 10,
                        Left = 10,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    // Set the image for the PictureBox
                    statusImage.Image = Properties.Resources.Partspic;

                    // Add the PictureBox to the panel
                    orderPanel.Controls.Add(statusImage);

                    // Order ID
                    Label lblOrderID = new Label
                    {
                        Text = "Order ID: " + orderID,
                        Top = 10,
                        Left = 180,
                        Width = 200,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        BackColor = Color.Transparent
                    };
                    orderPanel.Controls.Add(lblOrderID);

                    // Order Items
                    Label lblOrderItems = new Label
                    {
                        Text = "Items: " + orderItems,
                        Top = 40,
                        Left = 180,
                        Width = 400,
                        Font = new Font("Arial", 10),
                        BackColor = Color.Transparent,
                        ForeColor = Color.White
                    };
                    orderPanel.Controls.Add(lblOrderItems);

                    // Order Owner Name
                    Label lblOwnerName = new Label
                    {
                        Text = "Name: " + customerName,
                        Top = 65,
                        Left = 180,
                        Width = 300,
                        Font = new Font("Arial", 10),
                        ForeColor = Color.White,
                        BackColor = Color.Transparent
                    };
                    orderPanel.Controls.Add(lblOwnerName);

                    // Contact Number
                    Label lblContactNumber = new Label
                    {
                        Text = "Contact: " + customerPhone,
                        Top = 90,
                        Left = 180,
                        Width = 400,
                        Font = new Font("Arial", 10),
                        BackColor = Color.Transparent
                    };
                    orderPanel.Controls.Add(lblContactNumber);

                    // Total Price
                    Label lblTotalPrice = new Label
                    {
                        Text = "Total Price: RS. " + totalPrice,
                        Top = 40,
                        Left = 690,
                        Width = 300,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        BackColor = Color.Transparent
                    };
                    orderPanel.Controls.Add(lblTotalPrice);

                    // Track Button
                    Button btnTrack = new Button
                    {
                        Text = "Track",
                        Top = 80,
                        Left = 720,
                        Width = 100,
                        Font = new Font("Arial", 10)
                    };

                    // Attach the order status to the button as a Tag
                    btnTrack.Tag = orderStatus;

                    btnTrack.Click += (s, e) =>
                    {
                        // Retrieve the order status from the button's Tag
                        string O_status = (string)((Button)s).Tag;
                        MessageBox.Show("Tracking order: " + O_status);
                    };

                    orderPanel.Controls.Add(btnTrack);

                    ordersPanel.Controls.Add(orderPanel);

                    yPos += 130; // Adjust yPos for the next panel
                }

            }
        }
    }
}
