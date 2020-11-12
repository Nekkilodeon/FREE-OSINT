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
        List<IGeneral_module> module_list;
        IEnumerable<IGeneral_module> modules;
        public ModulesForm()
        {
            InitializeComponent();
            loadModules();
        }

        private void loadModules()
        {
            module_list = new List<IGeneral_module>();
            listModules.Items.Clear();
            
            string[] module_directories = System.IO.Directory.GetDirectories(General_Config.modules_directory);
            for(int i = 0; i < module_directories.Length; i++)
            {
                var moduleAssembly = System.Reflection.Assembly.LoadFrom(module_directories[i] + "/" + module_directories[i].Split('\\')[1] + ".exe");
                var moduleTypes = moduleAssembly.GetTypes().Where(t =>
                   t.GetInterfaces().Contains(typeof(IGeneral_module)));
                modules = moduleTypes.Select(type =>
                {
                    return (IGeneral_module)Activator.CreateInstance(type);
                });
                module_list.AddRange(this.modules.ToList());
                
            }

            foreach (IGeneral_module module in module_list)
            {
                listModules.Items.Add(module.Title());
            }
            /*
            listModules.Items.Add("Default Google");
            listModules.Items.Add("Default Bing");*/
        }

        private void listModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listModules.SelectedIndex > 0)
            {
                btnInteract.Enabled = module_list[listModules.SelectedIndex].isInteractable();
                btnConfigure.Enabled = module_list[listModules.SelectedIndex].isConfigurable();
                btnInteract.Text = "Interact with " + listModules.Items[listModules.SelectedIndex];
                btnSearchModules.Text = "Search using " + listModules.CheckedIndices.Count + " modules";
            }
        }

        private void btnInteract_Click(object sender, EventArgs e)
        {
            if (module_list[listModules.SelectedIndex].isInteractable())
            {
                try
                {
                    ((IInteractable_module)module_list[listModules.SelectedIndex]).Interact();
                }
                catch (ObjectDisposedException ex)
                {
                    int index = listModules.SelectedIndex;
                    loadModules();
                    ((IInteractable_module)module_list[index]).Interact();
                    //((IInteractable_module)o).Interact();
                }
            }
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SEARCH Modules
            //listModules.CheckedItems.
            List<ISearchable_module> searchables = new List<ISearchable_module>();
            foreach (string module in listModules.CheckedItems)
            {
                if (module_list[listModules.Items.IndexOf(module)].isSearchable())
                {
                    searchables.Add((ISearchable_module)module_list[listModules.Items.IndexOf(module)]);
                }
            }

            Query_InsertForm query_InsertForm = new Query_InsertForm(searchables);
            query_InsertForm.ShowDialog();
            var result = query_InsertForm.DialogResult;
            if (result == DialogResult.OK)
            {
                string query = query_InsertForm.query;
                List<object> extras = query_InsertForm.extras;
                SearchingForm searchingForm = new SearchingForm(searchables, query, extras);
                searchingForm.ShowDialog();
                query_InsertForm.Close();

                result = searchingForm.DialogResult;

                if (result == DialogResult.OK)
                {
                    List<SearchResult> searchResults = searchingForm.searchResults;
                    ResultsForm resultsForm = new ResultsForm(searchResults);
                    resultsForm.ShowDialog();

                }
                //Do something here with these values
            }
            if (result == DialogResult.Cancel)
            {
                query_InsertForm.Close();
            }

        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            if (module_list[listModules.SelectedIndex].isConfigurable())
            {
                ((IConfigurable_module)module_list[listModules.SelectedIndex]).Configure();
            }
        }

        private void ModulesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
