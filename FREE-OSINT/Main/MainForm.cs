using CefSharp;
using CefSharp.WinForms;
using FREE_OSINT.Main;
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
        private Size Base_Box_Size;
        private Dictionary<string, List<string>> ViewState;
        private bool TabClosing = false;

        private void TreeView1_ItemDrag(object sender, ItemDragEventArgs e)
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
        private void TreeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void TreeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeViewTargets.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeViewTargets.SelectedNode = treeViewTargets.GetNodeAt(targetPoint);
        }

        private void TreeView1_DragDrop(object sender, DragEventArgs e)
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
                if (targetNode == null)
                {
                    draggedNode.Remove();
                    ((TreeView)sender).Nodes.Add(draggedNode);
                }
                else if (e.Effect == DragDropEffects.Move)
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
                if (targetNode != null)
                    targetNode.Expand();
            }
            Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();
            ReloadWorkspace(true);
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2 == null || node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        public MainForm()
        {
            //Initiate the workpace select dialog before showing
            WorkspaceDialog workspaceDialog = new WorkspaceDialog();
            var result = workspaceDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InitializeComponent();
                //if user selected a workspace, open the file
                if (workspaceDialog.selected_workspace.Length > 0)
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.FileName = workspaceDialog.selected_workspace;
                    OpenFile(dlg);
                }


                Main_Instance.Instance.NodeDiagram.Dock = DockStyle.Fill;
                //sync the treeview from workspace with the one from the form
                Main_Instance.Instance.Workspace.TargetTreeView = treeViewTargets;
                //update the treeview with the target list info
                Main_Instance.Instance.Workspace.ReloadTreeViewFromTargets();
                //set initial size for container size
                Base_Box_Size = Main_Instance.Instance.NodeDiagram.NodeSize;
                panelDrawWorkspace.Controls.Add(Main_Instance.Instance.NodeDiagram);
                Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.Straight;
                //add listeners for drag&drop
                treeViewTargets.ItemDrag += new ItemDragEventHandler(TreeView1_ItemDrag);
                treeViewTargets.DragEnter += new DragEventHandler(TreeView1_DragEnter);
                treeViewTargets.DragOver += new DragEventHandler(TreeView1_DragOver);
                treeViewTargets.DragDrop += new DragEventHandler(TreeView1_DragDrop);
                Main_Instance.Instance.MainForm_Instance = this;
                //SetTabHeader(tabControl.TabPages[0], Color.Orange);
            }
            else
            {
                Application.Exit();
            }

        }

        private void BtnModules_Click(object sender, EventArgs e)
        {

        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchModulesForm modulesForm = new SearchModulesForm();
            var result = modulesForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ReloadWorkspace(false);
            }
        }

        private void ShowFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", General_Config.modules_directory);
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.Workspace = new Workspace();
            ReloadWorkspace(false);
            treeViewTargets.Nodes.Clear();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = General_Config.Documents_Path;
            saveFileDialog1.Filter = "XML File xml|*.workspace.xml";
            saveFileDialog1.Title = "Save results to XML file";

            saveFileDialog1.FileName = labelWorkspaceName.Text;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var split = saveFileDialog1.FileName.Split('\\');
                var proj_name = split[split.Length - 1];
                var sub_dir = proj_name.Split('.')[0];
                var result = saveFileDialog1.FileName;

                string path = System.IO.Path.Combine(General_Config.Documents_Path, sub_dir);
                if (!Directory.Exists(path))
                {
                    //Exists
                    DialogResult res = MessageBox.Show($"Do you want to place file in a {sub_dir} subfolder?", "Subfolder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        DirectoryInfo info = new DirectoryInfo(General_Config.Documents_Path);
                        DirectoryInfo dis = info.CreateSubdirectory(sub_dir);
                        result = dis.FullName + "\\" + proj_name;
                    }
                    if (res == DialogResult.No)
                    {

                    }
                }
                labelWorkspaceName.Text = proj_name;
                //labelWorkspaceName.Text = saveFileDialog1.FileName;
                ExportToXml(result);
                updateRecentProjectList(result);
            }
            //EXPORT WORKPLACE TO FILE
        }
        public void ExportToXml(string filename)
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
                Point point = new Point(0, 0);
                if (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(target.Title))
                {
                    point = Main_Instance.Instance.Workspace.TreeViewPositions[target.Title];
                }
                Color color = Color.DodgerBlue;
                if (((ConditionNode)Main_Instance.Instance.NodeDiagram.NodeAt(point.X, point.Y)) != null)
                {
                    color = ((ConditionNode)Main_Instance.Instance.NodeDiagram.NodeAt(point.X, point.Y)).Container_color;
                }
                sr.WriteLine("<Target value=\"" + FixUnwantedCharacters(target.Title) + "\" x=\"" + point.X + "\" y=\"" + point.Y + "\" color=\"" + color.ToArgb() + "\">");
                foreach (TreeNode node in target.TreeNodes)
                {
                    Point subpoint = new Point(0, 0);
                    if (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(node.Text))
                    {
                        subpoint = Main_Instance.Instance.Workspace.TreeViewPositions[node.Text];
                    }
                    Color subcolor = Color.DodgerBlue;
                    if (((ConditionNode)Main_Instance.Instance.NodeDiagram.NodeAt(subpoint.X, subpoint.Y)) != null)
                    {
                        subcolor = ((ConditionNode)Main_Instance.Instance.NodeDiagram.NodeAt(subpoint.X, subpoint.Y)).Container_color;
                    }
                    sr.WriteLine("<Node value=\"" + FixUnwantedCharacters(node.Text) + "\" x=\"" + subpoint.X + "\" y=\"" + subpoint.Y + "\" color=\"" + subcolor.ToArgb() + "\">");
                    SaveNode(node.Nodes);
                    sr.WriteLine("</Node>");
                }
                sr.WriteLine("</Target>");
            }
            //Close the root node
            sr.WriteLine("</Workplace>");
            sr.Close();
        }

        private void SaveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    Point subpoint = new Point(0, 0);
                    if (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(node.Text))
                    {
                        subpoint = Main_Instance.Instance.Workspace.TreeViewPositions[node.Text];

                    }
                    Color subcolor = Color.DodgerBlue;
                    if (((ConditionNode)Main_Instance.Instance.NodeDiagram.NodeAt(subpoint.X, subpoint.Y)) != null)
                    {
                        subcolor = ((ConditionNode)Main_Instance.Instance.NodeDiagram.NodeAt(subpoint.X, subpoint.Y)).Container_color;
                    }
                    sr.WriteLine("<Node value=\"" + FixUnwantedCharacters(HttpUtility.HtmlEncode(node.Text)) + "\" x=\"" + subpoint.X + "\" y=\"" + subpoint.Y + "\" color=\"" + subcolor.ToArgb() + "\">");
                    SaveNode(node.Nodes);
                    sr.WriteLine("</Node>");
                }
                else
                    sr.WriteLine("<Node value=\"" + FixUnwantedCharacters(HttpUtility.HtmlEncode(node.Text)) + "\"></Node>");
            }
        }

        private string FixUnwantedCharacters(string v)
        {
            if (v.Contains('"'))
            {
                v.Replace('"', '\'');
            }
            return v;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.Workspace = new Workspace();
            //OPEN WORKPLACE FILE
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = General_Config.Documents_Path;
            dlg.Title = "Open Workspace XML Document";
            dlg.Filter = "XML Files (*.workspace.xml)|*.workspace.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                OpenFile(dlg);
            }
        }
        private void OpenFile(OpenFileDialog dlg)
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
                    int colorARGB = Int32.Parse(target_node.Attributes.GetNamedItem("color").Value);
                    try
                    {
                        Main_Instance.Instance.Workspace.TreeViewPositions.Add(title, new Point(x, y));
                        Main_Instance.Instance.Workspace.TreeViewColors.Add(title, colorARGB);
                    }
                    catch (Exception)
                    {
                        Main_Instance.Instance.Workspace.TreeViewPositions.Add(title + " (1)", new Point(x, y));
                        Main_Instance.Instance.Workspace.TreeViewColors.Add(title + " (1)", colorARGB);

                    }

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
                        AddTreeNode(node, tNode);
                        target.AddNode(tNode);
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
                Main_Instance.Instance.Workspace.ReloadTreeViewFromTargets();
                updateRecentProjectList(dlg.FileName);
                ReloadWorkspace(false);
                Main_Instance.Instance.Sync_diagram_positions();
                //Main_Instance.Instance.populate_position_dictionary();
                this.Cursor = Cursors.Default; //Change the cursor back
            }

        }

        private void updateRecentProjectList(string fileName)
        {
            if (General_Config.recent_workspaces.Contains(fileName))
            {
                General_Config.recent_workspaces.Remove(fileName);
            }
            else
            {
                if (General_Config.recent_workspaces.Count > 4)
                {
                    General_Config.recent_workspaces.RemoveAt(4);
                }
            }
            General_Config.recent_workspaces.Insert(0, fileName);
            General_Config.SaveGeneralConfig();
        }

        public void GetExpandedStatus(TreeNode node, List<string> ExpandedNodes)
        {
            //check if node is expanded
            if (node.IsExpanded)
                ExpandedNodes.Add(node.FullPath);
            node.Nodes.Cast<TreeNode>().ToList().ForEach(a => GetExpandedStatus(a, ExpandedNodes));
        }

        /// <summary>
        /// Reloads workpace node environment
        /// </summary>
        /// <param name="save_state"> determines wether the treeview expanded state is preserved</param>
        public void ReloadWorkspace(bool save_state)
        {
            if (save_state)
            {
                ViewState = new Dictionary<string, List<string>>();
                List<string> expandedNodes = new List<string>();
                //get all expanded nodes
                treeViewTargets.Nodes.Cast<TreeNode>().ToList().ForEach(a => GetExpandedStatus(a, expandedNodes));
                //collapse all to reset the treeview
                treeViewTargets.CollapseAll();
                //save expanded node value paths
                ViewState["ExpandedNodes"] = expandedNodes;

            }

            treeViewTargets.Nodes.Clear();
            Main_Instance.Instance.Workspace.TargetTreeView = treeViewTargets;
            Main_Instance.Instance.Workspace.ReloadTreeViewFromTargets();
            Main_Instance.Instance.DrawTreeNodes();
            Main_Instance.Instance.Sync_diagram_positions();
            labelWorkspaceName.Text = Main_Instance.Instance.Workspace.Title;

            if (save_state && ViewState["ExpandedNodes"] != null)
            {

                foreach (string str in (List<string>)ViewState["ExpandedNodes"])
                {
                    String[] fullPath = str.Split(new string[] { treeViewTargets.PathSeparator }, StringSplitOptions.None);
                    TreeNode selected = null;
                    for (int i = 0; i < fullPath.Length; i++)
                    {
                        if (i == 0)
                        {
                            selected = treeViewTargets.Nodes.Cast<TreeNode>().Where(a => a.Text == fullPath[i]).FirstOrDefault();
                        }
                        else
                        {
                            selected = selected.Nodes.Cast<TreeNode>().Where(a => a.Text == fullPath[i]).FirstOrDefault();
                        }
                    }
                    selected.Expand();
                }
            }
            //treeViewTargets.ExpandAll();

        }

        private void AddTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes)
            {
                xNodeList = xmlNode.ChildNodes;


                int xx = Int16.Parse(xmlNode.Attributes.GetNamedItem("x").Value);
                int y = Int16.Parse(xmlNode.Attributes.GetNamedItem("y").Value);
                int colorARGB = Int32.Parse(xmlNode.Attributes.GetNamedItem("color").Value);

                try
                {
                    Main_Instance.Instance.Workspace.TreeViewPositions.Add(treeNode.Text, new Point(xx, y));
                    Main_Instance.Instance.Workspace.TreeViewColors.Add(treeNode.Text, colorARGB);

                }
                catch (Exception)
                {
                    //treeNode.Text += " (1)";
                    int idx = 0;
                    do
                    {
                        idx++;
                    } while (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(treeNode.Text + $" ({idx})"));
                    treeNode.Text += $" ({idx})";
                    Main_Instance.Instance.Workspace.TreeViewPositions.Add(treeNode.Text, new Point(xx, y + 50));
                    Main_Instance.Instance.Workspace.TreeViewColors.Add(treeNode.Text, colorARGB);

                }
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(HttpUtility.HtmlDecode(xNode.Attributes[0].Value)));
                    tNode = treeNode.Nodes[x];
                    AddTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = HttpUtility.HtmlDecode(xmlNode.Attributes[0].Value);
        }

        private void Workplace_panel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Paint_workplace()
        {

        }

        private void ResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenResultsTab();
            /*
            ResultsForm resultsForm = new ResultsForm("File");
            if (!resultsForm.IsDisposed && resultsForm.DialogResult == DialogResult.Retry)
            {
                resultsForm.ShowDialog();

            }
            if (resultsForm.DialogResult == DialogResult.OK)
            {
                ReloadWorkspace(false);
                //Main_Instance.Instance.NodeDiagram.AutoLayout(false);
            }*/
            //resultsForm.ShowDialog();
        }





        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnAutoLayout_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.AutoLayout(true, false);
            foreach (ConditionNode conditionNode in Main_Instance.Instance.NodeDiagram.Nodes)
            {
                Main_Instance.Instance.Workspace.TreeViewPositions[conditionNode.Text] = conditionNode.Position;
            }

        }

        private void BtnBezier_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.Bezier;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void Btn4way_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.FourWay;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void BtnStraight_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.Straight;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.AutoLayout(false, false);
            foreach (ConditionNode conditionNode in Main_Instance.Instance.NodeDiagram.Nodes)
            {
                Main_Instance.Instance.Workspace.TreeViewPositions[conditionNode.Text] = conditionNode.Position;
            }
        }

        private void LabelWorkspaceName_Click(object sender, EventArgs e)
        {

        }

        private void PanelDrawWorkspace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedNode = e.Node;
                if (selectedNode != null)
                {
                    ContextMenu mnu = new ContextMenu();
                    MenuItem myMenuItemChild = new MenuItem("New Empty Child");
                    myMenuItemChild.Click += new EventHandler(MyMenuItem_Click);
                    myMenuItemChild.Shortcut = Shortcut.CtrlN;
                    mnu.MenuItems.Add(myMenuItemChild);
                    if (selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:"))
                    {
                        MenuItem myMenuItemUrl = new MenuItem("Open using");
                        //myMenuItemUrl.Click += new EventHandler(myMenuItem_Click);
                        MenuItem imbedded = new MenuItem("Embedded Browser");
                        imbedded.Click += new EventHandler(MyMenuItem_Click);
                        myMenuItemUrl.MenuItems.Add(imbedded);
                        MenuItem defaultb = new MenuItem("Default Browser");
                        defaultb.Click += new EventHandler(MyMenuItem_Click);
                        myMenuItemUrl.MenuItems.Add(defaultb);
                        mnu.MenuItems.Add(myMenuItemUrl);
                    }
                    MenuItem myMenuItemCtrC = new MenuItem("Copy");
                    myMenuItemCtrC.Click += new EventHandler(MyMenuItem_Click);
                    myMenuItemCtrC.Shortcut = Shortcut.CtrlC;
                    mnu.MenuItems.Add(myMenuItemCtrC);
                    MenuItem myMenuItem2 = new MenuItem("Delete");
                    myMenuItem2.Click += new EventHandler(MyMenuItem_Click);
                    myMenuItem2.Shortcut = Shortcut.Del;
                    mnu.MenuItems.Add(myMenuItem2);
                    MenuItem myMenuItem3 = new MenuItem("Compose Query");
                    myMenuItem3.Click += new EventHandler(MyMenuItem_Click);
                    myMenuItem3.Shortcut = Shortcut.CtrlQ;

                    mnu.MenuItems.Add(myMenuItem3);
                    mnu.MenuItems.Add(myMenuItem2);
                    mnu.Show(treeViewTargets, e.Location);
                    selectedLocation = e.Location;
                }
            }
        }
        private void MyMenuItem_Click(object sender, EventArgs e)
        {
            if (((MenuItem)sender).Text == "Embedded Browser" && selectedNode != null)
            {
                if (selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:"))
                {
                    AddNewTab(selectedNode.Parent != null ? selectedNode.Parent.Text.Substring(0, 8) : selectedNode.Text.Split(':')[1].Substring(2, 10), selectedNode.Text);
                }
            }
            if (((MenuItem)sender).Text == "Default Browser" && selectedNode != null)
            {
                if (selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:"))
                {
                    ResultsForm.OpenUrl(selectedNode.Text);
                }
            }
            else if (((MenuItem)sender).Text == "Copy" && selectedNode != null)
            {
                Clipboard.SetText(treeViewTargets.SelectedNode.Text);
            }
            else if (((MenuItem)sender).Text == "Delete" && selectedNode != null)
            {
                treeViewTargets.Nodes.Remove(selectedNode);
                Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();
                ReloadWorkspace(true);
            }
            else if (((MenuItem)sender).Text == "Compose Query" && selectedNode != null)
            {
                List<TreeNode> selectedNodes = new List<TreeNode>();
                selectedNodes.Add(selectedNode);
                Main_Instance.Instance.Compose_funcion(selectedNodes);
            }
            else if (((MenuItem)sender).Text == "New Empty Child" && selectedNode != null)
            {
                selectedNode.Nodes.Add(new TreeNode("Empty"));
                selectedNode.Expand();
                Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();
                ReloadWorkspace(true);
            }
            else
            {
                //Main_Instance.Instance.Workspace.findTarget(((MenuItem)sender).Text).TreeNodes.Add(selectedNode);
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

        private void TreeViewTargets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<Node> selected = new List<Node>();
            Node node = Main_Instance.Instance.NodeDiagram.Nodes.Where(x => x.Text.Equals(e.Node.Text)).FirstOrDefault();
            selected.Add(node);
            selected = Iterate_parents(node, selected);

            Main_Instance.Instance.NodeDiagram.SelectedObjects.Clear();
            Main_Instance.Instance.NodeDiagram.SelectedObjects.UnionWith(selected);
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private List<Node> Iterate_parents(Node node, List<Node> selected)
        {
            if (node != null && node.ParentNodes.Count > 0)
            {
                selected.Add(node.ParentNodes.FirstOrDefault());
                selected = Iterate_parents(node.ParentNodes.FirstOrDefault(), selected);
            }
            return selected;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //openFile("MCIF.workspace.xml");
        }

        private void ShowTips()
        {
            if (!General_Config.skip_tips)
            {
                TipWindow tipWindow = new TipWindow(1);
                tipWindow.ShowDialog();
            }
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            if (TabClosing)
            {
                TabClosing = false;
                e.Cancel = true;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    /*this.DialogResult = DialogResult.OK;
                    for (int x = 0; x < Application.OpenForms.Count; x++)
                    {
                        if (Application.OpenForms[x] != this)
                            Application.OpenForms[x].Close();
                    }
                    return;*/
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        }

        private void modulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show_Modules report_Modules = new Show_Modules(General_Config.Module_Type.Report);
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

        private void btnColapse_Click(object sender, EventArgs e)
        {
            treeViewTargets.CollapseAll();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeViewTargets.ExpandAll();

        }

        private void btnHDPIEnable_Click(object sender, EventArgs e)
        {
            Cef.EnableHighDPISupport();
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = true;

            fontDialog1.Font = Main_Instance.Instance.NodeDiagram.Font;
            //fontDialog1.Color = Main_Instance.Instance.NodeDiagram.Font.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Main_Instance.Instance.NodeDiagram.Font = fontDialog1.Font;
                Main_Instance.Instance.NodeDiagram.Redraw();
                //textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void slideWidth_Scroll(object sender, EventArgs e)
        {
            Size size = Main_Instance.Instance.NodeDiagram.NodeSize;
            size.Width = Base_Box_Size.Width + ((TrackBar)sender).Value;
            Main_Instance.Instance.NodeDiagram.NodeSize = size;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void slideHeight_Scroll(object sender, EventArgs e)
        {
            Size size = Main_Instance.Instance.NodeDiagram.NodeSize;
            size.Height = Base_Box_Size.Height + ((TrackBar)sender).Value;
            Main_Instance.Instance.NodeDiagram.NodeSize = size;
            Main_Instance.Instance.NodeDiagram.Redraw();
        }

        private void btnResetBoxes_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.NodeSize = Base_Box_Size;
            Main_Instance.Instance.NodeDiagram.Redraw();
            slideHeight.Value = 0;
            slideWidth.Value = 0;
        }

        private void onDrawTabs(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString(this.tabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            if (e.Index > 0)
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            }
        }

        private void MouseDownTabs(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < this.tabControl.TabPages.Count; i++)
            {
                Rectangle r = tabControl.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.tabControl.TabPages[i].Controls[0] is ChromiumWebBrowser)
                        {
                            ChromiumWebBrowser browser = (ChromiumWebBrowser)this.tabControl.TabPages[i].Controls[0];
                            browser.Dispose();
                        }
                        this.TabClosing = true;
                        this.tabControl.TabPages.RemoveAt(i);
                        //break;
                    }
                }
            }
        }
        public void AddNewTab(string title_str, string url)
        {
            string title = title_str;// + (tabControl.TabCount + 1).ToString();
            if (title.Length > 10)
                title = title.Substring(0, 10);
            TabPage myTabPage = new TabPage(title);
            tabControl.TabPages.Add(myTabPage);
            SetTabHeader(myTabPage, Color.White);

            var browser = new ChromiumWebBrowser(url);
            browser.Dock = DockStyle.Fill;
            myTabPage.Controls.Add(browser);
            //browser.Load(e.Node.Text);
        }

        private void allModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modules_All_Form modules_All_Form = new Modules_All_Form();
            modules_All_Form.ShowDialog();

        }

        private void OnKeyDownTreeView(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && treeViewTargets.SelectedNode != null)
            {
                treeViewTargets.Nodes.Remove(treeViewTargets.SelectedNode);
                Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();
                ReloadWorkspace(true);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.N)
            {
                if (Control.ModifierKeys == Keys.Control && treeViewTargets.SelectedNode != null)
                {
                    //New Child
                    treeViewTargets.SelectedNode.Nodes.Add(new TreeNode("Empty"));
                    treeViewTargets.SelectedNode.Expand();
                    Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();
                    ReloadWorkspace(true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                }
            }
            if (e.KeyCode == Keys.C)
            {
                if (Control.ModifierKeys == Keys.Control && treeViewTargets.SelectedNode != null)
                {
                    //Copy text CTRL+C
                    Clipboard.SetText(treeViewTargets.SelectedNode.Text);

                    e.Handled = true;
                    e.SuppressKeyPress = true;


                }
            }
            if (e.KeyCode == Keys.Q && Control.ModifierKeys == Keys.Control && treeViewTargets.SelectedNode != null)
            {
                //CTRL + Q
                List<TreeNode> selectedNodes = new List<TreeNode>();
                selectedNodes.Add(treeViewTargets.SelectedNode);
                Main_Instance.Instance.Compose_funcion(selectedNodes);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnHorizontalIntuitive_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.AutoLayout(false, true);
            foreach (ConditionNode conditionNode in Main_Instance.Instance.NodeDiagram.Nodes)
            {
                Main_Instance.Instance.Workspace.TreeViewPositions[conditionNode.Text] = conditionNode.Position;
            }
        }

        private void DoubleClickTreeView(object sender, MouseEventArgs e)
        {
            selectedNode = treeViewTargets.SelectedNode;
            if (selectedNode != null && (selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:")))
            {
                string tab_title = selectedNode.Parent != null ? selectedNode.Parent.Text : "";
                try
                {
                    //tab_title = selectedNode.Parent != null ? selectedNode.Parent.Text.Substring(0, 8) : selectedNode.Text.Split(':')[1].Substring(2, 10);
                }
                catch (Exception ex)
                {

                }
                AddNewTab(tab_title, selectedNode.Text);
            }
        }

        private void configToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurationsForm configurationsForm = new ConfigurationsForm();
            var result = configurationsForm.ShowDialog();
            if (result == DialogResult.OK)
            {

            }
            else
            {

            }
        }

        private void btnRecolor_Click(object sender, EventArgs e)
        {
            General_Config.Recolor(Main_Instance.Instance.Workspace.TargetTreeView, true, true);
            ReloadWorkspace(true);
        }
        public void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            tabControl.Invalidate();
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            ReloadWorkspace(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchModulesForm modulesForm = new SearchModulesForm();
            var result = modulesForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ReloadWorkspace(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Show_Modules report_Modules = new Show_Modules(General_Config.Module_Type.Report);
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

        private void btnOpenResult_Click(object sender, EventArgs e)
        {
            OpenResultsTab();
        }
        private void OpenResultsTab()
        {
            ResultsForm frm = new ResultsForm("File");
            if (frm.DialogResult != DialogResult.Cancel)
            {
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                TabPage myTabPage = new TabPage("Results");
                myTabPage.Controls.Add(frm);
                myTabPage.Padding = new System.Windows.Forms.Padding(3);
                myTabPage.BackColor = System.Drawing.Color.DodgerBlue;

                this.tabControl.TabPages.Add(myTabPage);
                this.tabControl.SelectedTab = Main_Instance.Instance.MainForm_Instance.tabControl.TabPages[Main_Instance.Instance.MainForm_Instance.tabControl.TabPages.Count - 1];
                this.SetTabHeader(myTabPage, Color.DodgerBlue);
            }
        }
    }
}
