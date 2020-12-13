using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult dialogResult = MessageBox.Show("Load modules?", "Select", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //load
                Application.Run(new LoadingForm());
            }
            else if (dialogResult == DialogResult.No)
            {
                //just open main
                Application.Run(new MainForm());
            }
        }
    }
}
