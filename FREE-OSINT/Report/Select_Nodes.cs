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
    public partial class Select_Nodes : Form
    {
        public List<TreeNode> selected_nodes;
        public Select_Nodes(TreeView treeView)
        {
            selected_nodes = new List<TreeNode>();
            InitializeComponent();
            this.CenterToScreen();
            populateTreeView(treeView);
        }

        private void populateTreeView(TreeView treeView)
        {
            treeViewNodes.Nodes.Clear();
            selected_nodes = new List<TreeNode>();
            foreach (TreeNode treeNode in treeView.Nodes)
            {
                treeViewNodes.Nodes.Add((TreeNode)treeNode.Clone());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            GetCheckedNodes(treeViewNodes.Nodes);
        }

        public void GetCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                //edit
                if (!aNode.Checked && aNode.Nodes.Count == 0)
                    continue;
                if (aNode.Checked)
                {
                    selected_nodes.Add(aNode);
                    continue;
                }

                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeViewNodes.Nodes)
            {
                item.Checked = true;
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeViewNodes.Nodes)
            {
                item.Checked = false;
            }
        }
    }
}
