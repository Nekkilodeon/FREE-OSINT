using FREE_OSINT_Lib;
using NodeControl;
using NodeControl.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    public partial class MainForm : Form
    {
        NodeDiagram nodeDiagram;
        public MainForm()
        {
            InitializeComponent();
            nodeDiagram = new NodeDiagram();
            nodeDiagram.Dock = DockStyle.Fill;
            nodeDiagram.AutoLayout(true);
            panelDrawWorkspace.Controls.Add(nodeDiagram);
        }

        private void btnModules_Click(object sender, EventArgs e)
        {

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModulesForm modulesForm = new ModulesForm();
            modulesForm.Show();
        }

        private void showFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", General_Config.modules_directory);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.Workspace = new Workspace();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EXPORT WORKPLACE TO FILE
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OPEN WORKPLACE FILE
        }

        private void workplace_panel_Paint(object sender, PaintEventArgs e)
        {
            /*
            //create a form 
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("Facebook", "Instagram");
            graph.AddEdge("Instagram", "Youtube");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("Youtube").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("Instagram").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            workplace_panel.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            workplace_panel.Controls.Add(viewer);
            workplace_panel.ResumeLayout();*/
            //show the form 
        }
        private void paint_workplace()
        {
            List<TreeNode> treenodes = Main_Instance.Instance.Workspace.Targets[0].TreeNodes;

        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm("File");
            resultsForm.ShowDialog();
            if(resultsForm.DialogResult == DialogResult.OK && resultsForm.results != null)
            {
                drawTreeNodes(resultsForm.results);
            }

        }

        private void drawTreeNodes(List<TreeNode> results)
        {
            foreach (TreeNode treeNode in results[0].Nodes)
            {
                drawSubNodes(treeNode, null);
            }
            foreach (var node in nodeDiagram.Nodes)
            {
                node.Direction = Node.DirectionEnum.Vertical;
            }
        }

        private void drawSubNodes(TreeNode treeNode, ConditionNode prevNode)
        {
            if(treeNode.Nodes.Count > 0)
            {
                Random rnd = new Random(treeNode.Nodes.Count);
                //Microsoft.Msagl.Drawing.Color randomColor = new Microsoft.Msagl.Drawing.Color((byte)rnd.Next(256),(byte) rnd.Next(256), (byte) rnd.Next(256));
                ConditionNode node = prevNode;
                if (prevNode == null)
                {
                    node = new ConditionNode(nodeDiagram) { Text = treeNode.Text };
                }

                foreach (TreeNode subnode in treeNode.Nodes)
                {
                    if(subnode.Nodes.Count > 0)
                    {
                        var node2 = new ConditionNode(nodeDiagram) { Text = subnode.Text };
                        node.LinksTo.Add(new Condition() { LinksTo = node2 });
                        nodeDiagram.Nodes.Add(node2);
                        drawSubNodes(subnode, node2);
                    }
                    else
                    {
                        node.LinksTo.Add(new Condition() { Text = subnode.Text });
                    }

                }
                if(prevNode == null)
                nodeDiagram.Nodes.Add(node);

                return;
            }
            return;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAutoLayout_Click(object sender, EventArgs e)
        {
            nodeDiagram.AutoLayout(false);

        }

        private void btnBezier_Click(object sender, EventArgs e)
        {
            nodeDiagram.LineType = LineTypeEnum.Bezier;
            nodeDiagram.Redraw();
        }

        private void btn4way_Click(object sender, EventArgs e)
        {
            nodeDiagram.LineType = LineTypeEnum.FourWay;
            nodeDiagram.Redraw();
        }

        private void btnStraight_Click(object sender, EventArgs e)
        {
            nodeDiagram.LineType = LineTypeEnum.Straight;
            nodeDiagram.Redraw();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form frm = new Form())
                {
                    frm.BackgroundImage = nodeDiagram.AsImage();
                    frm.BackgroundImageLayout = ImageLayout.None;
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
