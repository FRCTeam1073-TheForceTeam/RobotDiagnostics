/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#ifndef ROBOTMAP_H
#define ROBOTMAP_H
#include "WPILib.h"
#include "WPILibExtensions/WPILibExtensions.h"
/**
 * The RobotMap is a mapping from the ports sensors and actuators are wired into
 * to a variable name. This provides flexibility changing wiring, makes checking
 * the wiring easier and significantly reduces the number of magic numbers
 * floating around.
 */
class RobotMap {
public:
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	static SmartGyro* chasisSmartGyro1;
	static StallableAnalogEncoder* chasisbatteryCurrent;
	static StallableAnalogEncoder* chasisAnalogInput2;
	static SmartCANJaguar* driveTrainfrontLeft;
	static SmartCANJaguar* driveTrainfrontRight;
	static SmartCANJaguar* driveTrainrearLeft;
	static SmartCANJaguar* driveTrainrearRight;
	static RobotDrive* driveTrainRobotDrive;
	static Encoder* driveTrainQuadratureEncoder1;
	static Encoder* driveTrainQuadratureEncoder2;
	static Encoder* driveTrainQuadratureEncoder3;
	static Encoder* driveTrainQuadratureEncoder4;
	static Relay* driveTrainSpike1;
	static Relay* driveTrainRelaySolenoid1;
	static Relay* driveTrainRelaySolenoid2;
	static Relay* driveTrainRelaySolenoid3;
	static Compressor* driveTrainCompressor1;
	static DigitalInput* driveTrainDigitalInput1;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	static void init();
};
#endif
