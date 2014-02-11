/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#ifndef SHIFTER_H
#define SHIFTER_H
#include "Commands/Subsystem.h"
#include "WPILib.h"
#include "../WPILibExtensions/WPILibExtensions.h"
class Shifter: public Subsystem {
private:
public:
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	DoubleSolenoid* doubleSolenoid;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	Shifter();
	void InitDefaultCommand();
	void Shift();
};
#endif
