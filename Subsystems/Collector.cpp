// RobotBuilder Version: 0.0.2
//
// This file was generated by RobotBuilder. It contains sections of
// code that are automatically generated and assigned by robotbuilder.
// These sections will be updated in the future when you export to
// C++ from RobotBuilder. Do not put any code or make any change in
// the blocks indicating autogenerated code or it will be lost on an
// update. Deleting the comments indicating the section will prevent
// it from being updated in th future.
#include "Collector.h"
#include "../Robotmap.h"
#include "../Commands/CollectorSensors.h"
#include "../Commands/DriveEncoders.h"
Collector::Collector() : Subsystem("Collector") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	pacManIR = RobotMap::collectorPacManIR;
	pacManFeeder = RobotMap::collectorPacManFeeder;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	WilliesSpeed2 = 0.00;
}
    
void Collector::InitDefaultCommand() {
	// Set the default command for a subsystem here.
	//SetDefaultCommand(new MySpecialCommand());
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
	//RobotMap::collectorPacManFeeder->Set( WilliesSpeed2 );
	//SetDefaultCommand(new CollectorSensors());
	//printf ("TESTING PLEASE SHOW UP!!!!\n");
	SetDefaultCommand(new DriveEncoders());
}
// Put methods for controlling this subsystem
// here. Call these from Commands.
void Collector::GetTheSensors()
{
	printf("this feature has been disabled/n");
	//float WillieHazSwag = pacManIR->Get();
	//float pacManVoltage = pacManFeeder->Get();
	//SmartDashboard::PutNumber("disk on the bed", (double) WillieHazSwag);
	//SmartDashboard::PutNumber("collector victor", (double) pacManVoltage);
}
void Collector::SetSpeed(float vicSpeed2)
{
	printf("this feature has been disabled/n");
	//WilliesSpeed2 = vicSpeed2;
	//pacManFeeder->Set( WilliesSpeed2 );
}
float Collector::GetSpeed()
{
	return ( WilliesSpeed2 );
}

