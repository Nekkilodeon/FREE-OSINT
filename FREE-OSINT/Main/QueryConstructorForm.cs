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
    public partial class QueryConstructorForm : Form
    {
        private List<string> to_query;
        private List<TreeNode> targets;
        private List<string> query;
        public string final_query = "";

        public QueryConstructorForm()
        {
            this.CenterToScreen();

            InitializeComponent();
        }

        public QueryConstructorForm(List<string> to_query, List<TreeNode> targets)
        {
            InitializeComponent();
            this.CenterToScreen();
            query = new List<string>();
            this.to_query = to_query;
            query.AddRange(to_query);
            updateQueryTxt();
            this.targets = targets;
            populateCheckLists();
        }

        private void updateQueryTxt()
        {
            txtQuery.Text = "";
            foreach (String value in query)
            {
                if(value != null || value != "")
                txtQuery.Text += value + " ";
            }
        }

        private void populateCheckLists()
        {
            foreach (String value in to_query)
            {
                int index = listQueryParams.Items.Add(value);
                listQueryParams.SetItemChecked(index, true);
            }
            foreach(TreeNode target in targets)
            iterate_target_nodes(target);
        }

        private void iterate_target_nodes(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    iterate_target_nodes(subNode);
                }
            }
            else
            {
                listRelated.Items.Add(node.Text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.final_query = txtQuery.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void listQueryItemChecked(object sender, ItemCheckEventArgs e)
        {
            if(((CheckedListBox)sender).SelectedItem != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    query.Add((string)((CheckedListBox)sender).SelectedItem);
                }
                else
                {
                    query.Remove((string)((CheckedListBox)sender).SelectedItem);
                }
                updateQueryTxt();
            }

        }

        private void listRelatedChecked(object sender, ItemCheckEventArgs e)
        {
            if (((CheckedListBox)sender).SelectedItem != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    query.Add((string)((CheckedListBox)sender).SelectedItem);
                }
                else
                {
                    query.Remove((string)((CheckedListBox)sender).SelectedItem);
                }
                updateQueryTxt();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
