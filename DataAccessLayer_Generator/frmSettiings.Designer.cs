namespace DataAccessLayer_Generator
{
    partial class frmSettiings
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectDataAccessPath = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.chkTableList = new System.Windows.Forms.CheckedListBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.btnSelectBussinesLayer = new Guna.UI2.WinForms.Guna2Button();
            this.chkBussinesLayer = new System.Windows.Forms.CheckBox();
            this.chkDataAccessLayer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.AutoRoundedCorners = true;
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 17;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(394, 32);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(725, 36);
            this.guna2ComboBox1.TabIndex = 0;
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnSelectDataAccessPath
            // 
            this.btnSelectDataAccessPath.Animated = true;
            this.btnSelectDataAccessPath.AutoRoundedCorners = true;
            this.btnSelectDataAccessPath.BorderRadius = 21;
            this.btnSelectDataAccessPath.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectDataAccessPath.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectDataAccessPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelectDataAccessPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelectDataAccessPath.FillColor = System.Drawing.Color.Black;
            this.btnSelectDataAccessPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectDataAccessPath.ForeColor = System.Drawing.Color.White;
            this.btnSelectDataAccessPath.Location = new System.Drawing.Point(-4, 631);
            this.btnSelectDataAccessPath.Name = "btnSelectDataAccessPath";
            this.btnSelectDataAccessPath.Size = new System.Drawing.Size(279, 45);
            this.btnSelectDataAccessPath.TabIndex = 1;
            this.btnSelectDataAccessPath.Text = "Select DataAccess_Location location";
            this.btnSelectDataAccessPath.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BorderRadius = 21;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Black;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(1277, 631);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(223, 45);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Text = "Next";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // chkTableList
            // 
            this.chkTableList.FormattingEnabled = true;
            this.chkTableList.Location = new System.Drawing.Point(394, 129);
            this.chkTableList.Name = "chkTableList";
            this.chkTableList.Size = new System.Drawing.Size(725, 137);
            this.chkTableList.TabIndex = 4;
            this.chkTableList.SelectedIndexChanged += new System.EventHandler(this.chkTableList_SelectedIndexChanged);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(394, 90);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(82, 21);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // dgvColumns
            // 
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Location = new System.Drawing.Point(195, 308);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowHeadersWidth = 51;
            this.dgvColumns.RowTemplate.Height = 26;
            this.dgvColumns.Size = new System.Drawing.Size(1086, 301);
            this.dgvColumns.TabIndex = 6;
            // 
            // btnSelectBussinesLayer
            // 
            this.btnSelectBussinesLayer.Animated = true;
            this.btnSelectBussinesLayer.AutoRoundedCorners = true;
            this.btnSelectBussinesLayer.BorderRadius = 21;
            this.btnSelectBussinesLayer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectBussinesLayer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectBussinesLayer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelectBussinesLayer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelectBussinesLayer.FillColor = System.Drawing.Color.Black;
            this.btnSelectBussinesLayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectBussinesLayer.ForeColor = System.Drawing.Color.White;
            this.btnSelectBussinesLayer.Location = new System.Drawing.Point(281, 631);
            this.btnSelectBussinesLayer.Name = "btnSelectBussinesLayer";
            this.btnSelectBussinesLayer.Size = new System.Drawing.Size(251, 45);
            this.btnSelectBussinesLayer.TabIndex = 7;
            this.btnSelectBussinesLayer.Text = "Select Bussines_Layer location";
            this.btnSelectBussinesLayer.Click += new System.EventHandler(this.btnSelectBussinesLayer_Click);
            // 
            // chkBussinesLayer
            // 
            this.chkBussinesLayer.AutoSize = true;
            this.chkBussinesLayer.Location = new System.Drawing.Point(12, 435);
            this.chkBussinesLayer.Name = "chkBussinesLayer";
            this.chkBussinesLayer.Size = new System.Drawing.Size(119, 21);
            this.chkBussinesLayer.TabIndex = 8;
            this.chkBussinesLayer.Text = "Bussines Layer";
            this.chkBussinesLayer.UseVisualStyleBackColor = true;
            this.chkBussinesLayer.CheckedChanged += new System.EventHandler(this.chkBussinesLayer_CheckedChanged);
            // 
            // chkDataAccessLayer
            // 
            this.chkDataAccessLayer.AutoSize = true;
            this.chkDataAccessLayer.Location = new System.Drawing.Point(12, 504);
            this.chkDataAccessLayer.Name = "chkDataAccessLayer";
            this.chkDataAccessLayer.Size = new System.Drawing.Size(142, 21);
            this.chkDataAccessLayer.TabIndex = 9;
            this.chkDataAccessLayer.Text = "Data Access Layer";
            this.chkDataAccessLayer.UseVisualStyleBackColor = true;
            this.chkDataAccessLayer.CheckedChanged += new System.EventHandler(this.chkDataAccessLayer_CheckedChanged);
            // 
            // frmSettiings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 688);
            this.Controls.Add(this.chkDataAccessLayer);
            this.Controls.Add(this.chkBussinesLayer);
            this.Controls.Add(this.btnSelectBussinesLayer);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.chkTableList);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.btnSelectDataAccessPath);
            this.Controls.Add(this.guna2ComboBox1);
            this.Name = "frmSettiings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettiings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2Button btnSelectDataAccessPath;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.CheckedListBox chkTableList;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dgvColumns;
        private Guna.UI2.WinForms.Guna2Button btnSelectBussinesLayer;
        private System.Windows.Forms.CheckBox chkBussinesLayer;
        private System.Windows.Forms.CheckBox chkDataAccessLayer;
    }
}