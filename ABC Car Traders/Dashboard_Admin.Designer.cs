namespace ABC_Car_Traders
{
    partial class Dashboard_Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard_Admin));
            this.DashboardPanle1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Back_DA = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Order_Report = new System.Windows.Forms.Button();
            this.btn_Order_Admin = new System.Windows.Forms.Button();
            this.CustomersBtn = new System.Windows.Forms.Button();
            this.CarPartsBtn = new System.Windows.Forms.Button();
            this.CarsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DashboardPanle1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Back_DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DashboardPanle1
            // 
            this.DashboardPanle1.BackColor = System.Drawing.Color.Black;
            this.DashboardPanle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DashboardPanle1.BackgroundImage")));
            this.DashboardPanle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DashboardPanle1.Controls.Add(this.label1);
            this.DashboardPanle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DashboardPanle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DashboardPanle1.Location = new System.Drawing.Point(0, 137);
            this.DashboardPanle1.Name = "DashboardPanle1";
            this.DashboardPanle1.Size = new System.Drawing.Size(1332, 696);
            this.DashboardPanle1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.BackgroundImage = global::ABC_Car_Traders.Properties.Resources._360_F_571834789_ujYbUnH190iUokdDhZq7GXeTBRgqYVwa;
            this.panel1.Controls.Add(this.btn_Back_DA);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_Order_Report);
            this.panel1.Controls.Add(this.btn_Order_Admin);
            this.panel1.Controls.Add(this.CustomersBtn);
            this.panel1.Controls.Add(this.CarPartsBtn);
            this.panel1.Controls.Add(this.CarsBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 137);
            this.panel1.TabIndex = 1;
            // 
            // btn_Back_DA
            // 
            this.btn_Back_DA.BackColor = System.Drawing.Color.Transparent;
            this.btn_Back_DA.Image = ((System.Drawing.Image)(resources.GetObject("btn_Back_DA.Image")));
            this.btn_Back_DA.Location = new System.Drawing.Point(32, 39);
            this.btn_Back_DA.Name = "btn_Back_DA";
            this.btn_Back_DA.Size = new System.Drawing.Size(122, 60);
            this.btn_Back_DA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Back_DA.TabIndex = 61;
            this.btn_Back_DA.TabStop = false;
            this.btn_Back_DA.Click += new System.EventHandler(this.btn_Back_DA_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1104, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Order_Report
            // 
            this.btn_Order_Report.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Order_Report.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Order_Report.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Order_Report.Location = new System.Drawing.Point(948, 39);
            this.btn_Order_Report.Name = "btn_Order_Report";
            this.btn_Order_Report.Size = new System.Drawing.Size(122, 49);
            this.btn_Order_Report.TabIndex = 7;
            this.btn_Order_Report.Text = "REPORTS";
            this.btn_Order_Report.UseVisualStyleBackColor = false;
            this.btn_Order_Report.Click += new System.EventHandler(this.btn_Order_Report_Click);
            // 
            // btn_Order_Admin
            // 
            this.btn_Order_Admin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Order_Admin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Order_Admin.Location = new System.Drawing.Point(793, 39);
            this.btn_Order_Admin.Name = "btn_Order_Admin";
            this.btn_Order_Admin.Size = new System.Drawing.Size(124, 49);
            this.btn_Order_Admin.TabIndex = 6;
            this.btn_Order_Admin.Text = "ORDERS";
            this.btn_Order_Admin.UseVisualStyleBackColor = true;
            this.btn_Order_Admin.Click += new System.EventHandler(this.btn_Order_Admin_Click);
            // 
            // CustomersBtn
            // 
            this.CustomersBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CustomersBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomersBtn.Location = new System.Drawing.Point(603, 39);
            this.CustomersBtn.Name = "CustomersBtn";
            this.CustomersBtn.Size = new System.Drawing.Size(156, 49);
            this.CustomersBtn.TabIndex = 5;
            this.CustomersBtn.Text = "CUSTOMERS";
            this.CustomersBtn.UseVisualStyleBackColor = true;
            this.CustomersBtn.Click += new System.EventHandler(this.CustomersBtn_Click);
            // 
            // CarPartsBtn
            // 
            this.CarPartsBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CarPartsBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarPartsBtn.Location = new System.Drawing.Point(418, 39);
            this.CarPartsBtn.Name = "CarPartsBtn";
            this.CarPartsBtn.Size = new System.Drawing.Size(154, 49);
            this.CarPartsBtn.TabIndex = 4;
            this.CarPartsBtn.Text = "CAR PARTS";
            this.CarPartsBtn.UseVisualStyleBackColor = true;
            this.CarPartsBtn.Click += new System.EventHandler(this.CarPartsBtn_Click);
            // 
            // CarsBtn
            // 
            this.CarsBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CarsBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarsBtn.Location = new System.Drawing.Point(263, 39);
            this.CarsBtn.Name = "CarsBtn";
            this.CarsBtn.Size = new System.Drawing.Size(125, 49);
            this.CarsBtn.TabIndex = 3;
            this.CarsBtn.Text = "CARS";
            this.CarsBtn.UseVisualStyleBackColor = true;
            this.CarsBtn.Click += new System.EventHandler(this.CarsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(378, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 134);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome ";
            // 
            // Dashboard_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 833);
            this.Controls.Add(this.DashboardPanle1);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard_Admin";
            this.DashboardPanle1.ResumeLayout(false);
            this.DashboardPanle1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Back_DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CarsBtn;
        private System.Windows.Forms.Panel DashboardPanle1;
        private System.Windows.Forms.Button btn_Order_Admin;
        private System.Windows.Forms.Button CustomersBtn;
        private System.Windows.Forms.Button CarPartsBtn;
        private System.Windows.Forms.Button btn_Order_Report;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btn_Back_DA;
        private System.Windows.Forms.Label label1;
    }
}