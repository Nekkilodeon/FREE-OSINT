using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FREE_OSINT
{
    using System;
    using CefSharp;
    using System.Windows.Forms;
    using FREE_OSINT_Lib;
    using CefSharp.WinForms;

    public class MyCustomMenuHandler : IContextMenuHandler
    {
        private const int initial_command = 26501;
        private ResultsForm resultsForm;


        public MyCustomMenuHandler(ResultsForm resultsForm)
        {
            this.resultsForm = resultsForm;
        }
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            // Remove any existent option using the Clear method of the model
            //
            //model.Clear();

            Console.WriteLine("Context menu opened !");

            // You can add a separator in case that there are more items on the list
            if (model.Count > 0)
            {
                model.AddSeparator();
            }


            // Add a new item to the list using the AddItem method of the model
            model.AddSubMenu((CefMenuCommand)initial_command, "Add to Target");
            IMenuModel target_menu = model.GetSubMenu((CefMenuCommand)initial_command);
            /*            target_menu.AddItem((CefMenuCommand)initial_command + 1, "New");
            */
            int i = 2;
            foreach (Target target in Main_Instance.Instance.Workspace.Targets)
            {
                target_menu.AddItem((CefMenuCommand)initial_command + i, target.Title);
                i++;
            }

            //model.AddItem((CefMenuCommand)26502, "Close DevTools");

            // Add a separator
            //model.AddSeparator();

            // Add another example item
            // model.AddItem((CefMenuCommand)26503, "Display alert message");
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            // React to the first ID (add to target method)

            if (commandId > (CefMenuCommand)initial_command)
            {
                if (commandId == ((CefMenuCommand)initial_command + 1))
                {
                    SimpleInputForm newTargetForm = new SimpleInputForm("New Target");
                    //newTargetForm.ShowDialog(resultsForm);
                    resultsForm.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        newTargetForm.ShowDialog();

                    });
                    if (newTargetForm.DialogResult == DialogResult.OK)
                    {
                        if (newTargetForm.title != "")
                        {
                            TreeNode target = new TreeNode(newTargetForm.title);
                            TreeNode treeNode = new TreeNode("From Browser");
                            treeNode.Nodes.Add(new TreeNode(parameters.SelectionText));
                            target.Nodes.Add(treeNode);
                            Main_Instance.Instance.Workspace.TargetTreeView.Nodes.Add(target);
                        }
                        //Main_Instance.Instance.Workspace.
                    }
                }
                else
                {
                    int index = (int)commandId - initial_command - 2;
                    if (Main_Instance.Instance.Workspace.TargetTreeView.Nodes[index].Nodes.ContainsKey("From Browser"))
                    {
                        resultsForm.Invoke((MethodInvoker)delegate
                        {
                            Main_Instance.Instance.Workspace.TargetTreeView.Nodes[index].Nodes["From Browser"].Nodes.Add(new TreeNode(parameters.SelectionText));
                            Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();

                        });
                    }
                    else
                    {
                        TreeNode treeNode = new TreeNode("From Browser");
                        treeNode.Nodes.Add(new TreeNode(parameters.SelectionText));
                        resultsForm.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            Main_Instance.Instance.Workspace.TargetTreeView.Nodes[index].Nodes.Add(treeNode);
                            Main_Instance.Instance.Workspace.ReloadTargetsFromTreeView();
                        });
                    }



                }
                //browser.GetHost().ShowDevTools();
                return true;
            }

            // Any new item should be handled through a new if statement


            // Return false should ignore the selected option of the user !
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
