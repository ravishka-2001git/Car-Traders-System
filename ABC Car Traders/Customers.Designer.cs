namespace ABC_Car_Traders
{
    partial class Customers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers));
            this.label1 = new System.Windows.Forms.Label();
            this.CustomersData = new System.Windows.Forms.DataGridView();
            this.btn_Cust_Search = new System.Windows.Forms.Button();
            this.btn_Cust_Refresh = new System.Windows.Forms.Button();
            this.btn_Cust_Update = new System.Windows.Forms.Button();
            this.btn_Cust_Delete = new System.Windows.Forms.Button();
            this.textSearch_Cust = new System.Windows.Forms.TextBox();
            this.btn_newAdmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customers";
            // 
            // CustomersData
            // 
            this.CustomersData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomersData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomersData.BackgroundColor = System.Drawing.Color.Black;
            this.CustomersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersData.GridColor = System.Drawing.Color.DarkGreen;
            this.CustomersData.Location = new System.Drawing.Point(12, 75);
            this.CustomersData.Name = "CustomersData";
            this.CustomersData.RowHeadersWidth = 51;
            this.CustomersData.RowTemplate.Height = 24;
            this.CustomersData.Size = new System.Drawing.Size(1298, 467);
            this.CustomersData.TabIndex = 2;
            this.CustomersData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomersData_CellContentClick);
            // 
            // btn_Cust_Search
            // 
            this.btn_Cust_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cust_Search.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cust_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cust_Search.BackgroundImage")));
            this.btn_Cust_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Cust_Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cust_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cust_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cust_Search.Location = new System.Drawing.Point(1182, 27);
            this.btn_Cust_Search.Name = "btn_Cust_Search";
            this.btn_Cust_Search.Size = new System.Drawing.Size(48, 40);
            this.btn_Cust_Search.TabIndex = 4;
            this.btn_Cust_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cust_Search.UseVisualStyleBackColor = false;
            this.btn_Cust_Search.Click += new System.EventHandler(this.btn_Cust_Search_Click);
            // 
            // btn_Cust_Refresh
            // 
            this.btn_Cust_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cust_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cust_Refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cust_Refresh.BackgroundImage")));
            this.btn_Cust_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Cust_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cust_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cust_Refresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cust_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cust_Refresh.Location = new System.Drawing.Point(1236, 27);
            this.btn_Cust_Refresh.Name = "btn_Cust_Refresh";
            this.btn_Cust_Refresh.Size = new System.Drawing.Size(42, 37);
            this.btn_Cust_Refresh.TabIndex = 5;
            this.btn_Cust_Refresh.UseVisualStyleBackColor = false;
            this.btn_Cust_Refresh.Click += new System.EventHandler(this.btn_Cust_Refresh_Click);
            // 
            // btn_Cust_Update
            // 
            this.btn_Cust_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cust_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cust_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cust_Update.Location = new System.Drawing.Point(59, 562);
            this.btn_Cust_Update.Name = "btn_Cust_Update";
            this.btn_Cust_Update.Size = new System.Drawing.Size(108, 52);
            this.btn_Cust_Update.TabIndex = 6;
            this.btn_Cust_Update.Text = "Update";
            this.btn_Cust_Update.UseVisualStyleBackColor = false;
            this.btn_Cust_Update.Click += new System.EventHandler(this.btn_Cust_Update_Click);
            // 
            // btn_Cust_Delete
            // 
            this.btn_Cust_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cust_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cust_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cust_Delete.BackgroundImage")));
            this.btn_Cust_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Cust_Delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cust_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cust_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cust_Delete.ForeColor = System.Drawing.Color.Red;
            this.btn_Cust_Delete.Location = new System.Drawing.Point(323, 562);
            this.btn_Cust_Delete.Name = "btn_Cust_Delete";
            this.btn_Cust_Delete.Size = new System.Drawing.Size(56, 52);
            this.btn_Cust_Delete.TabIndex = 7;
            this.btn_Cust_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Cust_Delete.UseVisualStyleBackColor = false;
            this.btn_Cust_Delete.Click += new System.EventHandler(this.btn_Cust_Delete_Click);
            // 
            // textSearch_Cust
            // 
            this.textSearch_Cust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch_Cust.Location = new System.Drawing.Point(951, 38);
            this.textSearch_Cust.Name = "textSearch_Cust";
            this.textSearch_Cust.Size = new System.Drawing.Size(225, 27);
            this.textSearch_Cust.TabIndex = 9;
            // 
            // btn_newAdmin
            // 
            this.btn_newAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_newAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btn_newAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newAdmin.Location = new System.Drawing.Point(185, 562);
            this.btn_newAdmin.Name = "btn_newAdmin";
            this.btn_newAdmin.Size = new System.Drawing.Size(121, 52);
            this.btn_newAdmin.TabIndex = 10;
            this.btn_newAdmin.Text = "New Admin";
            this.btn_newAdmin.UseVisualStyleBackColor = false;
            this.btn_newAdmin.Click += new System.EventHandler(this.btn_newAdmin_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ABC_Car_Traders.Properties.Resources._360_F_571834789_ujYbUnH190iUokdDhZq7GXeTBRgqYVwa;
            this.ClientSize = new System.Drawing.Size(1322, 649);
            this.ControlBox = false;
            this.Controls.Add(this.btn_newAdmin);
            this.Controls.Add(this.textSearch_Cust);
            this.Controls.Add(this.btn_Cust_Delete);
            this.Controls.Add(this.btn_Cust_Update);
            this.Controls.Add(this.btn_Cust_Refresh);
            this.Controls.Add(this.btn_Cust_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomersData);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Customers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CustomersData;
        private System.Windows.Forms.Button btn_Cust_Search;
        private System.Windows.Forms.Button btn_Cust_Refresh;
        private System.Windows.Forms.Button btn_Cust_Update;
        private System.Windows.Forms.TextBox textSearch_Cust;
        private System.Windows.Forms.Button btn_Cust_Delete;
        private System.Windows.Forms.Button btn_newAdmin;
    }
}