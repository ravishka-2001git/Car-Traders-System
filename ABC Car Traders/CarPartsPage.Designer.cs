namespace ABC_Car_Traders
{
    partial class CarPartsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarPartsPage));
            this.label1 = new System.Windows.Forms.Label();
            this.CarParts_dataGrid = new System.Windows.Forms.DataGridView();
            this.textSearch_CarParts = new System.Windows.Forms.TextBox();
            this.btn_CarParts_Search = new System.Windows.Forms.Button();
            this.btn_CarParts_Add = new System.Windows.Forms.Button();
            this.btn_CarParts_Delete = new System.Windows.Forms.Button();
            this.btn_CarParts_Update = new System.Windows.Forms.Button();
            this.btn_CarParts_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CarParts_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Car Parts Page";
            // 
            // CarParts_dataGrid
            // 
            this.CarParts_dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CarParts_dataGrid.BackgroundColor = System.Drawing.Color.Black;
            this.CarParts_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarParts_dataGrid.Location = new System.Drawing.Point(12, 73);
            this.CarParts_dataGrid.Name = "CarParts_dataGrid";
            this.CarParts_dataGrid.RowHeadersWidth = 51;
            this.CarParts_dataGrid.RowTemplate.Height = 24;
            this.CarParts_dataGrid.Size = new System.Drawing.Size(1298, 482);
            this.CarParts_dataGrid.TabIndex = 2;
            // 
            // textSearch_CarParts
            // 
            this.textSearch_CarParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch_CarParts.Location = new System.Drawing.Point(951, 38);
            this.textSearch_CarParts.Name = "textSearch_CarParts";
            this.textSearch_CarParts.Size = new System.Drawing.Size(225, 27);
            this.textSearch_CarParts.TabIndex = 13;
            // 
            // btn_CarParts_Search
            // 
            this.btn_CarParts_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CarParts_Search.BackColor = System.Drawing.Color.Transparent;
            this.btn_CarParts_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CarParts_Search.BackgroundImage")));
            this.btn_CarParts_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CarParts_Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CarParts_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CarParts_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CarParts_Search.Location = new System.Drawing.Point(1182, 27);
            this.btn_CarParts_Search.Name = "btn_CarParts_Search";
            this.btn_CarParts_Search.Size = new System.Drawing.Size(48, 40);
            this.btn_CarParts_Search.TabIndex = 12;
            this.btn_CarParts_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CarParts_Search.UseVisualStyleBackColor = false;
            this.btn_CarParts_Search.Click += new System.EventHandler(this.btn_CarParts_Search_Click);
            // 
            // btn_CarParts_Add
            // 
            this.btn_CarParts_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CarParts_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_CarParts_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CarParts_Add.Location = new System.Drawing.Point(30, 576);
            this.btn_CarParts_Add.Name = "btn_CarParts_Add";
            this.btn_CarParts_Add.Size = new System.Drawing.Size(108, 52);
            this.btn_CarParts_Add.TabIndex = 19;
            this.btn_CarParts_Add.Text = "Add New";
            this.btn_CarParts_Add.UseVisualStyleBackColor = false;
            this.btn_CarParts_Add.Click += new System.EventHandler(this.btn_CarParts_Add_Click);
            // 
            // btn_CarParts_Delete
            // 
            this.btn_CarParts_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CarParts_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_CarParts_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CarParts_Delete.BackgroundImage")));
            this.btn_CarParts_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CarParts_Delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_CarParts_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CarParts_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CarParts_Delete.ForeColor = System.Drawing.Color.Red;
            this.btn_CarParts_Delete.Location = new System.Drawing.Point(311, 579);
            this.btn_CarParts_Delete.Name = "btn_CarParts_Delete";
            this.btn_CarParts_Delete.Size = new System.Drawing.Size(56, 49);
            this.btn_CarParts_Delete.TabIndex = 18;
            this.btn_CarParts_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CarParts_Delete.UseVisualStyleBackColor = false;
            this.btn_CarParts_Delete.Click += new System.EventHandler(this.btn_CarParts_Delete_Click);
            // 
            // btn_CarParts_Update
            // 
            this.btn_CarParts_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CarParts_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_CarParts_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CarParts_Update.Location = new System.Drawing.Point(168, 576);
            this.btn_CarParts_Update.Name = "btn_CarParts_Update";
            this.btn_CarParts_Update.Size = new System.Drawing.Size(108, 52);
            this.btn_CarParts_Update.TabIndex = 17;
            this.btn_CarParts_Update.Text = "Update";
            this.btn_CarParts_Update.UseVisualStyleBackColor = false;
            this.btn_CarParts_Update.Click += new System.EventHandler(this.btn_CarParts_Update_Click);
            // 
            // btn_CarParts_Refresh
            // 
            this.btn_CarParts_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CarParts_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_CarParts_Refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CarParts_Refresh.BackgroundImage")));
            this.btn_CarParts_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CarParts_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CarParts_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CarParts_Refresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_CarParts_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CarParts_Refresh.Location = new System.Drawing.Point(1236, 27);
            this.btn_CarParts_Refresh.Name = "btn_CarParts_Refresh";
            this.btn_CarParts_Refresh.Size = new System.Drawing.Size(42, 37);
            this.btn_CarParts_Refresh.TabIndex = 16;
            this.btn_CarParts_Refresh.UseVisualStyleBackColor = false;
            this.btn_CarParts_Refresh.Click += new System.EventHandler(this.btn_CarParts_Refresh_Click);
            // 
            // CarPartsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ABC_Car_Traders.Properties.Resources._360_F_571834789_ujYbUnH190iUokdDhZq7GXeTBRgqYVwa;
            this.ClientSize = new System.Drawing.Size(1322, 649);
            this.ControlBox = false;
            this.Controls.Add(this.btn_CarParts_Add);
            this.Controls.Add(this.btn_CarParts_Delete);
            this.Controls.Add(this.btn_CarParts_Update);
            this.Controls.Add(this.btn_CarParts_Refresh);
            this.Controls.Add(this.textSearch_CarParts);
            this.Controls.Add(this.btn_CarParts_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarParts_dataGrid);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CarPartsPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CarPartsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarParts_dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CarParts_dataGrid;
        private System.Windows.Forms.TextBox textSearch_CarParts;
        private System.Windows.Forms.Button btn_CarParts_Search;
        private System.Windows.Forms.Button btn_CarParts_Add;
        private System.Windows.Forms.Button btn_CarParts_Delete;
        private System.Windows.Forms.Button btn_CarParts_Update;
        private System.Windows.Forms.Button btn_CarParts_Refresh;
    }
}