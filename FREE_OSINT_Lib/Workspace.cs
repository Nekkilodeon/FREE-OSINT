using System;
using System.Collections.Generic;
using System.Text;

namespace FREE_OSINT_Lib
{
    public class Workspace
    {
        List<Target> targets;
        public Workspace()
        {
            Targets = new List<Target>();
        }
        public List<Target> Targets { get => targets; set => targets = value; }
        public Target findTarget(string name)
        {
            foreach (Target target in this.targets)
            {
                if(target.Title == name)
                {
                    return target;
                }
            }
            return null;
        }
    }
   
}
