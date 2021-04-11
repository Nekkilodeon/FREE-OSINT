using FREE_OSINT_Lib;
using NodeControl;
using NodeControl.Nodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    public class Main_Instance
    {
        private static Main_Instance instance = null;
        private NodeDiagram nodeDiagram;
        private static readonly object padlock = new object();
        private Workspace workspace;
        private General_Config config;
        Dictionary<General_Config.Module_Type, List<IGeneral_module>> module_list;

        Main_Instance()
        {
            workspace = new Workspace();
            NodeDiagram = new NodeDiagram();
            Module_list = new Dictionary<General_Config.Module_Type, List<IGeneral_module>>();
            foreach (General_Config.Module_Type key in Enum.GetValues(typeof(General_Config.Module_Type)))
            {
                Module_list.Add(key, new List<IGeneral_module>());
            }
            NodeDiagram.DiagramEvent += NodeDiagram_DiagramEvent;
            Config = new General_Config();
        }

        private void NodeDiagram_DiagramEvent(object sender, EventArgs e)
        {
            //NodeDiagram nodeDiagram = sender as NodeDiagram;
            NodeDiagram.DiagramEventArgs diagramEventArgs = e as NodeDiagram.DiagramEventArgs;
            if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.COLOR)
            {
                foreach (INodeObject node in diagramEventArgs.SelectedObjects)
                {
                    ConditionNode conditionNode = node as ConditionNode;
                    if (Workspace.TreeViewColors.ContainsKey(conditionNode.Text))
                    {
                        Workspace.TreeViewColors[conditionNode.Text] = ((Color)diagramEventArgs.operation_attribute).ToArgb();
                    }
                    else
                    {
                        Workspace.TreeViewColors.Add(conditionNode.Text, ((Color)diagramEventArgs.operation_attribute).ToArgb());

                    }
                }
            }
            else if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.DRAG)
            {
                foreach (INodeObject node in diagramEventArgs.SelectedObjects)
                {
                    ConditionNode conditionNode = node as ConditionNode;
                    Workspace.TreeViewPositions[conditionNode.Text] = conditionNode.Position;
                }
            }
            else if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.COMPOSE)
            {
                //COMPOSE
                List<TreeNode> selectedNodes = new List<TreeNode>();
                foreach (INodeObject node in diagramEventArgs.SelectedObjects)
                {
                    TreeNode selected_node = (TreeNode)Workspace.find_node(((ConditionNode)node).Text);
                    selectedNodes.Add(selected_node);
                    //Workspace.find_remove(((ConditionNode)node).Text);
                }
                compose_funcion(selectedNodes);
            }
            else if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.REMOVE)
            {
                foreach (INodeObject node in diagramEventArgs.SelectedObjects)
                {
                    TreeNode selected_node = (TreeNode)Workspace.find_node(((ConditionNode)node).Text);
                    if (selected_node != null)
                        Workspace.TargetTreeView.Nodes.Remove(selected_node);
                    //Workspace.find_remove(((ConditionNode)node).Text);
                }
                Workspace.reloadTargetsFromTreeView();
                drawTreeNodes();
            }
            else if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.ADD)
            {
                if (diagramEventArgs.SelectedObjects.First().GetType().Equals(typeof(ConditionNode)))
                {
                    ConditionNode node = (ConditionNode)diagramEventArgs.SelectedObjects.First();
                    if (node.Container_color.Equals(Color.Orange))
                    {
                        Target target = new Target(node.Text);
                        if (node.LinksTo.Count > 0)
                        {
                            List<TreeNode> treeNodes = new List<TreeNode>();
                            foreach (Condition condition in node.LinksTo)
                            {
                                treeNodes.Add(new TreeNode(condition.Text));
                            }
                            target.TreeNodes.AddRange(treeNodes);
                        }
                        Workspace.Targets.Add(target);

                    }
                    else
                    {
                        TreeNode treeNode = new TreeNode(node.Text);
                        if (node.LinksTo.Count > 0)
                        {
                            List<TreeNode> treeNodes = new List<TreeNode>();
                            foreach (Condition condition in node.LinksTo)
                            {
                                treeNodes.Add(new TreeNode(condition.Text));
                            }
                            treeNode = new TreeNode(node.Text, treeNodes.ToArray());
                        }
                        Target unassigned = Workspace.findTarget("Unassigned");
                        unassigned.addNode(treeNode);
                    }
                    Workspace.generateTreeViewFromTargets();
                    drawTreeNodes();
                }
            }
            else if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.LINK)
            {
                ConditionNode first = (ConditionNode)diagramEventArgs.SelectedObjects.First();
                ConditionNode last = (ConditionNode)diagramEventArgs.SelectedObjects.Last();

                TreeNode node1 = (TreeNode)Workspace.find_node(first.Text);
                TreeNode node2 = (TreeNode)Workspace.find_node(last.Text);

                TreeNode backup = (TreeNode)node2.Clone();
                Workspace.TargetTreeView.Nodes.Remove(node2);
                node1.Nodes.Add(backup);
                //node2.

                Workspace.reloadTargetsFromTreeView();
                drawTreeNodes();
            }
            else if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.EDIT)
            {
                ConditionNode node = (ConditionNode)diagramEventArgs.SelectedObjects.First();
                ConditionNode node_new = (ConditionNode)diagramEventArgs.SelectedObjects.Last();

                TreeNode node1 = (TreeNode)Workspace.find_node(node.Text);
                node1.Text = node_new.Text;
                if (node_new.LinksTo.Count > 0)
                {
                    List<TreeNode> treeNodes = new List<TreeNode>();
                    foreach (Condition condition in node_new.LinksTo)
                    {
                        treeNodes.Add(new TreeNode(condition.Text));
                    }
                    node1.Nodes.Clear();
                    node1.Nodes.AddRange(treeNodes.ToArray());
                }
                Workspace.reloadTargetsFromTreeView();
                drawTreeNodes();
            }


        }


        public void compose_funcion(List<TreeNode> selectedNodes)
        {

            List<String> to_query = new List<string>();
            List<TreeNode> targets = new List<TreeNode>();

            DialogResult dialogResult = MessageBox.Show("Use intermediary nodes", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "";
                foreach (TreeNode treeNode in selectedNodes)
                {
                    TreeNode parent = treeNode;
                    if (treeNode.Nodes.Count > 0)
                    {
                        foreach (TreeNode node in treeNode.Nodes)
                        {
                            to_query.Add(node.Text);
                            query += node.Text + " ";
                        }
                    }
                    do
                    {
                        if (!targets.Contains(parent))
                        {
                            query += parent.Text + " ";
                            to_query.Add(parent.Text);
                        }

                        if (parent.Parent == null && !targets.Contains(parent))
                        {
                            targets.Add(parent);
                        }
                        parent = parent.Parent;
                    } while (parent != null);
                }
                dialogResult = MessageBox.Show("Query generated " + query + ", do you wish to edit?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //EDIT QUERY
                    QueryConstructorForm queryConstructorForm = new QueryConstructorForm(to_query, targets);
                    var result = queryConstructorForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //SEND TO MODULE
                        query = queryConstructorForm.final_query;
                        SearchModulesForm searchModulesForm = new SearchModulesForm(query);
                        searchModulesForm.ShowDialog();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //SEND QUERY TO MODULE
                    SearchModulesForm searchModulesForm = new SearchModulesForm(query);
                    searchModulesForm.ShowDialog();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                string query = "";
                foreach (TreeNode treeNode in selectedNodes)
                {

                    if (treeNode.Nodes.Count > 0)
                    {
                        foreach (TreeNode node in treeNode.Nodes)
                        {
                            to_query.Add(node.Text);
                            query += node.Text + " ";
                        }
                    }
                    else
                    {
                        query += treeNode.Text + " ";
                        to_query.Add(treeNode.Text);
                    }

                    TreeNode parent = treeNode;
                    do
                    {
                        if (parent.Parent == null && !targets.Contains(parent))
                        {
                            to_query.Add(parent.Text);
                            query += parent.Text + " ";
                            targets.Add(parent);
                        }
                        parent = parent.Parent;
                    } while (parent != null);
                }
                dialogResult = MessageBox.Show("Query generated " + query + ", do you wish to edit?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //EDIT QUERY
                    QueryConstructorForm queryConstructorForm = new QueryConstructorForm(to_query, targets);
                    var result = queryConstructorForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //SEND TO MODULE
                        query = queryConstructorForm.final_query;
                        SearchModulesForm searchModulesForm = new SearchModulesForm(query);
                        searchModulesForm.ShowDialog();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //SEND QUERY TO MODULE
                    SearchModulesForm searchModulesForm = new SearchModulesForm(query);
                    searchModulesForm.ShowDialog();

                }
            }
        }

        public void drawTreeNodes()
        {
            nodeDiagram.Nodes.Clear();
            foreach (TreeNode treeNode in workspace.TargetTreeView.Nodes)
            {
                drawSubNodes(treeNode, null, nodeDiagram, 0);
            }
            nodeDiagram.Redraw();
        }

        private void drawSubNodes(TreeNode treeNode, ConditionNode prevNode, NodeDiagram nodeDiagram, int level)
        {
            if (treeNode.Nodes.Count > 0)
            {
                Random rnd = new Random(100);
                ConditionNode node = prevNode;
                if (prevNode == null)
                {
                    node = new ConditionNode(nodeDiagram, Color.Orange, true) { Text = treeNode.Text };
                    if (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(node.Text))
                        node.Position = Main_Instance.Instance.Workspace.TreeViewPositions[node.Text];
                    if (Main_Instance.Instance.Workspace.TreeViewColors.ContainsKey(node.Text))
                    {
                        node.Container_color = Color.FromArgb(Main_Instance.Instance.Workspace.TreeViewColors[node.Text]);
                    }
                }

                foreach (TreeNode subnode in treeNode.Nodes)
                {
                    if (subnode.Nodes.Count > 0)
                    {
                        var node2 = new ConditionNode(nodeDiagram,
                            level == 0 ? Color.Cyan : level == 1 ? Color.DarkGray : Color.Gray
                            , false)
                        { Text = subnode.Text };

                        if (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(node2.Text))
                            node2.Position = Main_Instance.Instance.Workspace.TreeViewPositions[node2.Text];
                        else
                        {
                            if (subnode.Parent != null && Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(subnode.Parent.Text))
                            {
                                node2.Position = Main_Instance.Instance.Workspace.TreeViewPositions[subnode.Parent.Text];
                                node2.Position = new Point(node2.Position.X, node2.Position.Y + node2.NodeSize.Height);
                                Main_Instance.Instance.Workspace.TreeViewPositions.Add(node2.Text, node2.Position);
                            }
                            // 
                        }
                        if (Main_Instance.Instance.Workspace.TreeViewColors.ContainsKey(node2.Text))
                        {
                            node2.Container_color = Color.FromArgb(Main_Instance.Instance.Workspace.TreeViewColors[node2.Text]);
                        }
                        node.LinksTo.Add(new Condition() { LinksTo = node2 });
                        nodeDiagram.Nodes.Add(node2);
                        drawSubNodes(subnode, node2, nodeDiagram, level + 1);
                    }
                    else
                    {
                        node.LinksTo.Add(new Condition() { Text = subnode.Text });
                    }
                }
                if (prevNode == null)
                    nodeDiagram.Nodes.Add(node);
                return;
            }
            else
            {
                if (prevNode == null)
                {
                    ConditionNode node = new ConditionNode(nodeDiagram, Color.Orange, true) { Text = treeNode.Text };
                    if (Main_Instance.Instance.Workspace.TreeViewPositions.ContainsKey(node.Text))
                        node.Position = Main_Instance.Instance.Workspace.TreeViewPositions[node.Text];
                    nodeDiagram.Nodes.Add(node);

                }
            }
            return;
        }

        public static Main_Instance Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Main_Instance();
                    }
                    return instance;
                }
            }
        }

        public Workspace Workspace { get => workspace; set => workspace = value; }
        public NodeDiagram NodeDiagram { get => nodeDiagram; set => nodeDiagram = value; }
        public General_Config Config { get => config; set => config = value; }
        public Dictionary<General_Config.Module_Type, List<IGeneral_module>> Module_list { get => module_list; set => module_list = value; }

        public void sync_diagram_positions()
        {
            if (Workspace.TreeViewPositions.Count > 0)
            {
                foreach (Node node in nodeDiagram.Nodes)
                {
                    if (Workspace.TreeViewPositions.ContainsKey(node.Text))
                    {
                        Point point = Workspace.TreeViewPositions[node.Text];
                        node.Position = point;
                    }
                }
            }
            if (Workspace.TreeViewColors.Count > 0)
            {
                foreach (Node node in nodeDiagram.Nodes)
                {
                    if (Workspace.TreeViewColors.ContainsKey(node.Text))
                    {
                        Color container = Color.FromArgb(Workspace.TreeViewColors[node.Text]);
                        ((ConditionNode)node).Container_color = container;
                    }
                }
            }
        }

        public void populate_position_dictionary()
        {
            foreach (Node node in nodeDiagram.Nodes)
            {
                workspace.TreeViewPositions.Add(node.Text, node.Position);
            }
        }
    }
}
