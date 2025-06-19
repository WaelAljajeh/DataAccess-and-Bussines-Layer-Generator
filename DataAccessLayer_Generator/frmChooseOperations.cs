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
        List<clsCustomGetBy> CustomMethodTypeList;
        public frmChooseOperations(clsTableLogic Table,List<clsCustomGetBy> customMethodTypeList)
        {
            InitializeComponent();
            _Table = Table;
            CustomMethodTypeList = customMethodTypeList;
        }
        enum enOperation { Add,DeleteBy,Update,GetBy};
        clsCustomGetBy CustomMethodType;
        
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
            
          
            
            
            
        }
        void AddCheckedColumnsToList()
        {
            foreach (clsColumn col in _Table.ColumnsList)
            {

               
                foreach (var item in chkGetColList.CheckedItems)
                {


                    if (col.Name == item.ToString())
                    {
                        CustomMethodType.GetByCols.Add(col);
                        break;
                    }
                }
            }
        }
        private void chkOperationList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        
        }

        private void llAddCustomMethod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            CustomMethodType = new clsCustomGetBy();
            cbMethodType.Visible = true;
            cbMethodType.SelectedIndex = 0;
            chkGetColList.Visible = true;
            btnAddCustomMethod.Visible = true;

        }

        private void cbMethodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMethodType.SelectedIndex==cbMethodType.FindString(clsCustomGetBy.enMethods.GetBy.ToString()))
            {
                CustomMethodType.MethodType = clsCustomGetBy.enMethods.GetBy;
            }
            else if(cbMethodType.SelectedIndex == cbMethodType.FindString(clsCustomGetBy.enMethods.DeleteBy.ToString()))
            {
                CustomMethodType.MethodType = clsCustomGetBy.enMethods.DeleteBy;
            }
            else
            {
                CustomMethodType.MethodType = clsCustomGetBy.enMethods.IsExistingBy;
            }
        }

        private void btnAddCustomMethod_Click(object sender, EventArgs e)
        {
            AddCheckedColumnsToList();
            CustomMethodTypeList.Add(CustomMethodType);
            cbMethodType.Visible = false;
            //cbMethodType.SelectedIndex = 0;
            chkGetColList.Visible = false;
            btnAddCustomMethod.Visible = false;


        }
    }
}
