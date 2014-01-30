/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "RobotMap.h"
#include "LiveWindow/LiveWindow.h"
#include "Commands/sendData.h"
// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=ALLOCATION
SmartCANJaguar* RobotMap::driveTrainFrontLeft = NULL;
SmartCANJaguar* RobotMap::driveTrainFrontRight = NULL;
SmartCANJaguar* RobotMap::driveTrainRearLeft = NULL;
SmartCANJaguar* RobotMap::driveTrainRearRight = NULL;
RobotDrive* RobotMap::driveTrainRobotDrive = NULL;
SmartGyro* RobotMap::driveTrainDriveGyro = NULL;
DoubleSolenoid* RobotMap::shifterSystemShifterSolenoid = NULL;
Solenoid* RobotMap::launcherLauncherSolenoid = NULL;
StallableAnalogEncoder* RobotMap::dataSendingbatteryCurrent = NULL;
Compressor* RobotMap::compressionCompressor = NULL;
Servo* RobotMap::collectorAngleAdjuster = NULL;
DigitalInput* RobotMap::collectorHighLimit = NULL;
DigitalInput* RobotMap::collectorLowLimit = NULL;
StallableAnalogEncoder* RobotMap::collectorElevationEncoder = NULL;
SpeedController* RobotMap::collectorLeftCollect = NULL;
SpeedController* RobotMap::collectorRightCollect = NULL;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=ALLOCATION
void RobotMap::init() {
	
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
	LiveWindow* lw = LiveWindow::GetInstance();
	driveTrainFrontLeft = new SmartCANJaguar(2);
	
	
	driveTrainFrontRight = new SmartCANJaguar(5);
	
	
	driveTrainRearLeft = new SmartCANJaguar(3);
	
	
	driveTrainRearRight = new SmartCANJaguar(4);
	
	
	driveTrainRobotDrive = new RobotDrive(driveTrainFrontLeft, driveTrainRearLeft,
              driveTrainFrontRight, driveTrainRearRight);
	
	driveTrainRobotDrive->SetSafetyEnabled(false);
        driveTrainRobotDrive->SetExpiration(0.1);
        driveTrainRobotDrive->SetSensitivity(0.5);
        driveTrainRobotDrive->SetMaxOutput(1.0);
	driveTrainDriveGyro = new SmartGyro(1, 1);
	lw->AddSensor("Drive Train", "DriveGyro", driveTrainDriveGyro);
	driveTrainDriveGyro->SetSensitivity(0.007);
	shifterSystemShifterSolenoid = new DoubleSolenoid(1, 2, 3);      
	
	
	launcherLauncherSolenoid = new Solenoid(1, 1);
	lw->AddActuator("Launcher", "LauncherSolenoid", launcherLauncherSolenoid);
	
	dataSendingbatteryCurrent = new StallableAnalogEncoder(1, 3);
	lw->AddSensor("DataSending", "batteryCurrent", dataSendingbatteryCurrent);
	
	compressionCompressor = new Compressor(1, 1, 1, 1);
	
	
	collectorAngleAdjuster = new Servo(1, 1);
	lw->AddActuator("Collector", "AngleAdjuster", collectorAngleAdjuster);
	
	collectorHighLimit = new DigitalInput(1, 2);
	lw->AddSensor("Collector", "HighLimit", collectorHighLimit);
	
	collectorLowLimit = new DigitalInput(1, 3);
	lw->AddSensor("Collector", "LowLimit", collectorLowLimit);
	
	collectorElevationEncoder = new StallableAnalogEncoder(1, 2);
	lw->AddSensor("Collector", "ElevationEncoder", collectorElevationEncoder);
	
	collectorLeftCollect = new Talon(1, 2);
	lw->AddActuator("Collector", "LeftCollect", (Talon*) collectorLeftCollect);
	
	collectorRightCollect = new Talon(1, 3);
	lw->AddActuator("Collector", "RightCollect", (Talon*) collectorRightCollect);
	
	}
