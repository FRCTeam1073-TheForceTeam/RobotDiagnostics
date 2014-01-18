/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "sendData.h"
sendData::sendData() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void sendData::Initialize() {
	
}
// Called repeatedly when this Command is scheduled to run
void sendData::Execute() {
	Dashboard &dash = DriverStation::GetInstance()->GetHighPriorityDashboardPacker();
		DriverStation *drive = DriverStation::GetInstance();
		char buffer[1024];
		static int count = 0;
		float battery = drive->GetBatteryVoltage();
		float x =(float) drive->GetStickAxis(1,x);
		float y = (float) drive->GetStickAxis(1,y);
		float z = (float) drive->GetStickAxis(1,z);
		float batteryCurrent=RobotMap::chasisBatteryCurrent->GetVoltage();
		float idk=RobotMap::chasisPSITransducer120->GetVoltage();
		float pressureValue=RobotMap::launcherArmCompressor->GetPressureSwitchValue();
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
		
		float lol=RobotMap::shifterSystemDoubleSolenoid1->Get();
		float quadEncoder1=RobotMap::shifterSystemQuadratureEncoder1->GetDistance();
		float quadEncoder2=RobotMap::shifterSystemQuadratureEncoder2->GetDistance();
		float quadEncoder3=RobotMap::shifterSystemQuadratureEncoder3->GetDistance();
		float quadEncoder4=RobotMap::shifterSystemQuadratureEncoder4->GetDistance();
		int switchValue = RobotMap::shifterSystemShifterCompressor->GetPressureSwitchValue();
		
		sprintf(buffer, "%d %f ", count++, battery);
		dash.AddString(buffer);
		dash.Finalize();
}
// Make this return true when this Command no longer needs to run execute()
bool sendData::IsFinished() {
	return false;
}
// Called once after isFinished returns true
void sendData::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void sendData::Interrupted() {
}
