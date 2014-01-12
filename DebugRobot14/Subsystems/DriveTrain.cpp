/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "DriveTrain.h"
#include "../Robotmap.h"
DriveTrain::DriveTrain() : Subsystem("DriveTrain") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	frontLeft = RobotMap::driveTrainfrontLeft;
	frontRight = RobotMap::driveTrainfrontRight;
	rearLeft = RobotMap::driveTrainrearLeft;
	rearRight = RobotMap::driveTrainrearRight;
	robotDrive = RobotMap::driveTrainRobotDrive;
	quadratureEncoder1 = RobotMap::driveTrainQuadratureEncoder1;
	quadratureEncoder2 = RobotMap::driveTrainQuadratureEncoder2;
	quadratureEncoder3 = RobotMap::driveTrainQuadratureEncoder3;
	quadratureEncoder4 = RobotMap::driveTrainQuadratureEncoder4;
	spike1 = RobotMap::driveTrainSpike1;
	relaySolenoid1 = RobotMap::driveTrainRelaySolenoid1;
	relaySolenoid2 = RobotMap::driveTrainRelaySolenoid2;
	relaySolenoid3 = RobotMap::driveTrainRelaySolenoid3;
	compressor1 = RobotMap::driveTrainCompressor1;
	digitalInput1 = RobotMap::driveTrainDigitalInput1;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
}
    
void DriveTrain::InitDefaultCommand() {
	// Set the default command for a subsystem here.
	//SetDefaultCommand(new MySpecialCommand());
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
}
// Put methods for controlling this subsystem
// here. Call these from Commands.