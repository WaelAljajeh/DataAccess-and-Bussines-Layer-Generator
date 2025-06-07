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
    public partial class frmSettiings : Form
    {
        DataTable _dtDataBases;
        public frmSettiings()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
        void LoadDataBasesToComboBox()
        {
            
             _dtDataBases = clsDataBasesLogic.GetAllDataBases();
            if (_dtDataBases == null)
            {

                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            guna2ComboBox1.DataSource=_dtDataBases;

                guna2ComboBox1.DisplayMember = "name";
                guna2ComboBox1.ValueMember = "database_id";
            
        }
        private void frmSettiings_Load(object sender, EventArgs e)
        {
            clsSettings.SetConnectionString();
            LoadDataBasesToComboBox();


        }
        void AddTablesToListBox()
        {
            DataTable TablesList = clsTableLogic.GetAllTheTables();
            foreach(DataRow row in TablesList.Rows)
            {
                string TableName=row["TABLE_NAME"].ToString();
                chkTableList.Items.Add(TableName);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkTableList.Items.Clear();
            //dgvTables.Columns.Clear();
            clsSettings.DBName =guna2ComboBox1.Text;
            clsSettings.SetConnectionString();
            //DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn
            //{
            //    Name = "chkSelect",
            //    HeaderText = "Select",
            //    DataPropertyName = "IsSelected",  // Binds to TableModel.IsSelected
            //    Width = 60,
            //    FlatStyle = FlatStyle.Standard
            //};
            //dgvTables.Columns.Add(chkColumn);
            //dgvTables.Visible= true;
            //dgvTables.DataSource = clsTableLogic.GetAllTheTables();
            AddTablesToListBox();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            foreach (var item in chkTableList.CheckedItems)
            {
                ;
                clsDataAccessGenerate.GenerateMethodOperation(item.ToString());
            }
            clsDataAccessGenerate.GenerateDataAccessSetting();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i< chkTableList.Items.Count;i++)
            {
               chkTableList.SetItemChecked(i, chkSelectAll.Checked);
            }
        }
    }
}
