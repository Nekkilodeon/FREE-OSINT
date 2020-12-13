using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ThreadWithState tws = new ThreadWithState( this);
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.CenterToScreen();
            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
        }

        private void LoadingDone()
        {
            MainForm mainForm = new MainForm();
            var dialogResult = mainForm.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private class ThreadWithState
        {
            // State information used in the task.
            private LoadingForm loadingForm;
            public EventHandler LoadingEvent;

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
                    var moduleAssembly = System.Reflection.Assembly.LoadFrom(module_directories[i] + "/" + module_directories[i].Split('\\')[1] + ".exe");
                    var moduleTypes = moduleAssembly.GetTypes().Where(t =>
                       t.GetInterfaces().Contains(typeof(IGeneral_module)));
                    modules = moduleTypes.Select(type =>
                    {
                        loadingForm.txtCurrentModule.Invoke((MethodInvoker)delegate {
                            loadingForm.txtCurrentModule.Text = "Loading: " + type.FullName;
                        });
                        return (IGeneral_module)Activator.CreateInstance(type);
                    });
                    module_list.AddRange(this.modules.ToList());
                }

                loadingForm.txtCurrentModule.Invoke((MethodInvoker)delegate {
                    loadingForm.txtCurrentModule.Text = "Done";
                });
                Main_Instance.Instance.Module_list = module_list;
                loadingForm.Invoke(new MethodInvoker(loadingForm.Hide));
                loadingForm.Invoke(new MethodInvoker(loadingForm.LoadingDone));

                //LoadingEvent.Invoke(this, EventArgs.Empty);
                /*
                listModules.Items.Add("Default Google");
                listModules.Items.Add("Default Bing");*/
            }
        }


    }
}

