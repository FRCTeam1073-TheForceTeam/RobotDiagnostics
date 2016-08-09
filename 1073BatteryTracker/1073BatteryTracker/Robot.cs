using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1073BatteryTracker
{
    public class Robot
    {
        public string robotName { get; set; }
        public Robot()
        {

        }
        public Robot(string theName)
        {
            robotName = theName;
        }
        public override string ToString()
        {
            return robotName;
        }
    }
}
