/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "compressArm.h"
compressArm::compressArm() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void compressArm::Initialize() {
	
}
// Called repeatedly when this Command is scheduled to run
void compressArm::Execute() {
	Robot::launcher->Compress();
}
// Make this return true when this Command no longer needs to run execute()
bool compressArm::IsFinished() {
	return false;
}
// Called once after isFinished returns true
void compressArm::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void compressArm::Interrupted() {
}
