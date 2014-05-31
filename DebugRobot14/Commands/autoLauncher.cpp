/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "autoLauncher.h"
autoLauncher::autoLauncher() {
	// Use requires() here to declare subsystem dependencies
	// eg. requires(chassis);
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
	Requires(Robot::launcher);
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=REQUIRES
}
// Called just before this Command runs the first time
void autoLauncher::Initialize() {
	puts("Testing the Laucher and Compressor...\n");
}
// Called repeatedly when this Command is scheduled to run
void autoLauncher::Execute() {
	if((bool)RobotMap::launcherCompressor->GetPressureSwitchValue()){
		puts("Not testing the laucher subsystem due to pressure already exists...\n");
	}
	else{//assume there is no air in the compressor and the valve is closed
		puts("Lauching the Ball without air...\n");
		Robot::launcher->Launch();
		Wait(0.1);
		Robot::launcher->autoStopLauch();
		puts("Turning on the compressor for shifters...\n");
		Robot::launcher->Compress();
		Wait(5);
		Robot::launcher->canCompress();
		puts("Turning off the compressor...\n");
		Robot::launcher->Compress();
		Wait(0.3);
	}
}
// Make this return true when this Command no longer needs to run execute()
bool autoLauncher::IsFinished() {
	return true;
}
// Called once after isFinished returns true
void autoLauncher::End() {
}
// Called when another command which requires one or more of the same
// subsystems is scheduled to run
void autoLauncher::Interrupted() {
}
