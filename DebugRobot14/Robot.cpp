/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "Robot.h"
// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=INITIALIZATION
DriveTrain* Robot::driveTrain = 0;
Launcher* Robot::launcher = 0;
Collector* Robot::collector = 0;
Shifter* Robot::shifter = 0;
RobotRangeFinder* Robot::robotRangeFinder = 0;
Elevator* Robot::elevator = 0;
DataSending* Robot::dataSending = 0;
OI* Robot::oi = 0;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=INITIALIZATION
void Robot::RobotInit() {
	RobotMap::init();
	count=1;
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
	driveTrain = new DriveTrain();
	launcher = new Launcher();
	collector = new Collector();
	shifter = new Shifter();
	robotRangeFinder = new RobotRangeFinder();
	elevator = new Elevator();
	dataSending = new DataSending();
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
	// keep this here
	oi = new OI();
	lw = LiveWindow::GetInstance();
	// instantiate the command used for the autonomous period
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=AUTONOMOUS
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=AUTONOMOUS
	printf("\n\nFRC2014 " __DATE__ " " __TIME__ "\n\n" __FILE__ "\n\n");
  }
	
void Robot::AutonomousInit() {
	if (autonomousCommand != NULL)
		autonomousCommand->Start();
}
	
void Robot::AutonomousPeriodic() {
	Scheduler::GetInstance()->Run();
	if(count%5==0)
		Robot::dataSending->SendTheData();
	count++;
}
	
void Robot::TeleopInit() {
	autonomousCommand->Cancel();
}
	
void Robot::TeleopPeriodic() {
	if (autonomousCommand != NULL)
		Scheduler::GetInstance()->Run();
	if(count%5==0)
		Robot::dataSending->SendTheData();
	count++;
}
void Robot::TestPeriodic() {
	lw->Run();
	if(count%5==0)
		Robot::dataSending->SendTheData();
	count++;
}
void Robot::DisabledPeriodic() {
	if(count%5==0)
		Robot::dataSending->SendTheData();
	count++;
}
START_ROBOT_CLASS(Robot);
