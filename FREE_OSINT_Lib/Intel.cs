using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FREE_OSINT_Lib
{
    public class Intel
    {
        String from_module = "";
        String title = "";
        String description = "";
        Uri uri;
        ArrayList extras;


        public string From_module { get => from_module; set => from_module = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public Uri Uri { get => uri; set => uri = value; }
        public ArrayList Extras { get => extras; set => extras = value; }
    }
}
