using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FREE_OSINT
{
    public class General_Config
    {
        public static string modules_directory = "modules";
        static internal Dictionary<int, Color> SubNodes;
        internal static string lib_directory = "libs";
        private Color target_color = Color.Aqua;
        private Color sub_node_color = Color.Aquamarine;

        public General_Config()
        {
            SubNodes = new Dictionary<int, Color>();
            SubNodes.Add(0, Color.LightGray);
            SubNodes.Add(1, Color.LightGray);
            SubNodes.Add(2, Color.LightGray);

            /*
            SubNodes.Add(0, Color.FromArgb(0, 247, 250));
            SubNodes.Add(1, Color.FromArgb(150, 247, 250));
            SubNodes.Add(2, Color.FromArgb(213, 213, 213));*/
        }

        public Color Target_color { get => target_color; set => target_color = value; }
        public Color Sub_node_color { get => sub_node_color; set => sub_node_color = value; }

        public enum Module_Type
        {
            Search, Process, Report
        }
    }
}
