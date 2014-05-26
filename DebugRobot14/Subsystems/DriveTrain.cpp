/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "DriveTrain.h"
#include "../Robotmap.h"
#include "../Commands/drive.h"
const float TWIST_CONSTANT = 0.8f;
static const float MECANUM_CONSTANT = 1.4142;
int mode=0;
DriveTrain::DriveTrain() : Subsystem("DriveTrain") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	gyro = RobotMap::driveTrainGyro;
	rightBack = RobotMap::driveTrainRightBack;
	leftBack = RobotMap::driveTrainLeftBack;
	leftFront = RobotMap::driveTrainLeftFront;
	rightFront = RobotMap::driveTrainRightFront;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
}
void DriveTrain::InitDefaultCommand() {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
	SetDefaultCommand(new drive());
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
}
void DriveTrain::MecanumDrive(float joystickX, float joystickY, float joystickTwist) {
	double angle = atan2(joystickX, joystickY);
		float joystickMagnitude = sqrt((joystickX * joystickX) + (joystickY * joystickY));
		if(joystickTwist < 0.20 && joystickTwist > -0.20){
				joystickTwist = 0.0;
			}
		float ccTwist = joystickTwist * TWIST_CONSTANT;
		float twist = -joystickTwist * TWIST_CONSTANT;
		
		float leftFrontVal = -1 * (ccTwist + joystickMagnitude*(cos(angle)+sin(angle)));
		float rightFrontVal = (twist + joystickMagnitude*(cos(angle)-sin(angle)));
		float leftBackVal= -1 * (ccTwist + joystickMagnitude*(cos(angle)-sin(angle)));
		float rightBackVal = (twist + joystickMagnitude*(cos(angle)+sin(angle)));
		
		leftFront->Set(leftFrontVal);
		rightFront->Set(rightFrontVal);
		leftBack->Set(leftBackVal);
		rightBack->Set(rightBackVal);
}
void DriveTrain::AutoFoward(){
	leftFront->Set(-1);
	rightFront->Set(1);
	leftBack->Set(-1);
	rightBack->Set(1);
}
void DriveTrain::AutoReverse(){
	leftFront->Set(1);
	rightFront->Set(-1);
	leftBack->Set(1);
	rightBack->Set(-1);
}
void DriveTrain::Stop(){
	leftFront->Set(0);
	rightFront->Set(0);
	leftBack->Set(0);
	rightBack->Set(0);
}
