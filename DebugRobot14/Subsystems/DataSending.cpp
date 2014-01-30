/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "DataSending.h"
#include "../Robotmap.h"
#include"../Commands/sendData.h"
DataSending::DataSending() : Subsystem("DataSending") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	batteryCurrent = RobotMap::dataSendingbatteryCurrent;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	count=0;
	t2=t1=t3=1;
}
void DataSending::InitDefaultCommand() {
	// Set the default command for a subsystem here.
	//SetDefaultCommand(new MySpecialCommand());
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
	SetDefaultCommand(new sendData());
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
	//printf("You are now sending data\n");
}
// Put methods for controlling this subsystem
// here. Call these from Commands.
void DataSending::SendTheData(){
	t1 = Timer::GetFPGATimestamp();
	downTime=t1-t2;
	strIndex = 0;
	Dashboard &dash = DriverStation::GetInstance()->GetHighPriorityDashboardPacker();
	DriverStation *drive = DriverStation::GetInstance();
	Send(drive->GetBatteryVoltage());
	Send(Robot::oi->getJoystick1()->GetX());
	Send(Robot::oi->getJoystick1()->GetY());
	Send(Robot::oi->getJoystick1()->GetZ());
	Send(batteryCurrent->GetVoltage());
	Send(RobotMap::launcherLauncherSolenoid->Get());
	Send((bool)RobotMap::compressionCompressor->GetPressureSwitchValue());
	Send(RobotMap::driveTrainDriveGyro->GetAngle());
	GetJagInfo();
	Send(RobotMap::shifterSystemShifterSolenoid->Get());
	Send(RobotMap::collectorAngleAdjuster->GetAngle());
	Send((bool)RobotMap::collectorHighLimit->Get());
	Send((bool)RobotMap::collectorLowLimit->Get());
	Send(RobotMap::collectorElevationEncoder->GetVoltage());
	Send(RobotMap::collectorLeftCollect->Get());
	Send(RobotMap::collectorRightCollect->Get());
	t2=Timer::GetFPGATimestamp();
	totalExeucted=t2-t1;
	percentCPU=totalExeucted/downTime;
	Send(totalExeucted,4);
	Send(downTime,4);
	Send(percentCPU,4);
	dash.AddString(strBuffer);
	dash.Finalize();}
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
	char line1[100];
	char line2[100];
	char line3[100];
	char line4[100];
	char line5[100];
	string setting = "Shifter is "+Robot::shifterSystem->GetGearSetting();
	string driveMode = "Drive mode "+Robot::driveTrain->GetDriveMode();
	strcpy(line1,setting.c_str());
	strcpy(line2,driveMode.c_str());
	if((bool)RobotMap::compressionCompressor->GetPressureSwitchValue())sprintf(line3,"PSI is 1");
	if(!(bool)RobotMap::compressionCompressor->GetPressureSwitchValue())sprintf(line3,"PSI is 0");
	sprintf(line4,"Elevation is %f",RobotMap::collectorElevationEncoder->GetVoltage());
	sprintf(line5, "Battery Current is %f",batteryCurrent->GetVoltage());
	DriverStationLCD *lcd = DriverStationLCD::GetInstance();
	lcd->PrintfLine(DriverStationLCD::kUser_Line1, "%s",line1);
	lcd->PrintfLine(DriverStationLCD::kUser_Line2, "%s",line2);
	lcd->PrintfLine(DriverStationLCD::kUser_Line3, "%s",line3);
	lcd->PrintfLine(DriverStationLCD::kUser_Line4, "%s",line4);
	lcd->PrintfLine(DriverStationLCD::kUser_Line5, "%s",line5);
	lcd->UpdateLCD();
}
void DataSending::GetJagInfo(){
	Send(RobotMap::driveTrainFrontLeft->GetOutputVoltage());
	Send(RobotMap::driveTrainFrontLeft->GetOutputCurrent());
	Send(RobotMap::driveTrainFrontLeft->GetPosition());
	Send(RobotMap::driveTrainFrontRight->GetOutputVoltage());
	Send(RobotMap::driveTrainFrontRight->GetOutputCurrent());
	Send(RobotMap::driveTrainFrontRight->GetPosition());
	Send(RobotMap::driveTrainRearLeft->GetOutputVoltage());
	Send(RobotMap::driveTrainRearLeft->GetOutputCurrent());
	Send(RobotMap::driveTrainRearLeft->GetPosition());
	Send(RobotMap::driveTrainRearRight->GetOutputVoltage());
	Send(RobotMap::driveTrainRearRight->GetOutputCurrent());
	Send(RobotMap::driveTrainRearRight->GetPosition());
}
