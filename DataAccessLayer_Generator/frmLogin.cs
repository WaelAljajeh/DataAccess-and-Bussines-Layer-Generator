using Guna.UI2.WinForms;
using LogicLayerDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer_Generator
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //txtUsername.Validating += IsNotNulltext;
            //txtPassword.Validating += IsNotNulltext;
            btnNext.CausesValidation = true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!IsValidInputs())
            {
                MessageBox.Show("Please fix the highlighted fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            clsSettings.DBUserName = txtUsername.Text;
            clsSettings.DBPassword = txtPassword.Text;
      
                frmSettiings frmSettiings = new frmSettiings();
                frmSettiings.ShowDialog();
            
           
        }

        private bool IsValidInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Username cannot be empty");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password cannot be empty");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

            return isValid;
        }


       
        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnNext.Focus();
        }
    }
}
