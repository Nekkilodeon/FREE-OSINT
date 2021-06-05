using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FREE_OSINT
{
    public class General_Config
    {
        public static string modules_directory = "modules";
        static internal Dictionary<int, Color> ColorsHierarchy;
        internal static string lib_directory = "libs";

        

        public static string Documents_Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "FREE-OSINT");
        public static List<String> recent_workspaces;
        public General_Config()
        {
            ColorsHierarchy = new Dictionary<int, Color>();
            recent_workspaces = new List<string>();
            ColorsHierarchy.Add(0, Color.Orange);
            ColorsHierarchy.Add(1, Color.CornflowerBlue);
            ColorsHierarchy.Add(2, Color.SkyBlue);
            ColorsHierarchy.Add(3, Color.PowderBlue);
            ColorsHierarchy.Add(4, Color.Silver);

            /*
            SubNodes.Add(0, Color.FromArgb(0, 247, 250));
            SubNodes.Add(1, Color.FromArgb(150, 247, 250));
            SubNodes.Add(2, Color.FromArgb(213, 213, 213));*/
        }
        public static void SaveGeneralConfig()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create(Documents_Path + "/config.xml", settings))
            {
                writer.WriteStartElement("config");
                writer.WriteStartElement("colors");
                writer.WriteElementString("first", ColorsHierarchy[0].ToArgb() + "");
                writer.WriteElementString("second", ColorsHierarchy[1].ToArgb() + "");
                writer.WriteElementString("third", ColorsHierarchy[2].ToArgb() + "");
                writer.WriteElementString("fourth", ColorsHierarchy[3].ToArgb() + "");
                writer.WriteElementString("fifth", ColorsHierarchy[4].ToArgb() + "");
                writer.WriteEndElement();
                writer.WriteStartElement("recent");
                if(recent_workspaces.Count > 0)
                {
                    for(int i = 0; i < recent_workspaces.Count; i++)
                    writer.WriteElementString("project", recent_workspaces[i] + "");
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();

            }
        }

        public static TreeView Recolor(TreeView targetTreeView, bool recolorTree = false, bool recolorGraph = false)
        {
            if (ColorsHierarchy != null)
                foreach (TreeNode child in targetTreeView.Nodes)
                {
                    if (recolorTree)
                        child.BackColor = ColorsHierarchy[0];
                    if (recolorGraph)
                    {
                        if (Main_Instance.Instance.Workspace.TreeViewColors.ContainsKey(child.Text))
                            Main_Instance.Instance.Workspace.TreeViewColors[child.Text] = ColorsHierarchy[0].ToArgb();
                        else
                            Main_Instance.Instance.Workspace.TreeViewColors.Add(child.Text, ColorsHierarchy[0].ToArgb());
                    }
                    if (child.Nodes != null && child.Nodes.Count > 0)
                    {
                        List<TreeNode> copy = new List<TreeNode>();

                        foreach (TreeNode subchild in child.Nodes)
                        {
                            copy.Add(Fill_subnode_colors(subchild, 1, recolorTree, recolorGraph));
                        }
                        child.Nodes.Clear();
                        child.Nodes.AddRange(copy.ToArray());
                    }
                }
            return targetTreeView;
        }
        private static TreeNode Fill_subnode_colors(TreeNode subchild, int level, bool recolorTree = false, bool recolorGraph = false)
        {
            if (recolorTree)
                subchild.BackColor = ColorsHierarchy[level];
            if (recolorGraph)
            {
                if (Main_Instance.Instance.Workspace.TreeViewColors.ContainsKey(subchild.Text))
                    Main_Instance.Instance.Workspace.TreeViewColors[subchild.Text] = ColorsHierarchy[level].ToArgb();
                else
                    Main_Instance.Instance.Workspace.TreeViewColors.Add(subchild.Text, ColorsHierarchy[level].ToArgb());
            }
            List<TreeNode> copy = new List<TreeNode>();
            foreach (TreeNode node in subchild.Nodes)
            {
                TreeNode backup = node;
                if (node.Nodes.Count > 0)
                {
                    backup = Fill_subnode_colors(node, level + 1, recolorTree, recolorGraph);
                }
                copy.Add(backup);
            }
            subchild.Nodes.Clear();
            subchild.Nodes.AddRange(copy.ToArray());

            return subchild;
        }
        public enum Module_Type
        {
            Search, Process, Report
        }
    }
}
