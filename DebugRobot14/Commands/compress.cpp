/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "compress.h"
compress::compress() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::compression);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void compress::Initialize() {
	
}
// Called repeatedly when this Command is scheduled to run
void compress::Execute() {
	Robot::compression->Compress();
}
// Make this return true when this Command no longer needs to run execute()
bool compress::IsFinished() {
	return true;
}
// Called once after isFinished returns true
void compress::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void compress::Interrupted() {
}
