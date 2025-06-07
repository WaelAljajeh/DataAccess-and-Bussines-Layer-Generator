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
            this.grpOperation = new System.Windows.Forms.GroupBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.chkFind = new System.Windows.Forms.CheckBox();
            this.chkList = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.grpOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOperation
            // 
            this.grpOperation.Controls.Add(this.chkUpdate);
            this.grpOperation.Controls.Add(this.chkList);
            this.grpOperation.Controls.Add(this.chkFind);
            this.grpOperation.Controls.Add(this.chkAdd);
            this.grpOperation.Location = new System.Drawing.Point(3, 1);
            this.grpOperation.Name = "grpOperation";
            this.grpOperation.Size = new System.Drawing.Size(421, 316);
            this.grpOperation.TabIndex = 0;
            this.grpOperation.TabStop = false;
            this.grpOperation.Text = "Operation";
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(9, 38);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(54, 21);
            this.chkAdd.TabIndex = 0;
            this.chkAdd.Text = "Add";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // chkFind
            // 
            this.chkFind.AutoSize = true;
            this.chkFind.Location = new System.Drawing.Point(9, 95);
            this.chkFind.Name = "chkFind";
            this.chkFind.Size = new System.Drawing.Size(55, 21);
            this.chkFind.TabIndex = 1;
            this.chkFind.Text = "Find";
            this.chkFind.UseVisualStyleBackColor = true;
            // 
            // chkList
            // 
            this.chkList.AutoSize = true;
            this.chkList.Location = new System.Drawing.Point(9, 148);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(50, 21);
            this.chkList.TabIndex = 2;
            this.chkList.Text = "List";
            this.chkList.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(9, 213);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(74, 21);
            this.chkUpdate.TabIndex = 3;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // frmChooseOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 372);
            this.Controls.Add(this.grpOperation);
            this.Name = "frmChooseOperations";
            this.Text = "frmChooseOperations";
            this.grpOperation.ResumeLayout(false);
            this.grpOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOperation;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkList;
        private System.Windows.Forms.CheckBox chkFind;
        private System.Windows.Forms.CheckBox chkAdd;
    }
}