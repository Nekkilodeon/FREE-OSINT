using FREE_OSINT;
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
        Dictionary<String, Int32> treeViewColors;

        public Workspace()
        {
            Targets = new List<Target>();
            Targets.Add(new Target("Unassigned"));
            TargetTreeView = new TreeView();
            TreeViewPositions = new Dictionary<String, Point>();
            TreeViewColors = new Dictionary<String, Int32>();
            Title = "Untitled";
            this.reloadTreeViewFromTargets();
        }


        public List<Target> Targets { get => targets; set => targets = value; }
        public string Title { get => title; set => title = value; }
        public TreeView TargetTreeView { get => targetTreeView; set => targetTreeView = value; }
        public Dictionary<String, Point> TreeViewPositions { get => treeViewPositions; set => treeViewPositions = value; }
        public Dictionary<string, int> TreeViewColors { get => treeViewColors; set => treeViewColors = value; }

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

        public void reloadTreeViewFromTargets()
        {
            targetTreeView.Nodes.Clear();
            foreach (Target target in Targets)
            {
                TreeNode node = new TreeNode(target.Title, target.TreeNodesCloned().ToArray());
                targetTreeView.Nodes.Add(node);
            }
            targetTreeView = General_Config.Recolor(targetTreeView, true);
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

        public Object find_node(string text)
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
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode subnode in node.Nodes)
                {
                    TreeNode sub = recursive_find_node(subnode, text);
                    if (sub != null)
                    {
                        return sub;
                    }
                }
            }
            return null;
        }


    }





}
