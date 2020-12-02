using NodeControl.Nodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FREE_OSINT_Lib
{
    public class Workspace
    {
        List<Target> targets;

        string title;
        TreeView targetTreeView;
        Dictionary<String, Point> treeViewPositions;
        public Workspace()
        {
            Targets = new List<Target>();
            Targets.Add(new Target("Unassigned"));
            TargetTreeView = new TreeView();
            TreeViewPositions = new Dictionary<String, Point>();
            Title = "Untitled";
           
        }


        public List<Target> Targets { get => targets; set => targets = value; }
        public string Title { get => title; set => title = value; }
        public TreeView TargetTreeView { get => targetTreeView; set => targetTreeView = value; }
        public Dictionary<String, Point> TreeViewPositions { get => treeViewPositions; set => treeViewPositions = value; }

        public void reloadTargetsFromTreeView()
        {
            targets = new List<Target>();
            foreach (TreeNode target_node in targetTreeView.Nodes)
            {
                List<TreeNode> subnodes = new List<TreeNode>();
                foreach (TreeNode treeNode in target_node.Nodes)
                {
                    subnodes.Add(treeNode);
                }
                Target target = new Target(target_node.Text);
                target.TreeNodes = subnodes;
                targets.Add(target);
            }
        }

        internal void find_remove(string text)
        {
            foreach (Target target in targets)
            {
                if (target.Title == text)
                {
                    targets.Remove(target);
                    return;
                }
                if (target.TreeNodes.Count > 0)
                {
                    if (find_remove_iterator(target.TreeNodes, text))
                    {
                        return;
                    }
                }
            }
        }

        private bool find_remove_iterator(List<TreeNode> treeNodes, string text)
        {
            foreach (TreeNode treeNode in treeNodes)
            {
                if (treeNode.Text == text)
                {
                    treeNodes.Remove(treeNode);
                    return true;
                }
                if (treeNode.Nodes.Count > 0)
                {
                    if (find_remove_iterator_collection(treeNode.Nodes, text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool find_remove_iterator_collection(TreeNodeCollection treeNodes, string text)
        {
            foreach (TreeNode treeNode in treeNodes)
            {
                if (treeNode.Text == text)
                {
                    treeNodes.Remove(treeNode);
                    return true;
                }
                if (treeNode.Nodes.Count > 0)
                {
                    if (find_remove_iterator_collection(treeNode.Nodes, text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void generateTreeViewFromTargets()
        {
            targetTreeView.Nodes.Clear();
            foreach (Target target in Targets)
            {
                TreeNode node = new TreeNode(target.Title, target.TreeNodesCloned().ToArray());
                targetTreeView.Nodes.Add(node);
            }
            foreach (TreeNode child in targetTreeView.Nodes)
            {
                child.BackColor = Color.Orange;
                if (child.Nodes != null && child.Nodes.Count > 0)
                {
                    foreach (TreeNode subchild in child.Nodes)
                    {
                        subchild.BackColor = Color.Aqua;
                    }

                }
            }
        }

        public Target findTarget(string name)
        {
            foreach (Target target in this.targets)
            {
                if (target.Title == name)
                {
                    return target;
                }
            }
            return null;
        }

        internal Object find_node(string text)
        {
            foreach (TreeNode node in TargetTreeView.Nodes)
            {
                TreeNode found = recursive_find_node(node, text);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }

        private TreeNode recursive_find_node(TreeNode node, string text)
        {
            if (node.Text == text)
            {
                return node;
            }
            if(node.Nodes.Count > 0)
            {
                foreach(TreeNode subnode in node.Nodes)
                {
                    TreeNode sub = recursive_find_node(subnode, text);
                    if(sub != null)
                    {
                        return sub;
                    }
                }
            }
            return null;
        }


    }





}
