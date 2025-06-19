namespace DataAccessLayer_Generator
{
    partial class frmChooseOperations
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
            this.chkGetColList = new System.Windows.Forms.CheckedListBox();
            this.chkOperationList = new System.Windows.Forms.CheckedListBox();
            this.llAddCustomMethod = new System.Windows.Forms.LinkLabel();
            this.cbMethodType = new System.Windows.Forms.ComboBox();
            this.btnAddCustomMethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkGetColList
            // 
            this.chkGetColList.FormattingEnabled = true;
            this.chkGetColList.Location = new System.Drawing.Point(15, 183);
            this.chkGetColList.Name = "chkGetColList";
            this.chkGetColList.Size = new System.Drawing.Size(202, 42);
            this.chkGetColList.TabIndex = 1;
            this.chkGetColList.Visible = false;
            this.chkGetColList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkGetColList_ItemCheck);
            this.chkGetColList.SelectedIndexChanged += new System.EventHandler(this.chkGetColList_SelectedIndexChanged);
            // 
            // chkOperationList
            // 
            this.chkOperationList.FormattingEnabled = true;
            this.chkOperationList.Items.AddRange(new object[] {
            "Add",
            "Update",
            "Delete",
            "GetBy"});
            this.chkOperationList.Location = new System.Drawing.Point(-1, 12);
            this.chkOperationList.Name = "chkOperationList";
            this.chkOperationList.Size = new System.Drawing.Size(392, 308);
            this.chkOperationList.TabIndex = 0;
            this.chkOperationList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkOperationList_ItemCheck);
            this.chkOperationList.SelectedIndexChanged += new System.EventHandler(this.chkOperationList_SelectedIndexChanged);
            // 
            // llAddCustomMethod
            // 
            this.llAddCustomMethod.AutoSize = true;
            this.llAddCustomMethod.Location = new System.Drawing.Point(12, 103);
            this.llAddCustomMethod.Name = "llAddCustomMethod";
            this.llAddCustomMethod.Size = new System.Drawing.Size(148, 17);
            this.llAddCustomMethod.TabIndex = 2;
            this.llAddCustomMethod.TabStop = true;
            this.llAddCustomMethod.Text = "+ Add Custom Method";
            this.llAddCustomMethod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddCustomMethod_LinkClicked);
            // 
            // cbMethodType
            // 
            this.cbMethodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethodType.FormattingEnabled = true;
            this.cbMethodType.Items.AddRange(new object[] {
            "GetBy",
            "DeleteBy",
            "IsExistingBy"});
            this.cbMethodType.Location = new System.Drawing.Point(15, 137);
            this.cbMethodType.Name = "cbMethodType";
            this.cbMethodType.Size = new System.Drawing.Size(202, 24);
            this.cbMethodType.TabIndex = 3;
            this.cbMethodType.Visible = false;
            this.cbMethodType.SelectedIndexChanged += new System.EventHandler(this.cbMethodType_SelectedIndexChanged);
            // 
            // btnAddCustomMethod
            // 
            this.btnAddCustomMethod.Location = new System.Drawing.Point(15, 248);
            this.btnAddCustomMethod.Name = "btnAddCustomMethod";
            this.btnAddCustomMethod.Size = new System.Drawing.Size(202, 23);
            this.btnAddCustomMethod.TabIndex = 4;
            this.btnAddCustomMethod.Text = "Add This Function To The List";
            this.btnAddCustomMethod.UseVisualStyleBackColor = true;
            this.btnAddCustomMethod.Visible = false;
            this.btnAddCustomMethod.Click += new System.EventHandler(this.btnAddCustomMethod_Click);
            // 
            // frmChooseOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 372);
            this.Controls.Add(this.btnAddCustomMethod);
            this.Controls.Add(this.cbMethodType);
            this.Controls.Add(this.llAddCustomMethod);
            this.Controls.Add(this.chkGetColList);
            this.Controls.Add(this.chkOperationList);
            this.Name = "frmChooseOperations";
            this.Text = "frmChooseOperations";
            this.Load += new System.EventHandler(this.frmChooseOperations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox chkGetColList;
        private System.Windows.Forms.CheckedListBox chkOperationList;
        private System.Windows.Forms.LinkLabel llAddCustomMethod;
        private System.Windows.Forms.ComboBox cbMethodType;
        private System.Windows.Forms.Button btnAddCustomMethod;
    }
}