using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FREE_OSINT_Lib
{
    public class SearchResult
    {
        TreeNode treeNode;
        List<Intel> intels;
        int num_results;
        string title;

        DateTime timestamp;
        Status_Code status;
        String message;

        public SearchResult(Status_Code status, string message)
        {
            this.Status = status;
            this.Message = message;
            this.timestamp = DateTime.Now;
        }

        public SearchResult(TreeNode treeNode, DateTime timestamp, List<Intel> intels, int num_results, string title, Status_Code status, string message)
        {
            this.treeNode = treeNode;
            if (timestamp == null)
            {
                this.timestamp = DateTime.Now;
            }
            else
            {
                this.timestamp = timestamp;
            }
            this.intels = intels;
            this.num_results = num_results;
            this.title = title;
            this.Status = status;
            this.Message = message;
        }


        public SearchResult(TreeNode treeNode, DateTime timestamp, int num_results, string title, Status_Code status, string message)
        {
            this.treeNode = treeNode;
            if(timestamp == null)
            {
                this.timestamp = DateTime.Now;
            }
            else
            {
                this.timestamp = timestamp;
            }
            this.num_results = num_results;
            this.title = title;
            this.Status = status;
            this.Message = message;
        }

        public SearchResult(List<Intel> intels, DateTime timestamp, int num_results, string title, Status_Code status, string message)
        {
            this.intels = intels;
            if (timestamp == null)
            {
                this.timestamp = DateTime.Now;
            }
            else
            {
                this.timestamp = timestamp;
            }
            this.num_results = num_results;
            this.title = title;
            this.Status = status;
            this.Message = message;
        }

        public TreeNode Treenode { get => treeNode; set => treeNode = value; }
        public List<Intel> Intels { get => intels; set => intels = value; }
        public string Title { get => title; set => title = value; }
        public int Num_results { get => num_results; set => num_results = value; }
        public Status_Code Status { get => status; set => status = value; }
        public string Message { get => message; set => message = value; }
    }

    public enum Status_Code
    {
        //more?
        DONE,ERROR
    }
}
