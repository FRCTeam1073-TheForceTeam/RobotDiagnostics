/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "collectFaster.h"
collectFaster::collectFaster() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::collector);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void collectFaster::Initialize() {
	Robot::collector->SetSpeed(Robot::collector->GetSpeed()+0.10);
}
// Called repeatedly when this Command is scheduled to run
void collectFaster::Execute() {
	RobotMap::collectorLeftRoller->Set(Robot::collector->GetSpeed());
	RobotMap::collectorRightRoller->Set(Robot::collector->GetSpeed());
}
// Make this return true when this Command no longer needs to run execute()
bool collectFaster::IsFinished() {
	return true;
}
// Called once after isFinished returns true
void collectFaster::End() {
	
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void collectFaster::Interrupted() {
}
