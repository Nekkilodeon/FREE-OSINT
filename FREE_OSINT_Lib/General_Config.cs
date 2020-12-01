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
        public static string modules_directory = "search_modules";
        private Color target_color = Color.Aqua;
        private Color sub_node_color = Color.Aquamarine;

        public General_Config()
        {
        }

        public Color Target_color { get => target_color; set => target_color = value; }
        public Color Sub_node_color { get => sub_node_color; set => sub_node_color = value; }
    }
}
