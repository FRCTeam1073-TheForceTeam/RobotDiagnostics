/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "autoElevator.h"
autoElevator::autoElevator() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::elevator);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void autoElevator::Initialize() {
	puts("Testing the elevator...\n");
}
// Called repeatedly when this Command is scheduled to run
void autoElevator::Execute() {
	puts("moving the elevator down...\n");
	Robot::elevator->autoDown();
	Wait(1);
	puts("moving the elevator up...\n");
	Robot::elevator->autoUp();
	Wait(0.5);
	Robot::elevator->autoStopArm();
	Wait(1);
}
// Make this return true when this Command no longer needs to run execute()
bool autoElevator::IsFinished() {
	return true;
}
// Called once after isFinished returns true
void autoElevator::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void autoElevator::Interrupted() {
}
