/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#ifndef DRIVE_TRAIN_H
#define DRIVE_TRAIN_H
#include "Commands/Subsystem.h"
#include "WPILib.h"
#include "../WPILibExtensions/WPILibExtensions.h"
class DriveTrain: public Subsystem {
private:
	bool leftFrontOK;
	bool rightFrontOK;
	bool leftBackOK;
	bool rightBackOK;
public:
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	SmartGyro* gyro;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	SpeedController* rightBack;
	SpeedController* leftBack;
	SpeedController* leftFront;
	SpeedController* rightFront;
	DriveTrain();
	void InitDefaultCommand();
	void MecanumDrive(float joystickX, float joystickY, float joystickTwist);
	void AutoFoward();
	void AutoReverse();
	void Stop();
	void AreWheelsOK();
	bool isGyroReady();
	
	bool isDriveTrainReady;
};
#endif
