﻿using FREE_OSINT_Lib;
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

        Main_Instance()
        {
            workspace = new Workspace();
            NodeDiagram = new NodeDiagram();
            NodeDiagram.DiagramEvent += NodeDiagram_DiagramEvent;
            Config = new General_Config();
        }

        private void NodeDiagram_DiagramEvent(object sender, EventArgs e)
        {
            //NodeDiagram nodeDiagram = sender as NodeDiagram;
            NodeDiagram.DiagramEventArgs diagramEventArgs = e as NodeDiagram.DiagramEventArgs;
            if (diagramEventArgs.Operation == NodeDiagram.DiagramEventArgs.Operation_Type.REMOVE)
            {
                foreach (INodeObject node in diagramEventArgs.SelectedObjects)
                {
                    TreeNode selected_node = (TreeNode)Workspace.find_node(((ConditionNode)node).Text);
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
                    if (node.Container_color.Equals(Color.Red))
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


        }

        public void drawTreeNodes()
        {
            nodeDiagram.Nodes.Clear();
            foreach (TreeNode treeNode in workspace.TargetTreeView.Nodes)
            {
                drawSubNodes(treeNode, null, nodeDiagram, 0);
            }
            foreach (var node in nodeDiagram.Nodes)
            {
                node.Direction = Node.DirectionEnum.Vertical;
            }
            nodeDiagram.AutoLayout(true);
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
                    node = new ConditionNode(nodeDiagram, Color.Red) { Text = treeNode.Text };
                }

                foreach (TreeNode subnode in treeNode.Nodes)
                {
                    if (subnode.Nodes.Count > 0)
                    {
                        var node2 = new ConditionNode(nodeDiagram,
                            level == 0 ? Color.Cyan : level == 1 ? Color.DarkGray : Color.Gray
                            )
                        { Text = subnode.Text };
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
                    ConditionNode node = new ConditionNode(nodeDiagram, Color.Red) { Text = treeNode.Text };
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
    }
}
