using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1073BatteryTracker
{
    public class Subgroup
    {
        public string groupName { get; set; }
        public Subgroup()
        {

        }
        public override string ToString()
        {
            return groupName;
        }
    }
}
