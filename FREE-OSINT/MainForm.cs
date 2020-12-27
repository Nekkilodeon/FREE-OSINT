using FREE_OSINT_Lib;
using NodeControl;
using NodeControl.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace FREE_OSINT
{
    public partial class MainForm : Form
    {
        private StreamWriter sr;
        private TreeNode selectedNode;
        private Point selectedLocation;
        private bool autolayout = true;

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            /*
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }*/
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeViewTargets.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeViewTargets.SelectedNode = treeViewTargets.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeViewTargets.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = treeViewTargets.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }
                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
            Main_Instance.Instance.Workspace.reloadTargetsFromTreeView();
            reloadWorkspace();
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        public MainForm()
        {
            InitializeComponent();
            Main_Instance.Instance.NodeDiagram.Dock = DockStyle.Fill;
            Main_Instance.Instance.Workspace.TargetTreeView = treeViewTargets;
            panelDrawWorkspace.Controls.Add(Main_Instance.Instance.NodeDiagram);
            treeViewTargets.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            treeViewTargets.DragEnter += new DragEventHandler(treeView1_DragEnter);
            treeViewTargets.DragOver += new DragEventHandler(treeView1_DragOver);
            treeViewTargets.DragDrop += new DragEventHandler(treeView1_DragDrop);
        }

        private void btnModules_Click(object sender, EventArgs e)
        {

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchModulesForm modulesForm = new SearchModulesForm();
            var result = modulesForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                reloadWorkspace();
            }
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
            reloadWorkspace();
            treeViewTargets.Nodes.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File xml|*.xml";
            saveFileDialog1.Title = "Save results to XML file";
            var filePath = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exportToXml(saveFileDialog1.FileName);
            }
            //EXPORT WORKPLACE TO FILE
        }
        public void exportToXml(string filename)
        {
            String[] split = filename.Split('.');
            string newFilename = "";
            for (int i = 0; i < split.Length; i++)
            {
                if (i == split.Length - 1 && !split[i - 1].Equals("workspace"))
                {
                    newFilename += "workspace." + split[i];
                }
                else
                {
                    newFilename += split[i] + ".";
                }
            }
            sr = new StreamWriter(newFilename, false, System.Text.Encoding.UTF8);
            //Write the header
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sr.WriteLine("<Workplace>");
            foreach (Target target in Main_Instance.Instance.Workspace.Targets)
            {
                Point point = Main_Instance.Instance.Workspace.TreeViewPositions[target.Title];
                sr.WriteLine("<Target value=\"" + target.Title + "\" x=\"" + point.X + "\" y=\"" + point.Y + "\">");
                foreach (TreeNode node in target.TreeNodes)
                {
                    Point subpoint = Main_Instance.Instance.Workspace.TreeViewPositions[node.Text];
                    sr.WriteLine("<Node value=\"" + node.Text + "\" x=\"" + subpoint.X + "\" y=\"" + subpoint.Y + "\">");
                    saveNode(node.Nodes);
                    sr.WriteLine("</Node>");
                }
                sr.WriteLine("</Target>");
            }
            //Close the root node
            sr.WriteLine("</Workplace>");
            sr.Close();
        }

        private void saveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    Point subpoint = Main_Instance.Instance.Workspace.TreeViewPositions[node.Text];
                    sr.WriteLine("<Node value=\"" + HttpUtility.HtmlEncode(node.Text) + "\" x=\"" + subpoint.X + "\" y=\"" + subpoint.Y + "\">");
                    saveNode(node.Nodes);
                    sr.WriteLine("</Node>");
                }
                else
                    sr.WriteLine("<Node value=\"" + HttpUtility.HtmlEncode(node.Text) + "\"></Node>");
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.Workspace = new Workspace();
            //OPEN WORKPLACE FILE
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Workspace XML Document";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.FileName = Application.StartupPath + "\\..\\..\\example.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(dlg.FileName);
                    Main_Instance.Instance.Workspace = new Workspace();
                    Main_Instance.Instance.Workspace.Targets.Clear();
                    Main_Instance.Instance.Workspace.Title = dlg.SafeFileName;
                    XmlNodeList target_elements = xDoc.DocumentElement.GetElementsByTagName("Target");

                    foreach (XmlNode target_node in target_elements)
                    {
                        string title = target_node.Attributes.GetNamedItem("value").Value;
                        int x = Int16.Parse(target_node.Attributes.GetNamedItem("x").Value);
                        int y = Int16.Parse(target_node.Attributes.GetNamedItem("y").Value);

                        Main_Instance.Instance.Workspace.TreeViewPositions.Add(title, new Point(x, y));

                        Target target = new Target(title);
                        XmlNodeList childNodes = target_node.ChildNodes;
                        foreach (XmlNode node in childNodes)
                        {
                            TreeNode tNode = new TreeNode(node.Attributes.GetNamedItem("value").Value);
                            /*
                            x = Int16.Parse(node.Attributes.GetNamedItem("x").Value);
                            y = Int16.Parse(node.Attributes.GetNamedItem("y").Value);

                            Main_Instance.Instance.Workspace.TreeViewPositions.Add(tNode.Text, new Point(x, y));
                            */
                            addTreeNode(node, tNode);
                            target.addNode(tNode);
                        }
                        Main_Instance.Instance.Workspace.Targets.Add(target);
                    }


                }
                catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
                {
                    MessageBox.Show(xExc.Message);
                }
                catch (Exception ex) //General exception
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Main_Instance.Instance.Workspace.generateTreeViewFromTargets();
                    reloadWorkspace();
                    Main_Instance.Instance.sync_diagram_positions();
                    //Main_Instance.Instance.populate_position_dictionary();
                    this.Cursor = Cursors.Default; //Change the cursor back
                }
            }
        }

        public void reloadWorkspace()
        {
            treeViewTargets.Nodes.Clear();
            Main_Instance.Instance.Workspace.TargetTreeView = treeViewTargets;
            Main_Instance.Instance.Workspace.generateTreeViewFromTargets();
            Main_Instance.Instance.sync_diagram_positions();
            labelWorkspaceName.Text = Main_Instance.Instance.Workspace.Title;
            Main_Instance.Instance.drawTreeNodes();
            treeViewTargets.ExpandAll();

        }

        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes)
            {
                xNodeList = xmlNode.ChildNodes;


                int xx = Int16.Parse(xmlNode.Attributes.GetNamedItem("x").Value);
                int y = Int16.Parse(xmlNode.Attributes.GetNamedItem("y").Value);

                Main_Instance.Instance.Workspace.TreeViewPositions.Add(treeNode.Text, new Point(xx, y));

                for (int x = 0; x <= xNodeList.Count - 1; x++)
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(HttpUtility.HtmlDecode(xNode.Attributes[0].Value)));
                    tNode = treeNode.Nodes[x];


                    addTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = HttpUtility.HtmlDecode(xmlNode.Attributes[0].Value);
        }

        private void workplace_panel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void paint_workplace()
        {

        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm("File");
            if (!resultsForm.IsDisposed && resultsForm.DialogResult == DialogResult.Retry)
            {
                resultsForm.ShowDialog();

            }
            if (resultsForm.DialogResult == DialogResult.OK)
            {
                reloadWorkspace();
            }
            //resultsForm.ShowDialog();
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
            if (autolayout)
            {
                autolayout = false;
            }
            else
            {
                autolayout = true;
            }
            Main_Instance.Instance.NodeDiagram.AutoLayout(autolayout);

        }

        private void btnBezier_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.Bezier;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void btn4way_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.FourWay;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void btnStraight_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.Straight;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            ConditionNode node = (ConditionNode)Main_Instance.Instance.NodeDiagram.Nodes.First();
            node.Position = new Point(0, 0);
            /*
            try
            {
                using (Form frm = new Form())
                {
                    frm.BackgroundImage = Main_Instance.Instance.NodeDiagram.AsImage();
                    frm.BackgroundImageLayout = ImageLayout.None;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void labelWorkspaceName_Click(object sender, EventArgs e)
        {

        }

        private void panelDrawWorkspace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedNode = e.Node;
                if (selectedNode != null)
                {

                    ContextMenu mnu = new ContextMenu();
                    MenuItem myMenuItem2 = new MenuItem("Remove");
                    myMenuItem2.Click += new EventHandler(myMenuItem_Click);
                    mnu.MenuItems.Add(myMenuItem2);
                    mnu.Show(treeViewTargets, e.Location);
                    selectedLocation = e.Location;
                }
            }
        }
        private void myMenuItem_Click(object sender, EventArgs e)
        {

            if (((MenuItem)sender).Text == "Remove" && selectedNode != null)
            {
                treeViewTargets.Nodes.Remove(selectedNode);
                Main_Instance.Instance.Workspace.reloadTargetsFromTreeView();
                reloadWorkspace();
            }
            else if (((MenuItem)sender).Text == "New Target" && selectedNode != null)
            {
                SimpleInputForm newTargetForm = new SimpleInputForm("New Target");
                newTargetForm.Location = selectedLocation;
                newTargetForm.ShowDialog();
                if (newTargetForm.DialogResult == DialogResult.OK)
                {
                    if (newTargetForm.title != "")
                    {
                        Main_Instance.Instance.Workspace.Targets.Add(new Target(newTargetForm.title, selectedNode));
                    }
                    //Main_Instance.Instance.Workspace.
                }
            }
            else
            {
                Main_Instance.Instance.Workspace.findTarget(((MenuItem)sender).Text).TreeNodes.Add(selectedNode);
            }
        }
        public class TreeSyncronizer
        {
            static public void SyncTreeNodes(TreeNodeCollection source, TreeNodeCollection target)
            {
                foreach (TreeNode node in source)
                {
                    TreeNode theNode = SyncNode(node, target);
                    SyncTreeNodes(node.Nodes, theNode.Nodes);
                }
            }

            static private TreeNode SyncNode(TreeNode node, TreeNodeCollection tv)
            {
                TreeNode fNode = FindNode(node, tv);
                if (fNode == null)
                {
                    fNode = (TreeNode)node.Clone();
                    tv.Insert(node.Index, fNode);
                }
                return fNode;
            }

            static private TreeNode FindNode(TreeNode nodeToFind, TreeNodeCollection tv)
            {
                TreeNode[] treeNodes = tv.Cast<TreeNode>().Where(r => r.Text == nodeToFind.Text).ToArray();
                foreach (TreeNode node in treeNodes)
                {
                    if (node.Level == nodeToFind.Level)
                        return node;
                }
                return null;
            }
        }

        private void treeViewTargets_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void closingForm(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void modulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report_Modules report_Modules = new Report_Modules();
            var result = report_Modules.ShowDialog();
            if (result == DialogResult.OK)
            {
                IReport_module report_Module = (IReport_module)report_Modules.selected_module;
                Select_Nodes select_Nodes = new Select_Nodes(treeViewTargets);
                var result_nodes = select_Nodes.ShowDialog();
                if (result_nodes == DialogResult.OK)
                {
                    report_Module.GenerateDocument(select_Nodes.selected_nodes);
                }
                else
                {
                    select_Nodes.Hide();
                }
            }
            else
            {
                report_Modules.Hide();
            }
        }

        private void showFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", General_Config.modules_directory);
        }
    }
}
