using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1073BatteryTracker
{
    public class Battery
    {
        //String checkoutFormat = String.Format("{0:MM/dd/yy hh:mm tt}", checkoutTime);
        public Battery() { }
        private string batteryYear;
        private string batteryNumber;
        private float batteryVoltage;
        private bool inUse = false;
        private String checkoutTime;
        private String estCheckinTime;
        private String actCheckinTime;
        private String subgroup;
        private String robot;

        public string getBatteryYear() { return batteryYear; }
        public string getBatteryNumber() { return batteryNumber; }
        public float getBatteryVoltage() { return batteryVoltage; }
        public void setBatteryYear(string year) { batteryYear = year; }
        public void setBatteryNumber(string number) { batteryNumber = number; }
        public void setBatteryVoltage(float voltage) { batteryVoltage = voltage; }
        public bool isInUse() { return inUse; }
        public void isNowInUse(bool b) { inUse = b; }
        public override string ToString(){return "" + batteryYear + "_" + batteryNumber;}
        public void setCheckoutTime(String dt) { checkoutTime = dt; }
        public void setEstCheckinTime(String dt) { estCheckinTime = dt; }
        public void setActCheckinTime(String dt) { actCheckinTime = dt; }
        public String getCheckoutTime() { return checkoutTime; }
        public String getEstCheckinTime() { return estCheckinTime; }
        public String getActCheckinTime() { return actCheckinTime; }
        public String getFormatedCheckoutTime(){return String.Format("{0:MM/dd/yy hh:mm tt}", checkoutTime);}
        public string getSubgroup() { return subgroup; }
        public string getRobot() { return robot; }
        public void setSubgroup(String group) { subgroup = group; }
        public void setRobot(String theRobot) { robot = theRobot; }
        public String isInUseText()
        {
            if (inUse)
                return "true";
            else
                return "false";
        }

    }
}
