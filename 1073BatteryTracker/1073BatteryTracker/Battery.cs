using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1073BatteryTracker
{
    public class Battery
    {
        //2 constructers, a blank one and one where all the values can be set
        public Battery() { }
        public Battery(String battYear, String battNum, float battVol, String outTime, String estIn, String Subgroup, String bot)
        {
        batteryYear = battYear;
        batteryNumber = battNum;
        batteryVoltage = battVol;
        checkoutTime = outTime;
        estCheckinTime = estIn;
        subgroup = Subgroup;
        robot = bot;
        }
        //all the private instance variables
        private string batteryYear;
        private string batteryNumber;
        private float batteryVoltage;
        private String checkoutTime;
        private String estCheckinTime;
        private String subgroup;
        private String robot;
        //all the gets and sets
        public string getYear() { return batteryYear; }
        public string getNumber() { return batteryNumber; }
        public float getVoltage() { return batteryVoltage; }
        public void setYear(string year) { batteryYear = year; }
        public void setNumber(string number) { batteryNumber = number; }
        public void setVoltage(float voltage) { batteryVoltage = voltage; }
        public override string ToString(){return "" + batteryYear + "_" + batteryNumber;}
        public void setCheckoutTime(String dt) { checkoutTime = dt; }
        public void setEstCheckinTime(String dt) { estCheckinTime = dt; }
        public String getCheckoutTime() { return checkoutTime; }
        public String getEstCheckinTime() { return estCheckinTime; }
        public String getFormatedCheckoutTime(){return String.Format("{0:MM/dd/yy hh:mm tt}", checkoutTime);}
        public string getSubgroup() { return subgroup; }
        public string getRobot() { return robot; }
        public void setSubgroup(String group) { subgroup = group; }
        public void setRobot(String theRobot) { robot = theRobot; }
    }
}
