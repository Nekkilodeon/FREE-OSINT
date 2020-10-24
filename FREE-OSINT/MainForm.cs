using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            ModulesForm modulesForm = new ModulesForm();
            modulesForm.Show();
        }
    }
}
