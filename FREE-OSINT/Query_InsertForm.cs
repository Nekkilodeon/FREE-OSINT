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
    public partial class Query_InsertForm : Form
    {
        private List<ISearchable_module> modules;
        public String query;
        public List<object> extras;

        public Query_InsertForm()
        {
            InitializeComponent();
        }
        public Query_InsertForm(List<ISearchable_module> modules)
        {
            this.modules = modules;
            InitializeComponent();
            populateListView();
        }

        private void populateListView()
        {
            listViewModules.Columns.Add("Title", 250, HorizontalAlignment.Left);
            foreach (ISearchable_module module in modules) {
                listViewModules.Items.Add(((IGeneral_module)module).Title());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = txtQuery.Text;
            extras = new List<object>();
            extras.Add(Int16.Parse(txtLimitResults.Value + ""));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listViewModules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
