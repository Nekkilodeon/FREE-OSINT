using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FREE_OSINT_Lib;

namespace FREE_OSINT
{
    public partial class Show_Modules : Form
    {
        public IGeneral_module selected_module;
        private General_Config.Module_Type module_type;

        public Show_Modules(General_Config.Module_Type type)
        {
            InitializeComponent();
            this.module_type = type;
            this.CenterToScreen();
            populateList(null);
            this.Title.Text = type.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
            selected_module = Main_Instance.Instance.Module_list[module_type].Find(x => x.Title().Equals(listReportModules.Items[listReportModules.SelectedIndices[0]].Text));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                populateList(null);
            }
            else
            {
                populateList(txtSearch.Text);
            }
        }

        private void populateList(string text)
        {
            listReportModules.Items.Clear();
            if (text == null)
            {
                foreach (IGeneral_module module in Main_Instance.Instance.Module_list[module_type])
                {
                    listReportModules.Items.Add(module.Title());
                }
            }
            else
            {
                foreach (IGeneral_module module in Main_Instance.Instance.Module_list[module_type])
                {
                    if (module.Title().ToLower().Contains(text.ToLower()))
                    {
                        listReportModules.Items.Add(module.Title());
                    }
                }
            }
        }

    }
}
