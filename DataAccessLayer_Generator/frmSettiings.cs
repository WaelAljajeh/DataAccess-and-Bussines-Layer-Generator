using LogicLayerDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DataAccessLayer_Generator
{
    public partial class frmSettiings : Form
    {
        string MethodsPath;
        DataTable _dtDataBases;
        List<clsTableLogic> Tables;
        List<clsCustomGetBy> CustomMethod = new List<clsCustomGetBy> { };
        public frmSettiings()
        {
            InitializeComponent();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            bool ChooseOperation = false;
            if(MessageBox.Show("do you want to select your operation there are more features if you choose it manually","Info",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                ChooseOperation=true;
            }
            
            foreach (var item in chkTableList.CheckedItems)
            {
                clsTableLogic Table = new clsTableLogic(item.ToString());
                CustomMethod = new List<clsCustomGetBy> { new clsCustomGetBy(clsCustomGetBy.enMethods.GetBy, Table), new clsCustomGetBy(clsCustomGetBy.enMethods.DeleteBy, Table) };
                if (ChooseOperation)
                {   
                    frmChooseOperations frmChooseOperations = new frmChooseOperations(Table, CustomMethod);
                    frmChooseOperations.ShowDialog();
                }
                

                clsDataAccessGenerate.GenerateMethodOperation(Table,CustomMethod);
                clsBussinessLayer_Generator.GenerateMethodOperation(Table,CustomMethod);
            }
            clsDataAccessGenerate.GenerateDataAccessSetting();
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
            Tables = new List<clsTableLogic> { };

        }
         void AddTablesToListBox(DataTable TablesList)
        {
            

            foreach (DataRow row in TablesList.Rows)
            {
                string TableName=row["TABLE_NAME"].ToString();
                Tables.Add(new clsTableLogic(TableName));
                chkTableList.Items.Add(TableName);
                
            }
        }

        private async void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkTableList.Items.Clear();
            clsSettings.DBName =guna2ComboBox1.Text;
            clsSettings.SetConnectionString();
            DataTable tablesList = await Task.Run(() => clsTableLogic.GetAllTheTables());
            AddTablesToListBox(tablesList);
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if(!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            MethodsPath=folderBrowserDialog1.SelectedPath;
            clsDataAccessGenerate.MethodsPath= MethodsPath;
            clsBussinessLayer_Generator.MethodsPath= MethodsPath;

        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i< chkTableList.Items.Count;i++)
            {
               chkTableList.SetItemChecked(i, chkSelectAll.Checked);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           MethodsPath=saveFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void chkTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item=chkTableList.SelectedItem;
            if(item==null) return;
            foreach(var Table in Tables)
            {
                if(Table.TableName==item.ToString())
                {
                    dgvColumns.DataSource=Table.ColumnsList;
                    return;
                }
            }

        }
    }
}
