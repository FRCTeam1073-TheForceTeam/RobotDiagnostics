/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "deCompressArm.h"
deCompressArm::deCompressArm() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::launcher);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void deCompressArm::Initialize() {
	printf("Decompressing the arm, abort the launch!\n");
}
// Called repeatedly when this Command is scheduled to run
void deCompressArm::Execute() {
	Robot::launcher->DeCompress();
}
// Make this return true when this Command no longer needs to run execute()
bool deCompressArm::IsFinished() {
	return true;
}
// Called once after isFinished returns true
void deCompressArm::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void deCompressArm::Interrupted() {
}
