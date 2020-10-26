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
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        public ResultsForm(List<SearchResult> searchResults)
        {
            InitializeComponent();
            populateTreeView(searchResults);
        }

        private void populateTreeView(List<SearchResult> searchResults)
        {
            foreach (SearchResult result in searchResults)
            {
                if(result.Treenode != null) {
                    treeViewResults.Nodes.Add(result.Treenode);
                }
            }
            /*
            TreeNode treeNode = new TreeNode("Windows");
            treeViewResults.Nodes.Add(treeNode);
            TreeNode node2 = new TreeNode("C#");
            TreeNode node3 = new TreeNode("VB.NET");
            TreeNode[] array = new TreeNode[] { node2, node3 };
            treeNode = new TreeNode("Dot Net Perls", array);
            treeViewResults.Nodes.Add(treeNode);*/
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            //txtURL.Text
        }

        private void treeViewResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                if(e.Node.Text.Contains("http")){
                    webBrowser1.Url = new Uri(e.Node.Text);
                    txtURL.Text = e.Node.Text;
                    //MessageBox.Show(e.Node.Nodes.Count + "");
                }
            }
            
            //
        }
    }
}
