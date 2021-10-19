using NodeControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT.Main
{
    public partial class ConfigurationsForm : Form
    {
        private ListViewItem _itemDnD;

        public ConfigurationsForm()
        {
            InitializeComponent();
            checkTips.Checked = General_Config.skip_tips;
            checkAutoCloseSearch.Checked = General_Config.auto_closeSearch;
            PopulateListBoxColors();
            this.CenterToScreen();

            numericUpDown1.Value = Main_Instance.Instance.NodeDiagram.SubsPerLine;
        }

        private void PopulateListBoxColors()
        {
            listViewColors.Items.Clear();
            List<int> color_keys = General_Config.ColorsHierarchy.Keys.ToList();
            foreach (int key in color_keys)
            {
                ListViewItem item = new ListViewItem();
                var list_item = new ListViewItem(new[] { " ", key + "", General_Config.ColorsHierarchy[key].Name });
                list_item.SubItems[0].BackColor = General_Config.ColorsHierarchy[key];
                list_item.UseItemStyleForSubItems = false;
                list_item.SubItems[1].BackColor = Color.White;

                listViewColors.Items.Add(list_item);
                // listViewColors.Items[listViewColors.Items.Count-1].BackColor = General_Config.ColorsHierarchy[key];
            }
        }


        private void ConfigurationsForm_Load(object sender, EventArgs e)
        {
            if (!General_Config.skip_tips)
            {
                TipWindow tipWindow = new TipWindow(4);
                tipWindow.ShowDialog();
            }
        }

        private void ListViewColors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoubleClick(object sender, MouseEventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                int index = Int16.Parse(((ListView)sender).SelectedItems[0].SubItems[1].Text);
                General_Config.ColorsHierarchy[index] = dialog.Color;
                PopulateListBoxColors();
            }

        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            _itemDnD = listViewColors.GetItemAt(e.X, e.Y);

        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (_itemDnD == null)
                return;

            // Show the user that a drag operation is happening
            Cursor = Cursors.Hand;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;

            if (_itemDnD == null)
                return;

            // use 0 instead of e.X so that you don't have
            // to keep inside the columns while dragging
            ListViewItem itemOver = listViewColors.GetItemAt(0, e.Y);

            if (itemOver == null)
            {
                _itemDnD = null; return;

            }
            if (_itemDnD == itemOver)
            {
                _itemDnD = null; return;
            }

            int index_src = Int16.Parse(_itemDnD.SubItems[1].Text);
            int index_dest = Int16.Parse(itemOver.SubItems[1].Text);

            Color backup = General_Config.ColorsHierarchy[index_dest];
            General_Config.ColorsHierarchy[index_dest] = General_Config.ColorsHierarchy[index_src];
            General_Config.ColorsHierarchy[index_src] = backup;/*
            listViewColors.Items.Remove(_itemDnD);
            listViewColors.Items.Insert(itemOver.Index, _itemDnD);*/
            _itemDnD = null;
            PopulateListBoxColors();

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            General_Config.skip_tips = checkTips.Checked;
            General_Config.auto_closeSearch = checkAutoCloseSearch.Checked;
            General_Config.SaveGeneralConfig();
            this.DialogResult = DialogResult.OK;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Main_Instance.Instance.NodeDiagram.SubsPerLine = (int)numericUpDown1.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPerformance.Checked)
            {
                Main_Instance.Instance.NodeDiagram.PerformanceMode = true;
                Main_Instance.Instance.NodeDiagram.LineType = LineTypeEnum.Straight;
                Main_Instance.Instance.NodeDiagram.Redraw();
            }
            else
            {
                Main_Instance.Instance.NodeDiagram.PerformanceMode = false;
                Main_Instance.Instance.NodeDiagram.Redraw();
            }
        }
    }
}
