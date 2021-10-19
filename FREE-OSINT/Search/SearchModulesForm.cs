using FREE_OSINT.Main;
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
    public partial class SearchModulesForm : Form
    {
        private string premade_query;

        public SearchModulesForm()
        {
            InitializeComponent();
            loadModules();
            this.CenterToScreen();
            
        }
        public SearchModulesForm(string query)
        {
            InitializeComponent();
            loadModules();
            this.premade_query = query;
            txtQuery.Text = query;
            this.CenterToScreen();
        }

        private void loadModules()
        {
            listModules.Items.Clear();
            if (Main_Instance.Instance.Module_list.Count > 0)
            {
                foreach (IGeneral_module module in Main_Instance.Instance.Module_list[General_Config.Module_Type.Search])
                {
                    listModules.Items.Add(module.Title());
                }
            }
            /*
            listModules.Items.Add("Default Google");
            listModules.Items.Add("Default Bing");*/
        }

        private void listModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listModules.SelectedIndex >= 0)
            {
                btnInteract.Enabled = Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex].GetType().GetInterfaces().Contains(typeof(IInteractable_module));
                btnConfigure.Enabled = Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex].GetType().GetInterfaces().Contains(typeof(IConfigurable_module));
                //btnInteract.Text = "     Interact with " + listModules.Items[listModules.SelectedIndex];
                txtDescription.Text = Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex].Description();
            }
        }


        private void btnInteract_Click(object sender, EventArgs e)
        {
            if (listModules.SelectedIndex >= 0 && Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex].GetType().GetInterfaces().Contains(typeof(IInteractable_module)))
            {
                try
                {
                    ((IInteractable_module)Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex]).Interact(premade_query != null ? premade_query : "");
                    ((IInteractable_module)Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex]).InteractEvent += InteractEventTriggered;
                }
                catch (ObjectDisposedException ex)
                {
                    MessageBox.Show("Malformed module, disposed after closing");
                    //int index = listModules.SelectedIndex;
                    //loadModules();
                    //((IInteractable_module)Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex]).Interact();
                    //((IInteractable_module)o).Interact();
                }
            }
        }

        private void InteractEventTriggered(object sender, EventArgs e)
        {
            InteractEventArgs interactEventArgs = e as InteractEventArgs;
            if (interactEventArgs.Operation.Equals(InteractEventArgs.Operation_Type.INSERT))
            {
                SimpleInputForm simpleInputForm = new SimpleInputForm(interactEventArgs.SelectedObjects);
                var result = simpleInputForm.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
                else
                {

                }

            }
            else if (interactEventArgs.Operation.Equals(InteractEventArgs.Operation_Type.OPEN_URL))
            {
                HashSet<TreeNode> selectedObjects = interactEventArgs.SelectedObjects;
                Open_Url_Form open_Url_Form = new Open_Url_Form(selectedObjects.FirstOrDefault().Text);
                open_Url_Form.Show();
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
                if (Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.Items.IndexOf(module)].GetType().GetInterfaces().Contains(typeof(ISearchable_module)))
                {
                    searchables.Add((ISearchable_module)Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.Items.IndexOf(module)]);
                }
            }/*
            Query_InsertForm query_InsertForm;
            if (premade_query != null)
            {
                query_InsertForm = new Query_InsertForm(searchables, premade_query);
            }
            else
            {
                query_InsertForm = new Query_InsertForm(searchables);
            }
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
            }*/

            SearchingForm searchingForm = new SearchingForm(searchables, txtQuery.Text, new List<object>());

            var result = searchingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<SearchResult> searchResults = searchingForm.searchResults;
                //ResultsForm resultsForm = new ResultsForm(searchResults);
                //resultsForm.ShowDialog();

                ResultsForm frm = new ResultsForm(searchResults);
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                TabPage myTabPage = new TabPage("Results");
                myTabPage.Controls.Add(frm);
                myTabPage.Padding = new System.Windows.Forms.Padding(3);
                myTabPage.BackColor = System.Drawing.Color.DodgerBlue;

                Main_Instance.Instance.MainForm_Instance.tabControl.TabPages.Add(myTabPage);
                Main_Instance.Instance.MainForm_Instance.tabControl.SelectedTab = Main_Instance.Instance.MainForm_Instance.tabControl.TabPages[Main_Instance.Instance.MainForm_Instance.tabControl.TabPages.Count - 1];
                Main_Instance.Instance.MainForm_Instance.SetTabHeader(myTabPage, Color.DodgerBlue);
                this.DialogResult = DialogResult.OK;


            }
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                if (listModules.SelectedIndex > -1 && Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex].GetType().GetInterfaces().Contains(typeof(IInteractable_module)))
                {
                    ((IConfigurable_module)Main_Instance.Instance.Module_list[General_Config.Module_Type.Search][listModules.SelectedIndex]).Configure();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ModulesForm_Load(object sender, EventArgs e)
        {
            if (!General_Config.skip_tips)
            {
                TipWindow tipWindow = new TipWindow(2);
                tipWindow.ShowDialog();
            }
        }

        private void closingForm(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void listModulesItemChecked(object sender, ItemCheckEventArgs e)
        {
            int value = 0;
            if (e.NewValue == CheckState.Checked)
            {
                value = 1;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                value = -1;
            }
            btnSearchModules.Text = "     Search using " + (((CheckedListBox)sender).CheckedItems.Count + value) + " modules";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listModules.Items.Clear();
            if (Main_Instance.Instance.Module_list[General_Config.Module_Type.Search].Count > 0)
            {
                foreach (IGeneral_module module in Main_Instance.Instance.Module_list[General_Config.Module_Type.Search])
                {
                    if (module.Title().ToLower().Contains(txtSearch.Text.ToLower()))
                        listModules.Items.Add(module.Title());
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
