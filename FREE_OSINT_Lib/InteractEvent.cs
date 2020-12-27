using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FREE_OSINT_Lib
{
    public class InteractEventArgs : EventArgs
    {
        public Operation_Type Operation { get; set; }
        public HashSet<TreeNode> SelectedObjects { get; set; }

        public enum Operation_Type
        {
            Insert
        }
    }
}
