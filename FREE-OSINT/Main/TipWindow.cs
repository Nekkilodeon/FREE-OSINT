using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT.Main
{
    public partial class TipWindow : Form
    {
        int subTipNumber = 1;
        int tipNumber = 1;
        Tips tips;
        public TipWindow(int tipNumber)
        {
            InitializeComponent();
            LoadJson();
            try
            {
                this.tipNumber = tipNumber;
                string tipFile = Directory.GetCurrentDirectory() + "\\Tips\\" + tipNumber + "_" + subTipNumber + ".gif";
                tipText.Text = tips.tips[tipNumber - 1].tip[subTipNumber - 1];

                PictureDisplayBox.Image = Image.FromFile(tipFile);
                //PictureDisplayBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkSkipTips.Checked)
            {
                General_Config.skip_tips = true;
                General_Config.SaveGeneralConfig();
            }

            //OK 
            this.DialogResult = DialogResult.OK;

        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            try
            {
                subTipNumber++;
                string tipFile = Directory.GetCurrentDirectory() + "\\Tips\\" + tipNumber + "_" + subTipNumber + ".gif";
                tipText.Text = tips.tips[tipNumber - 1].tip[subTipNumber - 1];
                PictureDisplayBox.Image = Image.FromFile(tipFile);
                //PictureDisplayBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                subTipNumber = 1;
                string tipFile = Directory.GetCurrentDirectory() + "\\Tips\\" + tipNumber + "_" + subTipNumber + ".gif";
                tipText.Text = tips.tips[tipNumber - 1].tip[subTipNumber - 1];
                PictureDisplayBox.Image = Image.FromFile(tipFile);
                //PictureDisplayBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "\\Tips\\" + "tips.json"))
            {
                string json = r.ReadToEnd();
                tips = JsonConvert.DeserializeObject<Tips>(json);
            }
        }



        public class Tips
        {
            public Tip[] tips { get; set; }
        }

        public class Tip
        {
            public string[] tip { get; set; }
        }

        private void TipWindow_Load(object sender, EventArgs e)
        {

        }

        private void PictureDisplayBox_Click(object sender, EventArgs e)
        {

        }
    }
}
