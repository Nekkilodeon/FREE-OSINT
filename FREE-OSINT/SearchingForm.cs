using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    public partial class SearchingForm : Form
    {
        List<ISearchable_module> modules;
        public List<SearchResult> searchResults;
        Action action;

        public SearchingForm()
        {
            InitializeComponent();
        }

        public SearchingForm(List<ISearchable_module> modules, string query, List<object> extras)
        {
            InitializeComponent();
            this.modules = modules;
            this.searchResults = new List<SearchResult>();
            populateModuleList();
            searchModules(query, extras);
        }

        public void addtoResults(SearchResult result){
            searchResults.Add(result);
        }

        private void populateModuleList()
        {
            listViewModules.Enabled = false;
            listViewModules.Columns.Add("Module", 320, HorizontalAlignment.Left);
            listViewModules.Columns.Add("Status", 100, HorizontalAlignment.Left);
            listViewModules.Columns.Add("Results", 150, HorizontalAlignment.Left);
            if (modules != null)
            {
                foreach (ISearchable_module module in modules)
                {
                    var list_item = new ListViewItem(new[] { ((IGeneral_module)module).Title(), "", ""});
                    listViewModules.Items.Add(list_item);
                } 
            }
        }

        private void searchModules(string query, List<object> extras)
        {
            ThreadWithState tws = new ThreadWithState(modules,query,extras, this);

            // Create a thread to execute the task, and then
            // start the thread.
            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            //t.Join();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private class ThreadWithState
        {
            // State information used in the task.
            List<ISearchable_module> modules;
            private string query;
            private List<object> extras;
            private SearchingForm searchingForm;

            // The constructor obtains the state information.
            public ThreadWithState(List<ISearchable_module> modules, string query, List<object> extras, SearchingForm searchingForm)
            {
                this.modules = modules;
                this.query = query;
                this.extras = extras;
                this.searchingForm = searchingForm;
            }

            // The thread procedure performs the task, such as formatting
            // and printing a document.
            public void ThreadProc()
            {
                foreach (ISearchable_module module in modules)
                {
                    searchingForm.txtLog.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        searchingForm.txtLog.Text += "Executing: " + ((IGeneral_module)module).Title();
                        searchingForm.txtLog.Text += Environment.NewLine;

                    });
                    searchingForm.listViewModules.Invoke((MethodInvoker)delegate {
                        searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[0].Font = new Font(FontFamily.GenericSansSerif, 7.8f, FontStyle.Bold);
                    });

                    SearchResult result = module.Search(query, extras);

                    searchingForm.txtLog.Invoke((MethodInvoker)delegate
                    {
                        searchingForm.addtoResults(result);
                    });


                        searchingForm.listViewModules.Invoke((MethodInvoker)delegate {
                        searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[0].Font = new Font(FontFamily.GenericSansSerif, 7.8f, FontStyle.Regular);
                    });
                    searchingForm.txtLog.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        searchingForm.txtLog.Text += Environment.NewLine;
                        searchingForm.txtLog.Text = result.Message;
                        searchingForm.txtLog.Text += Environment.NewLine;
                    });

                    searchingForm.listViewModules.Invoke((MethodInvoker)delegate {
                        searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[1].Text = Enum.GetName(typeof(Status_Code), result.Status);
                        searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[2].Text = result.Num_results.ToString();
                    });

                   
                    /*
                    searchingForm.txtLog.Text += Environment.NewLine;
                    searchingForm.txtLog.Text = result.Message;
                    searchingForm.txtLog.Text += Environment.NewLine;
                    searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[1].Text = Enum.GetName(typeof(Status_Code), result.Status);
                    searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[1].Font = new Font(FontFamily.GenericSansSerif, 7.8f, FontStyle.Bold);
                    searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[2].Text = result.Num_results.ToString();
                    searchingForm.listViewModules.Items[modules.IndexOf(module)].SubItems[1].Font = new Font(FontFamily.GenericSansSerif, 7.8f, FontStyle.Bold);
                */
                }
                searchingForm.btnDone.Invoke((MethodInvoker)delegate
                {
                    searchingForm.btnDone.Enabled = true;
                });

                    //Console.WriteLine(boilerplate, numberValue);
                }
        }

        private void log(string v)
        {
            this.txtLog.AppendText(v);
            this.txtLog.AppendText(Environment.NewLine);

        }
    }

}
