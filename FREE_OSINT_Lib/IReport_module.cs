using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FREE_OSINT_Lib
{
    public interface IReport_module
    {
        public object GenerateDocument(object toReport);
    }
}
