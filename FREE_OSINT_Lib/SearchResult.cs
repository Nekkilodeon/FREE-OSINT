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
        List<object> extras;
        Status_Code status;
        String message;

        public SearchResult(Status_Code status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public SearchResult(TreeNode treeNode, List<Intel> intels, int num_results, string title, List<object> extras, Status_Code status, string message)
        {
            this.treeNode = treeNode;
            this.intels = intels;
            this.num_results = num_results;
            this.title = title;
            this.extras = extras;
            this.Status = status;
            this.Message = message;
        }

        public SearchResult(TreeNode treeNode, List<Intel> intels, int num_results, string title, Status_Code status, string message)
        {
            this.treeNode = treeNode;
            this.intels = intels;
            this.num_results = num_results;
            this.title = title;
            this.Status = status;
            this.Message = message;
        }

        public SearchResult(TreeNode treeNode, int num_results, string title, List<object> extras, Status_Code status, string message)
        {
            this.treeNode = treeNode;
            this.num_results = num_results;
            this.title = title;
            this.extras = extras;
            this.Status = status;
            this.Message = message;
        }

        public SearchResult(List<Intel> intels, int num_results, string title, Status_Code status, string message)
        {
            this.intels = intels;
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
