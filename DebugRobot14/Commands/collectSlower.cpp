/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "collectSlower.h"
collectSlower::collectSlower() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::collector);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void collectSlower::Initialize() {
	
}
// Called repeatedly when this Command is scheduled to run
void collectSlower::Execute() {
	Robot::collector->SetCollectorSpeed(-0.1);
}
// Make this return true when this Command no longer needs to run execute()
bool collectSlower::IsFinished() {
	return true;
}
// Called once after isFinished returns true
void collectSlower::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void collectSlower::Interrupted() {
}