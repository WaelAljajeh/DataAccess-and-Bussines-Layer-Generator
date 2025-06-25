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
using System.Threading;
using System.Diagnostics;
namespace DataAccessLayer_Generator
{
    public partial class frmSettiings : Form
    {
        string DataAccessMethodsPath;
        string BussinesMethodsPath;
        DataTable _dtDataBases;
        List<clsTableLogic> Tables;
        List<clsCustomGetBy> CustomMethod = new List<clsCustomGetBy> { };
        clsGenerator BussinesGenerator;
        clsGenerator DataAccesGenerator;
        
        public frmSettiings()
        {
            InitializeComponent();
        }
        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();

            bool chooseOperation = false;
            if (MessageBox.Show("Do you want to select your operation? There are more features if you choose manually.", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                chooseOperation = true;
            }

            var tasks = new List<Task>();

            foreach (var item in chkTableList.CheckedItems)
            {
                string tableName = item.ToString();
                clsTableLogic table = await clsTableLogic.CreateAsync(tableName);

                var customMethods = new List<clsCustomGetBy>
        {
            new clsCustomGetBy(clsCustomGetBy.enMethods.GetBy, table),
            new clsCustomGetBy(clsCustomGetBy.enMethods.DeleteBy, table),
            new clsCustomGetBy(clsCustomGetBy.enMethods.IsExistingBy, table)
        };

                if (chooseOperation)
                {
                    frmChooseOperations frmChooseOperations = new frmChooseOperations(table, customMethods);
                    frmChooseOperations.ShowDialog();
                }

                // Run both generations in parallel for this table
                if (!string.IsNullOrWhiteSpace(DataAccessMethodsPath))
                {
                    tasks.Add(Task.Run(() => DataAccesGenerator.GenerateMethodOperation(table, customMethods)));
                }

                if (!string.IsNullOrWhiteSpace(BussinesMethodsPath))
                {
                    tasks.Add(Task.Run(() => BussinesGenerator.GenerateMethodOperation(table, customMethods)));
                }
            }

            await Task.WhenAll(tasks); // Wait for all generation tasks

            stopwatch1.Stop();
            MessageBox.Show($"Classes generated successfully within {stopwatch1.ElapsedMilliseconds} ms!");
        }
        async void LoadDataBasesToComboBox()
        {

            _dtDataBases = await clsDataBasesLogic.GetAllDataBases();
            
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
            chkBussinesLayer.Checked = true;
            chkDataAccessLayer.Checked = true;

        }
        async void AddTablesToListBox(DataTable TablesList)
        {
            

            foreach (DataRow row in TablesList.Rows)
            {
                string TableName=row["TABLE_NAME"].ToString();
                
                Tables.Add(await clsTableLogic.CreateAsync(TableName));
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
            DataAccessMethodsPath=folderBrowserDialog1.SelectedPath;
            DataAccesGenerator = new clsGenerator(clsGenerator.enGenerateType.DataAccess, DataAccessMethodsPath);
            

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
           DataAccessMethodsPath =saveFileDialog1.FileName;
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

        private void chkBussinesLayer_CheckedChanged(object sender, EventArgs e)
        {

            btnSelectBussinesLayer.Enabled = chkBussinesLayer.Checked;
            
        }

        private void chkDataAccessLayer_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectDataAccessPath.Enabled = chkDataAccessLayer.Checked;
        }

        private void btnSelectBussinesLayer_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                BussinesMethodsPath = folderBrowserDialog1.SelectedPath;
            BussinesGenerator = new clsGenerator(clsGenerator.enGenerateType.Bussines, BussinesMethodsPath,DataAccessMethodsPath);

        }
    }
}
