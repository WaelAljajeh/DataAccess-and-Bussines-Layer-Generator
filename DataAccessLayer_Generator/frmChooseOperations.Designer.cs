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
            this.SuspendLayout();
            // 
            // chkGetColList
            // 
            this.chkGetColList.FormattingEnabled = true;
            this.chkGetColList.Location = new System.Drawing.Point(102, 75);
            this.chkGetColList.Name = "chkGetColList";
            this.chkGetColList.Size = new System.Drawing.Size(150, 42);
            this.chkGetColList.TabIndex = 1;
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
            this.chkOperationList.SelectedIndexChanged += new System.EventHandler(this.chkOperationList_SelectedIndexChanged);
            // 
            // frmChooseOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 372);
            this.Controls.Add(this.chkGetColList);
            this.Controls.Add(this.chkOperationList);
            this.Name = "frmChooseOperations";
            this.Text = "frmChooseOperations";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox chkGetColList;
        private System.Windows.Forms.CheckedListBox chkOperationList;
    }
}