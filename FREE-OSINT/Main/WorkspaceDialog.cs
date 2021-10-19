using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FREE_OSINT.Main
{
    public partial class WorkspaceDialog : Form
    {
        List<String> recents;
        public string selected_workspace = "";
        public WorkspaceDialog()
        {
            recents = new List<string>();
            this.CenterToParent();
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            string configFileName = General_Config.Documents_Path + "/config.xml";
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(configFileName);
                XmlNode colors = xDoc.DocumentElement.GetElementsByTagName("colors")[0];
                bool skip_tips = Boolean.Parse(xDoc.DocumentElement.GetElementsByTagName("skip_tips")[0].InnerText);
                General_Config.skip_tips = skip_tips;
                Dictionary<int, Color> ColorsHierarchy = new Dictionary<int, Color>();
                int i = 0;
                foreach (XmlNode color in colors.ChildNodes)
                {
                    Color colorARGB = Color.FromArgb(Int32.Parse(color.InnerText));
                    ColorsHierarchy.Add(i, colorARGB);
                    i++;
                }
                General_Config.ColorsHierarchy = ColorsHierarchy;
                XmlNode recentsXML = xDoc.DocumentElement.GetElementsByTagName("recent")[0];
                foreach (XmlNode recentXML in recentsXML.ChildNodes)
                {
                    recents.Add(recentXML.InnerText);

                }
                General_Config.recent_workspaces = recents;
                if (recents.Count > 0)
                {
                    for (int j = 0; j < recents.Count; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                this.linkLabel1.Text = recents[j].Split('\\')[recents[j].Split('\\').Length - 1];
                                this.linkLabel1.Visible = true;
                                break;
                            case 1:
                                this.linkLabel2.Text = recents[j].Split('\\')[recents[j].Split('\\').Length - 1];
                                this.linkLabel2.Visible = true;
                                break;
                            case 2:
                                this.linkLabel3.Text = recents[j].Split('\\')[recents[j].Split('\\').Length - 1];
                                this.linkLabel3.Visible = true;
                                break;
                            case 3:
                                this.linkLabel4.Text = recents[j].Split('\\')[recents[j].Split('\\').Length - 1];
                                this.linkLabel4.Visible = true;
                                break;
                            case 4:
                                this.linkLabel5.Text = recents[j].Split('\\')[recents[j].Split('\\').Length - 1];
                                this.linkLabel5.Visible = true;
                                break;
                        }
                    }
                }

            }
            catch (Exception e)
            {

            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int idx = Int16.Parse(((LinkLabel)sender).Name.Substring(((LinkLabel)sender).Name.Length - 1)) - 1;
            selected_workspace = recents[idx];
            this.DialogResult = DialogResult.OK;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Main_Instance.Instance.Workspace = new Workspace();
            //OPEN WORKPLACE FILE
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = General_Config.Documents_Path;
            dlg.Title = "Open Workspace XML Document";
            dlg.Filter = "XML Files (*.workspace.xml)|*.workspace.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.selected_workspace = dlg.FileName;
            }
        }
    }
}
