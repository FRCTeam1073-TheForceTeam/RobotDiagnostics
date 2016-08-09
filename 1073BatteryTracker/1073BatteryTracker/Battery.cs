using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1073BatteryTracker
{
    public class Battery
    {
        public Battery() { }
        //all the private instance variables
        public string batteryYear{get; set;}
        public string batteryNumber{get; set;}
        public float batteryVoltage{get; set;}
        public String checkoutTime{get; set;}
        public String estCheckinTime{get; set;}
        public String subgroup{get; set;}
        public String robot{get; set;}
        public override string ToString() { return "" + batteryYear + "_" + batteryNumber; }
    }
}
