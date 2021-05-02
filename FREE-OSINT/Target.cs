using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FREE_OSINT_Lib
{
    public class Target
    {
        List<TreeNode> treeNodes;
        String title = "";
        public Target()
        {
            TreeNodes = new List<TreeNode>();
        }
        public Target(string title)
        {
            TreeNodes = new List<TreeNode>();
            this.Title = title;
        }
        public Target(string title, TreeNode firstNode)
        {
            TreeNodes = new List<TreeNode>();
            TreeNodes.Add(firstNode);
            this.Title = title;
        }

        public bool AddNode(TreeNode node)
        {
            foreach (TreeNode sub in treeNodes)
            {
                if (FindNode(node, sub) != null)
                {
                    return false;
                }
            }
            treeNodes.Add(node);
            return true;
        }

        private TreeNode FindNode(TreeNode node, TreeNode sub)
        {
            TreeNode found = null;
            if (sub.Text.Equals(node.Text))
            {
                return sub;
            }
            if (sub.Nodes.Count > 0)
            {
                foreach (TreeNode treeNode in sub.Nodes)
                {
                    found = FindNode(node, treeNode);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return found;
        }

        public void RemoveNode(TreeNode node)
        {
            treeNodes.Remove(node);
        }
        public void RemoveNode(int index)
        {
            treeNodes.RemoveAt(index);
        }
        public override string ToString()
        {
            return Title;
        }

        public string Title { get => title; set => title = value; }
        public List<TreeNode> TreeNodes { get => treeNodes; set => treeNodes = value; }

        public List<TreeNode> TreeNodesCloned()
        {
            List<TreeNode> cloned = new List<TreeNode>();
            foreach (TreeNode treeNode in TreeNodes)
            {
                cloned.Add((TreeNode)treeNode.Clone());
            }
            return cloned;
        }
    }
}
