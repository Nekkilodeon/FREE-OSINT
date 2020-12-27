using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FREE_OSINT_Lib
{
    public interface IReport_module
    {
        public PdfDocument GenerateDocument(object infoToPdf);
    }
}
