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
        DateTime timestamp;


        public string From_module { get => from_module; set => from_module = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public Uri Uri { get => uri; set => uri = value; }
        public ArrayList Extras { get => extras; set => extras = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        
        public void Fix_Characters()
        {
            if(title != null && title.Contains("\n"))
            {
                title.Replace(System.Environment.NewLine, "");
            }
            if (Description != null && Description.Contains("\n"))
            {
                String backup = Description;
                Description = "";
                foreach(String value in backup.Split('\n'))
                {
                    Description += value;
                }
            }
        }
    }
}
