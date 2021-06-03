using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FREE_OSINT.General_Config;

namespace FREE_OSINT
{
    public partial class Modules_All_Form : Form
    {
        public IGeneral_module selected_module { get; private set; }

        public Modules_All_Form()
        {
            InitializeComponent();
            this.CenterToScreen();

            populateList(null);
            listModules.Sorted = true;
        }

        private void btnInteract_Click(object sender, EventArgs e)
        {
            ((IInteractable_module)selected_module).Interact("");
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            ((IConfigurable_module)selected_module).Configure();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            populateList(txtSearch.Text);
        }

        private void populateList(string text)
        {
            listModules.Items.Clear();
            if (text == null || text.Length == 0)
            {
                foreach (KeyValuePair<Module_Type, List<IGeneral_module>> entry in Main_Instance.Instance.Module_list)
                {
                    foreach (IGeneral_module module in entry.Value)
                    {
                        listModules.Items.Add(module.Title());
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<Module_Type, List<IGeneral_module>> entry in Main_Instance.Instance.Module_list)
                {
                    foreach (IGeneral_module module in entry.Value)
                    {
                        if (module.Title().ToLower().Contains(text.ToLower()))
                        {
                            listModules.Items.Add(module.Title());
                        }
                    }
                }
            }
        }

        private void listModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<Module_Type, List<IGeneral_module>> entry in Main_Instance.Instance.Module_list)
            {
                foreach (IGeneral_module module in entry.Value)
                {
                    if (module.Title().Equals(listModules.SelectedItem))
                    {
                        selected_module = module;
                        txtDescription.Text = selected_module.Description();
                        btnInteract.Enabled = selected_module.GetType().GetInterfaces().Contains(typeof(IInteractable_module));
                        btnConfigure.Enabled = selected_module.GetType().GetInterfaces().Contains(typeof(IConfigurable_module));
                        if (selected_module.GetType().GetInterfaces().Contains(typeof(ISearchable_module)))
                        {
                            txtModuleType.Text = "Search Module";
                        }
                        else if (selected_module.GetType().GetInterfaces().Contains(typeof(IProcessing_Module)))
                        {
                            txtModuleType.Text = "Process Module";
                        }
                        else if (selected_module.GetType().GetInterfaces().Contains(typeof(IReport_module)))
                        {
                            txtModuleType.Text = "Report Module";
                        }
                    }
                }
            }
        }
    }
}
