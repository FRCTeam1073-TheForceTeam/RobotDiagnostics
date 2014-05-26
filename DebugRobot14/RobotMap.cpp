/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "RobotMap.h"
#include "LiveWindow/LiveWindow.h"
// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=ALLOCATION
SmartGyro* RobotMap::driveTrainGyro = NULL;
SpeedController* RobotMap::driveTrainRightBack = NULL;
SpeedController* RobotMap::driveTrainLeftBack = NULL;
SpeedController* RobotMap::driveTrainLeftFront = NULL;
SpeedController* RobotMap::driveTrainRightFront = NULL;
Solenoid* RobotMap::launcherSolenoidLeft = NULL;
Solenoid* RobotMap::launcherSolenoidRight = NULL;
Compressor* RobotMap::launcherCompressor = NULL;
SpeedController* RobotMap::collectorLeftRoller = NULL;
SpeedController* RobotMap::collectorRightRoller = NULL;
DoubleSolenoid* RobotMap::shifterDoubleSolenoid = NULL;
StallableAnalogEncoder* RobotMap::robotRangeFinderUltrasonicSensor = NULL;
SpeedController* RobotMap::elevatorAngleAdjuster = NULL;
StallableAnalogEncoder* RobotMap::dataSendingBatteryCurrent = NULL;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=ALLOCATION
AnalogPressureTransducer* RobotMap::launcherPressureSwitch = NULL;
void RobotMap::init() {
	
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
	LiveWindow* lw = LiveWindow::GetInstance();
	driveTrainGyro = new SmartGyro(1, 1);
	lw->AddSensor("Drive Train", "Gyro", driveTrainGyro);
	driveTrainGyro->SetSensitivity(0.007);
	driveTrainRightBack = new SmartVictor(1, 6);
	lw->AddActuator("Drive Train", "Right Back", (SmartVictor*) driveTrainRightBack);
	
	driveTrainLeftBack = new SmartVictor(1, 7);
	lw->AddActuator("Drive Train", "Left Back", (SmartVictor*) driveTrainLeftBack);
	
	driveTrainLeftFront = new SmartVictor(1, 4);
	lw->AddActuator("Drive Train", "Left Front", (SmartVictor*) driveTrainLeftFront);
	
	driveTrainRightFront = new SmartVictor(1, 5);
	lw->AddActuator("Drive Train", "Right Front", (SmartVictor*) driveTrainRightFront);
	
	launcherSolenoidLeft = new Solenoid(1, 1);
	lw->AddActuator("Launcher", "SolenoidLeft", launcherSolenoidLeft);
	
	launcherSolenoidRight = new Solenoid(1, 4);
	lw->AddActuator("Launcher", "SolenoidRight", launcherSolenoidRight);
	
	launcherCompressor = new Compressor(1, 1, 1, 1);
	
	
	collectorLeftRoller = new Talon(1, 2);
	lw->AddActuator("Collector", "Left Roller", (Talon*) collectorLeftRoller);
	
	collectorRightRoller = new Talon(1, 3);
	lw->AddActuator("Collector", "Right Roller", (Talon*) collectorRightRoller);
	
	shifterDoubleSolenoid = new DoubleSolenoid(1, 2, 3);      
	
	
	robotRangeFinderUltrasonicSensor = new StallableAnalogEncoder(1, 4);
	lw->AddSensor("RobotRangeFinder", "UltrasonicSensor", robotRangeFinderUltrasonicSensor);
	
	
	elevatorAngleAdjuster = new Jaguar(1, 1);
	lw->AddActuator("Elevator", "Angle Adjuster", (Jaguar*) elevatorAngleAdjuster);
	
	dataSendingBatteryCurrent = new StallableAnalogEncoder(1, 5);
	lw->AddSensor("DataSending", "BatteryCurrent", dataSendingBatteryCurrent);
	
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
	launcherPressureSwitch = new AnalogPressureTransducer(1, 6);
	lw->AddActuator("Launcher", "PressureSwitch", launcherPressureSwitch);
	}
