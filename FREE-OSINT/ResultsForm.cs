using CefSharp;
using CefSharp.WinForms;
using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;


namespace FREE_OSINT
{
    public partial class ResultsForm : Form
    {

        private StreamWriter sr;
        public List<TreeNode> results;
        private TreeNode selectedNode;
        private Point selectedLocation;
        private ChromiumWebBrowser browser;

        public ResultsForm()
        {
            InitializeComponent();
            DesignTreeView();
        }



        public ResultsForm(string file)
        {
            results = new List<TreeNode>();
            InitializeComponent();
            this.btnBrowser.Image = (Image)(new Bitmap(btnBrowser.Image, new Size(15, 15)));
            populateTreeview();
            DesignTreeView();
            browser = new ChromiumWebBrowser("");
            browser.Dock = DockStyle.Fill;
            panelBrowser.Controls.Add(browser);
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;

            if (this.DialogResult == DialogResult.Cancel)
            {
                //this.Close();
            }
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            txtURL.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                txtURL.Text = e.Address;

            });
            //throw new NotImplementedException();
        }

        private void DesignTreeView()
        {

        }

        /*
        private void readExcelResults(string file)
        {
            var excelAplication = new Excel.Application();
            excelAplication.Visible = true;
            Workbook excelnewWorkbook = excelAplication.Workbooks.Open(file);
            try
            {

                excelnewWorkbook = excelAplication.ActiveWorkbook;
                Worksheet worksheet = excelnewWorkbook.Sheets[1];

                // Find the last real row
                int lastUsedRow = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                // Find the last real column
                int lastUsedColumn = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;

                List<TreeNode> mudule_tree = new List<TreeNode>();
                //Get the used Range
                Excel.Range usedRange = worksheet.UsedRange;

                //Iterate the rows in the used range
                String[,] matrix = new String[lastUsedRow + 1, lastUsedColumn + 1];
                int rowIdx = 0;
                foreach (Excel.Range row in usedRange.Rows)
                {
                    String rowData = "";
                    for (int i = 0; i < row.Columns.Count; i++)
                    {
                        matrix[rowIdx, i] = Convert.ToString(row.Cells[1, i + 1].Value2);
                        rowData += matrix[rowIdx, i];
                    }
                    log(rowData);
                    rowIdx++;
                }
                List<TreeNode> trees = matrixToTreeNode(matrix);
                treeViewResults.Nodes.AddRange(trees.ToArray());
            }
            catch (Exception e)
            {
                log(e.Message);
            }
            excelnewWorkbook.Close();
            excelAplication.Quit();




        }
        */
        /*

        private List<TreeNode> matrixToTreeNode(string[,] matrix)
        {
            List<TreeNode> modules = new List<TreeNode>();
            int length = matrix.GetLength(1);
            modules = getSubNodes(0, 0, matrix);
            int capacity = modules.Capacity;
            return modules;
        }
        */

        private bool hasSubTree(int row, int column, string[,] matrix)
        {
            if (matrix[row + 1, column] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void log(String message)
        {
            txtLogs.Text += Environment.NewLine;
            txtLogs.Text += message;
        }

        public ResultsForm(List<SearchResult> searchResults)
        {
            InitializeComponent();
            populateTreeView(searchResults);

            browser = new ChromiumWebBrowser("");
            panelBrowser.Controls.Add(browser);
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
        }
        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);
            SetIsLoading(args.CanReload);
        }

        private void SetIsLoading(bool v)
        {
            btnReload.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                btnReload.Enabled = v;

            });
        }

        private void SetCanGoForward(bool canGoForward)
        {
            btnForward.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                btnForward.Enabled = canGoForward;

            });
        }

        private void SetCanGoBack(bool canGoBack)
        {
            btnBack.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                btnBack.Enabled = canGoBack;

            });
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
            labelURLTitle.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                labelURLTitle.Text = e.Title;

            });
            //txtURL.Text = e.Title;
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }


        private void populateTreeView(List<SearchResult> searchResults)
        {
            int count = 0;
            foreach (SearchResult result in searchResults)
            {
                if (result.Treenode != null)
                {
                    result.Treenode.BackColor = Color.LightSlateGray;
                    result.Treenode.ForeColor = Color.White;
                    if (result.Treenode.Nodes.Count > 0)
                        foreach (TreeNode treeNode in result.Treenode.Nodes)
                        {
                            paintSubNodes(treeNode);

                        }
                    if (result.Treenode.Nodes.Count > 0)
                        treeViewResults.Nodes.Add(result.Treenode);
                }
                if (result.Intels != null && result.Intels.Count > 0)
                {
                    List<TreeNode> treeNodes = parseIntels(result.Intels);
                    TreeNode node = new TreeNode(result.Title, treeNodes.ToArray());
                    node.BackColor = Color.LightSlateGray;
                    node.ForeColor = Color.White;
                    if (node.Nodes.Count > 0)
                        foreach (TreeNode treeNode in node.Nodes)
                        {
                            paintSubNodes(treeNode);

                        }
                    treeViewResults.Nodes.Add(node);

                }
                count += treeViewResults.GetNodeCount(true);
            }
            labelNodeCount.Text = "Total nodes: " + count;
        }

        private List<TreeNode> parseIntels(List<Intel> intels)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (Intel intel in intels)
            {
                List<TreeNode> sub = new List<TreeNode>();
                sub.Add(new TreeNode(intel.Description));
                sub.Add(new TreeNode(intel.Uri.ToString()));
                sub.Add(new TreeNode(intel.Timestamp.ToString()));
                TreeNode node = new TreeNode(intel.Title, sub.ToArray());
                nodes.Add(node);
            }

            return nodes;
        }

        private void paintSubNodes(TreeNode treenode)
        {
            if (treenode.Nodes.Count > 0)
            {
                treenode.BackColor = Color.LightGray;
                foreach (TreeNode node in treenode.Nodes)
                {
                    paintSubNodes(node);
                }
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenUrl(txtURL.Text);
            }
            catch (Exception ex)
            {
                log(ex.Message);
            }
            //txtURL.Text
        }
        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void treeViewResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                if (e.Node.Text.Contains("http:") || e.Node.Text.Contains("https:"))
                {
                    browser.Load(e.Node.Text);
                    txtURL.Text = e.Node.Text;
                    //MessageBox.Show(e.Node.Nodes.Count + "");
                }
            }

            //
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File xml|*.xml";
            saveFileDialog1.Title = "Save results to XML file";
            var filePath = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exportToXml(treeViewResults, saveFileDialog1.FileName);
            }
        }

        /*
        private static void saveCurrentResults(TreeView treeViewResults)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel xlsx|*.xlsx";
            saveFileDialog1.Title = "Save dataset xlsx file";
            var filePath = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = saveFileDialog1.FileName;

                var excelAplication = new Excel.Application();
                excelAplication.Visible = true;

                Workbook excelnewWorkbook = excelAplication.Workbooks.Add();
                excelnewWorkbook = excelAplication.ActiveWorkbook;
                excelnewWorkbook.Worksheets.Add();
                Worksheet worksheet = excelnewWorkbook.Sheets[1];

                int count = excelnewWorkbook.Worksheets.Count;
                if (count > 0)
                {
                    int rowCounter = 0;
                    RecurseNodes(treeViewResults.Nodes, 1);

                    void RecurseNodes(TreeNodeCollection currentNode, int col)
                    {
                        foreach (TreeNode node in currentNode)
                        {
                            rowCounter = rowCounter + 1;
                            worksheet.Cells[rowCounter, col].Value = node.Text;
                            if (node.FirstNode != null)
                                RecurseNodes(node.Nodes, col + 1);
                        }
                    }
                }
                excelnewWorkbook.SaveAs(filePath, AccessMode: XlSaveAsAccessMode.xlNoChange);
                excelnewWorkbook.Close();
                excelAplication.Quit();
            }
        }
        */

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            populateTreeview();
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public void exportToXml(TreeView tv, string filename)
        {
            String[] split = filename.Split('.');
            string newFilename = "";
            for (int i = 0; i < split.Length; i++)
            {
                if (i == split.Length - 1 && !split[i - 1].Equals("result"))
                {
                    newFilename += "result." + split[i];
                }
                else
                {
                    newFilename += split[i] + ".";
                }
            }
            sr = new StreamWriter(newFilename, false, System.Text.Encoding.UTF8);
            //Write the header
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr.WriteLine("<Node value=\"" + HttpUtility.HtmlEncode(treeViewResults.Nodes[0].Text) + "\">");
            foreach (TreeNode node in tv.Nodes)
            {
                saveNode(node.Nodes);
            }
            //Close the root node
            sr.WriteLine("</Node>");
            sr.Close();
        }

        private void saveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    sr.WriteLine("<Node value=\"" + HttpUtility.HtmlEncode(node.Text) + "\">");
                    saveNode(node.Nodes);
                    sr.WriteLine("</Node>");
                }
                else
                    sr.WriteLine("<Node value=\"" + HttpUtility.HtmlEncode(node.Text) + "\"></Node>");
            }
        }

        private void populateTreeview()
        {
            results = new List<TreeNode>();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Results XML Document";
            dlg.Filter = "XML Files (*.xml)|*result.xml";
            dlg.FileName = Application.StartupPath + "\\..\\..\\example.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.DialogResult = DialogResult.Retry;
                    //Just a good practice -- change the cursor to a 
                    //wait cursor while the nodes populate
                    this.Cursor = Cursors.WaitCursor;
                    //First, we'll load the Xml document
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(dlg.FileName);
                    //Now, clear out the treeview, 
                    //and add the first (root) node
                    treeViewResults.Nodes.Clear();
                    TreeNode result = new TreeNode(HttpUtility.HtmlDecode(xDoc.DocumentElement.GetAttribute("value")));
                    result.BackColor = Color.LightSlateGray;
                    result.ForeColor = Color.White;
                    treeViewResults.Nodes.Add(result);
                    TreeNode tNode = new TreeNode();
                    tNode = (TreeNode)treeViewResults.Nodes[0];
                    //We make a call to addTreeNode, 
                    //where we'll add all of our nodes
                    addTreeNode(xDoc.DocumentElement, tNode);
                    //Expand the treeview to show all nodes
                    labelNodeCount.Text = "Total nodes: " + treeViewResults.GetNodeCount(true);
                    //treeViewResults.ExpandAll();
                }
                catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
                {
                    //MessageBox.Show();
                    txtLogs.AppendText(xExc.Message);
                }
                catch (Exception ex) //General exception
                {
                    txtLogs.AppendText(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default; //Change the cursor back
                }
            }
            else
            {
                //this.DialogResult = DialogResult.Cancel;
            }
        }
        //This function is called recursively until all nodes are loaded
        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
            {

                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(HttpUtility.HtmlDecode(xNode.Attributes[0].Value)));
                    tNode = treeNode.Nodes[x];
                    tNode.BackColor = Color.LightGray;
                    addTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
            {
                treeNode.Text = HttpUtility.HtmlDecode(xmlNode.Attributes[0].Value);
                treeNode.BackColor = Color.White;
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSendToGraph_Click(object sender, EventArgs e)
        {

            foreach (TreeNode treeNode in treeViewResults.Nodes)
            {
                results.Add(treeNode);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        private void mouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                selectedNode = e.Node;
                if (selectedNode != null)
                {

                    ContextMenu mnu = new ContextMenu();
                    MenuItem myMenuItem = new MenuItem("Insert");
                    mnu.MenuItems.Add(myMenuItem);
                    myMenuItem.Click += new EventHandler(myMenuItem_Click);

                    MenuItem myMenuItem3 = new MenuItem("Open URL");
                    myMenuItem3.Click += new EventHandler(myMenuItem_Click);
                    mnu.MenuItems.Add(myMenuItem3);

                    MenuItem mnuItemChromium = new MenuItem("Chromium");
                    mnuItemChromium.Click += new EventHandler(myMenuItem_Click);
                    myMenuItem3.MenuItems.Add(mnuItemChromium);
                    MenuItem mnuPredefinedBrowser = new MenuItem("Predefined Browser");
                    mnuPredefinedBrowser.Click += new EventHandler(myMenuItem_Click);
                    myMenuItem3.MenuItems.Add(mnuPredefinedBrowser);


                    MenuItem myMenuItem4 = new MenuItem("Process Module");
                    myMenuItem4.Click += new EventHandler(myMenuItem_Click);
                    mnu.MenuItems.Add(myMenuItem4);

                    (mnu.MenuItems[0] as MenuItem).MenuItems.Add("New Target");
                    (mnu.MenuItems[0] as MenuItem).MenuItems[0].Click += new EventHandler(myMenuItem_Click);
                    int i = 1;
                    foreach (Target target in Main_Instance.Instance.Workspace.Targets)
                    {
                        (mnu.MenuItems[0] as MenuItem).MenuItems.Add(target.Title);
                        (mnu.MenuItems[0] as MenuItem).MenuItems[i].Click += new EventHandler(myMenuItem_Click);
                        i++;
                    }
                    MenuItem myMenuItem2 = new MenuItem("Remove");
                    myMenuItem2.Click += new EventHandler(myMenuItem_Click);
                    mnu.MenuItems.Add(myMenuItem2);

                    mnu.Show(treeViewResults, e.Location);
                    selectedLocation = e.Location;
                }

            }
        }

        private void myMenuItem_Click(object sender, EventArgs e)
        {

            if (((MenuItem)sender).Text == "Remove" && selectedNode != null)
            {
                treeViewResults.Nodes.Remove(selectedNode);
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
            else if (((MenuItem)sender).Text == "Process Module" && selectedNode != null)
            {
                Show_Modules process_Modules = new Show_Modules(General_Config.Module_Type.Process);
                var result = process_Modules.ShowDialog();
                if (result == DialogResult.OK)
                {
                    IProcessing_Module process_Module = (IProcessing_Module)process_Modules.selected_module;
                    treeViewResults.Nodes.Add(process_Module.Process(selectedNode));
                }
                else
                {
                    process_Modules.Hide();
                }
            }
            else if (((MenuItem)sender).Text == "Predefined Browser" && selectedNode != null)
            {
                if (selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:"))
                {
                    //webBrowser1.Url = new Uri(selectedNode.Text);
                    //txtURL.Text = selectedNode.Text;
                    OpenUrl(selectedNode.Text);
                    //MessageBox.Show(e.Node.Nodes.Count + "");
                }
                else
                {
                    string url = dig_node_for_url(selectedNode);
                    if (url != null)
                    {
                        OpenUrl(url);
                    }
                }
            }
            else if (((MenuItem)sender).Text == "Chromium" && selectedNode != null)
            {
                if (selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:"))
                {
                    browser.Load(selectedNode.Text);
                }
                else
                {
                    string url = dig_node_for_url(selectedNode);
                    if (url != null)
                    {
                        browser.Load(url);
                    }
                }
            }
            else
            {
                Main_Instance.Instance.Workspace.findTarget(((MenuItem)sender).Text).TreeNodes.Add(selectedNode);
            }
        }

        private string dig_node_for_url(TreeNode selectedNode)
        {
            if ((selectedNode.Text.Contains("http:") || selectedNode.Text.Contains("https:")))
            {
                return selectedNode.Text;
            }
            else if (selectedNode.Nodes.Count > 0)
            {
                foreach (TreeNode treeNode in selectedNode.Nodes)
                {
                    string url = dig_node_for_url(treeNode);
                    if (url != null)
                    {
                        return url;
                    }
                }
            }
            return null;

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtURL.Text = ((WebBrowser)sender).Url.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (browser.Text == null)
            {
                MessageBox.Show("Invalid URL");
            }
            else
            {
                SimpleInputForm newTargetForm = new SimpleInputForm(labelURLTitle.Text, txtURL.Text /*webBrowser1.Document.Title, webBrowser1.Url.ToString()*/);
                newTargetForm.Location = selectedLocation;
                newTargetForm.ShowDialog();
                if (newTargetForm.DialogResult == DialogResult.OK)
                {
                    if (newTargetForm.title != "")
                    {


                    }
                    //Main_Instance.Instance.Workspace.
                }
            }
        }


        private void ResultsForm_Load(object sender, EventArgs e)
        {

        }
        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Workspace workspace = Main_Instance.Instance.Workspace;
                this.DialogResult = DialogResult.OK;
                Main_Instance.Instance.Workspace.generateTreeViewFromTargets();
                this.treeViewResults.Nodes.Clear();
            }
            else if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void panelBrowser_Paint(object sender, PaintEventArgs e)
        {
        }
    }

}
