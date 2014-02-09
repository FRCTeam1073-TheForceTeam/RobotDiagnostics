/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "OI.h"
// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=INCLUDES
#include "SmartDashboard/SmartDashboard.h"
#include "Commands/AutonomousCommand.h"
#include "Commands/angleDown.h"
#include "Commands/angleUp.h"
#include "Commands/collectFaster.h"
#include "Commands/collectSlower.h"
#include "Commands/compress.h"
#include "Commands/drive.h"
#include "Commands/driveArcarde.h"
#include "Commands/launch.h"
#include "Commands/shift.h"
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=INCLUDES
OI::OI() {
	// Process operator interface input here.
        // BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
	joystick1 = new SmartJoystick(1);
	
	arcadeDriveButton = new JoystickButton(joystick1, 5);
	arcadeDriveButton->WhenPressed(new driveArcarde());
	collectSlowerButton = new JoystickButton(joystick1, 12);
	collectSlowerButton->WhenPressed(new collectSlower());
	collectFasterButton = new JoystickButton(joystick1, 11);
	collectFasterButton->WhenPressed(new collectFaster());
	angleDownButton = new JoystickButton(joystick1, 11);
	angleDownButton->WhenPressed(new angleDown());
	angleUpButton = new JoystickButton(joystick1, 9);
	angleUpButton->WhenPressed(new angleUp());
	shiftButton = new JoystickButton(joystick1, 8);
	shiftButton->WhenPressed(new shift());
	launchBall = new JoystickButton(joystick1, 6);
	launchBall->WhenPressed(new launch());
	mecanumDriveButton = new JoystickButton(joystick1, 4);
	mecanumDriveButton->WhenPressed(new drive());
	compressButton = new JoystickButton(joystick1, 2);
	compressButton->WhenPressed(new compress());
     
        // SmartDashboard Buttons
	SmartDashboard::PutData("Autonomous Command", new AutonomousCommand());
	SmartDashboard::PutData("compress", new compress());
	SmartDashboard::PutData("drive", new drive());
	SmartDashboard::PutData("driveArcarde", new driveArcarde());
	SmartDashboard::PutData("launch", new launch());
	SmartDashboard::PutData("angleDown", new angleDown());
	SmartDashboard::PutData("collectFaster", new collectFaster());
	SmartDashboard::PutData("collectSlower", new collectSlower());
	SmartDashboard::PutData("shift", new shift());
	SmartDashboard::PutData("angleUp", new angleUp());
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=CONSTRUCTORS
}
// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=FUNCTIONS
SmartJoystick* OI::getJoystick1() {
	return joystick1;
}
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=FUNCTIONS
