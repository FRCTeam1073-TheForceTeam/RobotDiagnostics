/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "DataSending.h"
#include "../Robotmap.h"
#include "../Robot.h"
static const float VoltsPerCM = 0.0049;
#define AMPS_CONSTANT (71.43)
#define PSI_CONSTANT (22.22222)
DataSending::DataSending() : Subsystem("DataSending") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	batteryCurrent = RobotMap::dataSendingBatteryCurrent;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	InitializeBackGroundTask();//wake the zombie
}
const float periodicIntervalSec = .05f;
void DataSending::InitDefaultCommand() {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
	//printf("You are now sending data\n");
}
void DataSending::SendTheData(){
	strIndex = 0;
	Dashboard &dash = DriverStation::GetInstance()->GetHighPriorityDashboardPacker();
	DriverStation *drive = DriverStation::GetInstance();
	Send(drive->GetBatteryVoltage());//battery info
	Send((batteryCurrent->GetVoltage()-2.5)*AMPS_CONSTANT);
	GetDriveJoystickInfo();//joystick info
	//GetOperatorJoystickInfo();//moar joystick info
	GetVicInfo();//victor info
	Send((bool)RobotMap::launcherSolenoidLeft->Get());//solenoid info
	Send((bool)RobotMap::launcherSolenoidRight->Get());
	Send(RobotMap::shifterDoubleSolenoid->Get());
	Send((bool)RobotMap::launcherCompressor->GetPressureSwitchValue());//sensor info
	Send(RobotMap::robotRangeFinderUltrasonicSensor->GetVoltage()/VoltsPerCM);
	Send(RobotMap::driveTrainGyro->GetAngle());
	Send(RobotMap::elevatorElevationEncoder->GetVoltage());
	Send(RobotMap::launcherHighPressureSwitch->GetVoltage()*PSI_CONSTANT);//transducer1
	Send(RobotMap::collectorLeftRoller->Get()*-1);//talon info
	Send(RobotMap::collectorRightRoller->Get());
	Send(count++);//number of packets
	Send(periodicIntervalSec);//the refresh rate of sending
	Send(drive->GetMatchTime());
	Send(drive->IsEnabled());
	dash.AddString(strBuffer);
	dash.Finalize();
	UpdateUserLCD();
}
void DataSending::Send(double f, int digits)
{
	char buff[20];
	int len = sprintf(buff, "%.*f,", digits, f);
	if(strIndex+len < MaxBuffer){
		strcpy(strBuffer+strIndex, buff);
		strIndex += len;
	}
}
void DataSending::Send(bool b)
{
	int len = 2;
	if(strIndex+len < MaxBuffer){
		if(b)	strcpy(strBuffer+strIndex, "1,");
		else	strcpy(strBuffer+strIndex, "0,");
		strIndex += len;
	}
}
void DataSending::Send(int i)
{
	char buff[20];
	int len = sprintf(buff, "%d,", i);
	if(strIndex+len < MaxBuffer){
		strcpy(strBuffer+strIndex, buff);
		strIndex += len;
	}
}
void DataSending::Send(char *s)
{
	char buff[81];
	int len = sprintf(buff, "%s,", s);
	if(strIndex+len < MaxBuffer){
		strcpy(strBuffer+strIndex, buff);
		strIndex += len;
	}
}
void DataSending::UpdateUserLCD(){
	char line1[200];
	char line2[200];
	char line3[200];
	char line4[200];
	char line5[200];
	string setting = "Shifter is "+GetGearSetting();
	string driveMode = "Drive mode Mecanum";
	strcpy(line1,setting.c_str());
	strcpy(line2,driveMode.c_str());
	if((bool)RobotMap::launcherCompressor->GetPressureSwitchValue())sprintf(line3,"Sufficent Pressure");
	else sprintf(line3,"Insufficient Pressure");
	if(((batteryCurrent->GetVoltage()-2.5)*AMPS_CONSTANT)<150)sprintf(line4,"Don't drop the clutch!");
	else sprintf(line4,"You droped the clutch!");
	sprintf(line5, "Battery Current is %f Amps",((batteryCurrent->GetVoltage()-2.5)*AMPS_CONSTANT));
	DriverStationLCD *lcd = DriverStationLCD::GetInstance();
	lcd->PrintfLine(DriverStationLCD::kUser_Line1, "%s",line1);
	lcd->PrintfLine(DriverStationLCD::kUser_Line2, "%s",line2);
	lcd->PrintfLine(DriverStationLCD::kUser_Line3, "%s",line3);
	lcd->PrintfLine(DriverStationLCD::kUser_Line4, "%s",line4);
	lcd->PrintfLine(DriverStationLCD::kUser_Line5, "%s",line5);
	lcd->UpdateLCD();
}
void DataSending::GetVicInfo(){
	Send(RobotMap::driveTrainLeftFront->Get());
	Send(RobotMap::driveTrainRightFront->Get());
	Send(RobotMap::driveTrainLeftBack->Get());
	Send(RobotMap::driveTrainRightBack->Get());
	Send(RobotMap::elevatorAngleAdjuster->Get());
}
void DataSending::GetDriveJoystickInfo(){
	Send(Robot::oi->getDriveStick()->GetX());
	Send(Robot::oi->getDriveStick()->GetY());
	Send(Robot::oi->getDriveStick()->GetZ());
	/*Send(Robot::oi->shiftButton->Get());
	Send(Robot::oi->lauchBall->Get());
	Send(Robot::oi->compressButton->Get());
	Send(Robot::oi->angleUpButton->Get());
	Send(Robot::oi->angleDownButton->Get());
	Send(Robot::oi->collectFasterButton->Get());
	Send(Robot::oi->collectSlowerButton->Get());*/
}
void DataSending::GetOperatorJoystickInfo(){
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
	Send(false);
}
int BackroundFunction(...)
{
	Wait(1.0);  //wait a second to make sure everything is ready
	while (1)  // No stopping the Zombie, Life before Autonomous....
	{
		Wait(periodicIntervalSec);		// Wait 50ms for a 20Hz update rate...
		Robot::dataSending->SendTheData();
	}
}
SEM_ID BackgroundSemaphore = 0;
Task *BackgroundTask;
void DataSending::InitializeBackGroundTask()
{
	printf("Initiation ocurred\n");
	BackgroundTask = new Task("BackGroundTask", BackroundFunction, Task::kDefaultPriority+10 );
	BackgroundSemaphore = semMCreate(SEM_DELETE_SAFE | SEM_INVERSION_SAFE); // synchronize access to multi-value registers
	BackgroundTask->Start();
	printf("This robot is currently being monitered\n");
}
string DataSending::GetGearSetting(){
	if(RobotMap::shifterDoubleSolenoid->Get()==DoubleSolenoid::kForward){
		return "low";
	}
	if(RobotMap::shifterDoubleSolenoid->Get()==DoubleSolenoid::kReverse){
		return "high";
	}
	if(RobotMap::shifterDoubleSolenoid->Get()==DoubleSolenoid::kOff){
		return "off";
	}
	return 0;
}
