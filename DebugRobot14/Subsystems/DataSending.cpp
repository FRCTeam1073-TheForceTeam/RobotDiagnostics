/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "DataSending.h"
#include "../Robotmap.h"
#include"../Commands/sendData.h"
DataSending::DataSending() : Subsystem("DataSending") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
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
	static const int MaxBuffer = 1000;
	char strBuffer[MaxBuffer];
	int strIndex=0;
	int length=2;
	int fakeBool;
	Dashboard &dash = DriverStation::GetInstance()->GetHighPriorityDashboardPacker();
	DriverStation *drive = DriverStation::GetInstance();
	stickStuff=new SmartJoystick(1);
	char buffer[1024];
	static int count = 0;
	float battery = drive->GetBatteryVoltage();
	float x = stickStuff->GetAxis(Joystick::kXAxis);
	float y =stickStuff->GetAxis(Joystick::kYAxis);
	float z =stickStuff->GetAxis(Joystick::kZAxis);
	float batteryCurrent=RobotMap::chasisBatteryCurrent->GetVoltage();
	if(RobotMap::launcherLauncherSolenoid->Get())fakeBool=1;
	if(!RobotMap::launcherLauncherSolenoid->Get())fakeBool=0;
	float pressureValue=RobotMap::compressionCompressor->GetPressureSwitchValue();
	float gyroAngle=RobotMap::driveTrainDriveGyro->GetAngle();
	float leftFrontVoltage=RobotMap::driveTrainFrontLeft->GetOutputVoltage();
	float leftFrontCurrent=RobotMap::driveTrainFrontLeft->GetOutputCurrent();
	float leftFrontPosition=RobotMap::driveTrainFrontLeft->GetPosition();
	float rightFrontVoltage=RobotMap::driveTrainFrontRight->GetOutputVoltage();
	float rightFrontCurrent=RobotMap::driveTrainFrontRight->GetOutputCurrent();
	float rightFrontPosition=RobotMap::driveTrainFrontRight->GetPosition();
	float leftRearVoltage=RobotMap::driveTrainRearLeft->GetOutputCurrent();
	float leftRearCurrent=RobotMap::driveTrainRearLeft->GetPosition();
	float leftRearPosition=RobotMap::driveTrainRearLeft->GetOutputCurrent();
	float rightRearVoltage=RobotMap::driveTrainRearRight->GetPosition();
	float rightRearCurrent=RobotMap::driveTrainRearRight->GetOutputCurrent();
	float rightRearPosition=RobotMap::driveTrainRearRight->GetPosition();
	float shifterSolenoid=RobotMap::shifterSystemShifterSolenoid->Get();
	float collectorAngle=RobotMap::collectorAngleAdjuster->GetAngle();
	int highLimit=RobotMap::collectorHighLimit->Get();
	int lowLimit=RobotMap::collectorLowLimit->Get();
	float elevation=RobotMap::collectorElevationEncoder->GetVoltage();
	float leftCollecter=RobotMap::collectorLeftCollect->Get();
	float rightCollector=RobotMap::collectorRightCollect->Get();
	int len = sprintf(buffer, ",%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%d ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%.*f ,%d ,%d ,%.*f ,%.*f ,%.*f ,%d ",
		length, battery,
		length, x,
		length, y,
		length, z,
		length, batteryCurrent,
		fakeBool,
		length, pressureValue,
		length, gyroAngle,
		length, leftFrontVoltage,
		length, leftFrontCurrent,
		length, leftFrontPosition,
		length, rightFrontVoltage,
		length, rightFrontCurrent,
		length, rightFrontPosition,
		length,	leftRearVoltage,
		length, leftRearCurrent,
		length, leftRearPosition,
		length, rightRearVoltage,
		length, rightRearCurrent,
		length, rightRearPosition,
		length, shifterSolenoid,
		length, collectorAngle,
		highLimit,
		lowLimit,
		length, elevation,
		length, leftCollecter,
		length, rightCollector,
		count++);
     if(strIndex+len < MaxBuffer){
		strcpy(strBuffer+strIndex, buffer);
		strIndex += len;}
	dash.AddString(buffer);
	dash.Finalize();
			
	char line1[100];
	char line2[100];
	char line3[100];
	int setting = Robot::shifterSystem->GetGearSetting();
	int driveMode = Robot::driveTrain->GetDriveMode();
	float PSI = Robot::launcher->GetPSI();
	if(driveMode==0)sprintf(line2,"Drive Mode Error");
	if(driveMode==1)sprintf(line2,"Drive Mode Arcade");
	if(driveMode==2)sprintf(line2,"Drive Mode Meccanum");
	if(setting==-1)sprintf(line1,"Shifted Down");
	if(setting==0)sprintf(line1,"Shifter Off");
	if(setting==1)sprintf(line1,"Shifted Up");
	sprintf(line3,"PSI is %f",PSI);
	DriverStationLCD *lcd = DriverStationLCD::GetInstance();
	lcd->PrintfLine(DriverStationLCD::kUser_Line1, "%s",line1);
	lcd->PrintfLine(DriverStationLCD::kUser_Line2, "%s",line2);
	lcd->PrintfLine(DriverStationLCD::kUser_Line3, "%s",line3);
	lcd->UpdateLCD();
}
