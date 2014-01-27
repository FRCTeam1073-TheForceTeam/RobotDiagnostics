/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "ShifterSystem.h"
#include "../Robotmap.h"
bool lowGear;
ShifterSystem::ShifterSystem() : Subsystem("ShifterSystem") {
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	shifterSolenoid = RobotMap::shifterSystemShifterSolenoid;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
}
    
void ShifterSystem::InitDefaultCommand() {
	// Set the default command for a subsystem here.
	//SetDefaultCommand(new MySpecialCommand());
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DEFAULT_COMMAND
	shifterSolenoid->Set(DoubleSolenoid::kOff);
}
// Put methods for controlling this subsystem
// here. Call these from Commands.
int ShifterSystem::GetGearSetting(){
	//printf("Getting Gear Setting...\n");
	if(shifterSolenoid->Get()==DoubleSolenoid::kForward){
		//printf("yes it is in low\n");
		return -1;
	}
	if(shifterSolenoid->Get()==DoubleSolenoid::kReverse){
		//printf("yes it is in high\n");
		return 1;
	}
	if(shifterSolenoid->Get()==DoubleSolenoid::kOff){
		//printf("yes it is off\n");
		return 0;
	}
	return 0;
}
void ShifterSystem::Shift(){
	bool changed=false;
	if(shifterSolenoid->Get()==DoubleSolenoid::kOff){
		shifterSolenoid->Set(DoubleSolenoid::kForward);
		changed=true;
	}
	if(shifterSolenoid->Get()==DoubleSolenoid::kForward&&!changed){
		shifterSolenoid->Set(DoubleSolenoid::kReverse);
		changed=true;
	}
	if(shifterSolenoid->Get()==DoubleSolenoid::kReverse&&!changed)
		shifterSolenoid->Set(DoubleSolenoid::kForward);
}
