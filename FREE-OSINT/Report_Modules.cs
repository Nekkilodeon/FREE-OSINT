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
    public partial class Report_Modules : Form
    {
        public IGeneral_module selected_module;
        private string selected_module_str;

        public Report_Modules()
        {
            var module = Main_Instance.Instance.Module_list;
            InitializeComponent();
            populateList(null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            selected_module = Main_Instance.Instance.Module_list[General_Config.Module_Type.Report].Find(x => x.Title().Equals(selected_module_str));
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
                foreach (IGeneral_module module in Main_Instance.Instance.Module_list[General_Config.Module_Type.Report])
                {
                    listReportModules.Items.Add(module.Title());
                }
            }
            else
            {
                foreach (IGeneral_module module in Main_Instance.Instance.Module_list[General_Config.Module_Type.Report])
                {
                    if (module.Title().ToLower().Contains(text.ToLower()))
                    {
                        listReportModules.Items.Add(module.Title());
                    }
                }
            }
        }

        private void listReportModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_module_str = listReportModules.SelectedItems[0].Text;
        }
    }
}
