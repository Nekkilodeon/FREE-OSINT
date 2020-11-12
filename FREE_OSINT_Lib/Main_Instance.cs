using FREE_OSINT_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FREE_OSINT
{
    public class Main_Instance
    {
        private static Main_Instance instance = null;
        private static readonly object padlock = new object();
        private Workspace workspace;

        Main_Instance()
        {
            workspace = new Workspace();
        }
        public static Main_Instance Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Main_Instance();
                    }
                    return instance;
                }
            }
        }

        public Workspace Workspace { get => workspace; set => workspace = value; }
    }
}
