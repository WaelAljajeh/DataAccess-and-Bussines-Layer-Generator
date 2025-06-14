using GloblalLibrary;
using LogicLayerDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DataAccessLayer_Generator
{
    public partial class frmChooseOperations : Form
    {
        clsTableLogic _Table;
        public frmChooseOperations(clsTableLogic Table)
        {
            InitializeComponent();
            _Table = Table;
        }
        enum enOperation { Add,Delete,Update,GetBy};

        private void chkOperationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmChooseOperations_Load(object sender, EventArgs e)
        {
            foreach (var col in _Table.ColumnsList)
            { 
                
                chkGetColList.Items.Add(col.Name); 
            }
        }

        private void chkGetColList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
      
        }

        private void chkGetColList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            foreach (clsColumn col in _Table.ColumnsList)
            {
                
                col.IsGetByEnabled = false;
                foreach (var item in chkGetColList.CheckedItems)
                {


                    if (col.Name == item.ToString())
                    {
                        col.IsGetByEnabled = true;
                        break;
                    }
                }
            }
            
            
            
        }

        private void chkOperationList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //foreach(var item in chkOperationList.CheckedItems)
            //{
            //    if (item.ToString() == enOperation.Add.ToString())
            //    {
            //        clsDataAccessGenerate.OnOperationExecuted += clsDataAccessGenerate.GenerateInsertMethod;
            //    }
            //    else if (item.ToString() == enOperation.Update.ToString())
            //    {
            //        clsDataAccessGenerate.OnOperationExecuted += clsDataAccessGenerate.GenerateUpdateMethod;
            //    }
            //    else if(item.ToString()==enOperation.Delete.ToString())
            //    {
            //        clsDataAccessGenerate.OnOperationExecuted += clsDataAccessGenerate.GenerateDeleteOperation;
            //    }
            //    else
            //    {
            //        clsDataAccessGenerate.OnOperationExecuted += clsDataAccessGenerate.GenerateGetByIDOperation;
            //    }

            //}
        }
    }
}
