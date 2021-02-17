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
    public partial class SimpleInputForm : Form
    {
        public string title;
        private string url;
        private HashSet<TreeNode> treeNodes;

        public SimpleInputForm()
        {
            InitializeComponent();
            title = txtTitle.Text;
        }
        public SimpleInputForm(string name)
        {
            InitializeComponent();

            this.Text = name;
            this.txtDescription.Visible = false;
            this.label2.Visible = false;
            this.labelURL.Visible = false;
            this.label3.Visible = false;
            this.cmbTargets.Visible = false;
            this.btnNewTarget.Visible = false;
        }
        public SimpleInputForm(HashSet<TreeNode> treeNodes)
        {
            InitializeComponent();
            populateCmbTargets();
            this.Text = "Select Target";
            this.txtTitle.Enabled = false;
            this.txtDescription.Enabled = false;
            this.labelURL.Enabled = false;
            this.label3.Enabled = false;
            this.treeNodes = treeNodes;
        }
        public SimpleInputForm(string name, string url)
        {
            InitializeComponent();
            populateCmbTargets();

            this.Text = "New Intel";
            this.txtTitle.Text = name;
            this.labelURL.Text = url;
            this.url = url;
        }
        private void populateCmbTargets()
        {
            cmbTargets.Items.Clear();
            cmbTargets.Items.AddRange(Main_Instance.Instance.Workspace.Targets.ToArray());
            if (cmbTargets.Items.Count > 0)
                cmbTargets.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.title = txtTitle.Text;
            if (treeNodes != null)
            {
                foreach (TreeNode node in treeNodes)
                {
                    ((Target)cmbTargets.SelectedItem).TreeNodes.Add(node);
                }
            }
            else if (txtDescription.Visible)
            {
                TreeNode link = new TreeNode(url);
                List<TreeNode> nodes = new List<TreeNode>();
                nodes.Add(link);
                if (txtDescription.Text != String.Empty)
                {
                    nodes.Add(new TreeNode(txtDescription.Text));
                }
                nodes.Add(new TreeNode(DateTime.Now.ToString()));
                TreeNode node = new TreeNode(title, nodes.ToArray());
                try
                {
                    ((Target)cmbTargets.SelectedItem).TreeNodes.Add(node);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnNewTarget_Click(object sender, EventArgs e)
        {
            SimpleInputForm newTargetForm = new SimpleInputForm("New Target");
            newTargetForm.Location = ((Button)sender).Location;
            newTargetForm.ShowDialog();
            if (newTargetForm.DialogResult == DialogResult.OK)
            {
                if (newTargetForm.title != "")
                {
                    Main_Instance.Instance.Workspace.Targets.Add(new Target(newTargetForm.title));
                    populateCmbTargets();
                }
                //Main_Instance.Instance.Workspace.
            }
        }
    }
}
