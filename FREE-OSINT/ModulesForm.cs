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

namespace FREE_OSINT
{
    public partial class ModulesForm : Form
    {
        List<IInteractable_module> module_list;

        public ModulesForm()
        {
            InitializeComponent();
            loadModules();
        }

        private void loadModules()
        {
            string[] module_directories = System.IO.Directory.GetDirectories(General_Config.modules_directory);
            for(int i = 0; i < module_directories.Length; i++)
            {
                var moduleAssembly = System.Reflection.Assembly.LoadFrom(module_directories[i] + "/" + module_directories[i].Split('\\')[1] + ".exe");
                var moduleTypes = moduleAssembly.GetTypes().Where(t =>
                   t.GetInterfaces().Contains(typeof(IInteractable_module)));
                var modules = moduleTypes.Select(type =>
                {
                    return (IInteractable_module)Activator.CreateInstance(type);
                });
                module_list = modules.ToList();
                foreach(IInteractable_module module in module_list)
                {
                    listModules.Items.Add(module.Title());
                }
            }
            listModules.Items.Add("Default Google");
            listModules.Items.Add("Default Bing");
        }

        private void listModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInteract.Text = "Interact with " + listModules.Items[listModules.SelectedIndex];
            btnSearchModules.Text = "Search using " + listModules.CheckedIndices.Count + " modules";
        }

        private void btnInteract_Click(object sender, EventArgs e)
        {
            module_list[listModules.SelectedIndex].Interact();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
