using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            ThreadWithState tws = new ThreadWithState(this);
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.CenterToScreen();
            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
        }

        private void LoadingDone()
        {
            MainForm mainForm = new MainForm();
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private class ThreadWithState
        {
            // State information used in the task.
            private LoadingForm loadingForm;

            List<IGeneral_module> module_list;
            IEnumerable<IGeneral_module> modules;

            // The constructor obtains the state information.
            public ThreadWithState(LoadingForm loadingForm)
            {
                this.loadingForm = loadingForm;
            }

            // The thread procedure performs the task, such as formatting
            // and printing a document.
            public void ThreadProc()
            {
                loadModules();
                //Console.WriteLine(boilerplate, numberValue);
            }
            private void loadModules()
            {
                module_list = new List<IGeneral_module>();

                string[] module_directories = System.IO.Directory.GetDirectories(General_Config.modules_directory);
                for (int i = 0; i < module_directories.Length; i++)
                {
                    try
                    {
                        if (!module_directories[i].Contains(General_Config.lib_directory))
                        {

                            var moduleAssembly = System.Reflection.Assembly.LoadFrom(module_directories[i] + "/" + module_directories[i].Split('\\')[1] + ".exe");
                            var moduleTypes = moduleAssembly.GetTypes().Where(t =>
                               t.GetInterfaces().Contains(typeof(IGeneral_module)));
                            modules = moduleTypes.Select(type =>
                            {
                                loadingForm.txtCurrentModule.Invoke((MethodInvoker)delegate
                                {
                                    loadingForm.txtCurrentModule.Text = " Loading: " + type.FullName;
                                });
                                return (IGeneral_module)Activator.CreateInstance(type);
                            });
                            module_list.AddRange(this.modules.ToList());
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                module_list = ReadDlls(module_list);

                loadingForm.txtCurrentModule.Invoke((MethodInvoker)delegate
                {
                    loadingForm.txtCurrentModule.Text = "Done";
                });
                foreach (IGeneral_module module in module_list)
                {
                    if (module.GetType().GetInterfaces().Contains(typeof(IInteractable_module)) || module.GetType().GetInterfaces().Contains(typeof(ISearchable_module)))
                    {
                        Main_Instance.Instance.Module_list[General_Config.Module_Type.Search].Add(module);
                    }
                    else if (module.GetType().GetInterfaces().Contains(typeof(IProcessing_Module)))
                    {
                        Main_Instance.Instance.Module_list[General_Config.Module_Type.Process].Add(module);
                    }
                    else if (module.GetType().GetInterfaces().Contains(typeof(IReport_module)))
                    {
                        Main_Instance.Instance.Module_list[General_Config.Module_Type.Report].Add(module);
                    }
                }
                loadingForm.Invoke(new MethodInvoker(loadingForm.Hide));
                loadingForm.Invoke(new MethodInvoker(loadingForm.LoadingDone));

                //LoadingEvent.Invoke(this, EventArgs.Empty);
                /*
                listModules.Items.Add("Default Google");
                listModules.Items.Add("Default Bing");*/
            }

            private List<IGeneral_module> ReadDlls(List<IGeneral_module> module_list)
            {
                string[] fileEntries = Directory.GetFiles(General_Config.modules_directory + "/" + General_Config.lib_directory);
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    try
                    {
                        var moduleAssembly = System.Reflection.Assembly.LoadFrom(fileEntries[i]);
                        var moduleTypes = moduleAssembly.GetTypes().Where(t =>
                           t.GetInterfaces().Contains(typeof(IGeneral_module)));
                        modules = moduleTypes.Select(type =>
                        {
                            loadingForm.txtCurrentModule.Invoke((MethodInvoker)delegate
                            {
                                loadingForm.txtCurrentModule.Text = " Loading: " + type.FullName;
                            });
                            return (IGeneral_module)Activator.CreateInstance(type);
                        });
                        module_list.AddRange(this.modules.ToList());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }

                return module_list;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}

