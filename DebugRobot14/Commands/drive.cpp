/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "drive.h"
drive::drive() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::driveTrain);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void drive::Initialize() {
	printf("mecannum drive\n");
}
// Called repeatedly when this Command is scheduled to run
void drive::Execute() {
	Robot::driveTrain->MecanumDrive(Robot::oi->getJoystick1()->GetX(), Robot::oi->getJoystick1()->GetY(), Robot::oi->getJoystick1()->GetZ());
	
	//Robot::oi->getJoystick1()
}
// Make this return true when this Command no longer needs to run execute()
bool drive::IsFinished() {
	return false;
}
// Called once after isFinished returns true
void drive::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void drive::Interrupted() {
}
