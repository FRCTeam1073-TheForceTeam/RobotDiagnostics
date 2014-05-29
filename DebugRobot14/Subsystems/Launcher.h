/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#ifndef LAUNCHER_H
#define LAUNCHER_H
#include "Commands/Subsystem.h"
#include "WPILib.h"
#include "../WPILibExtensions/WPILibExtensions.h"
class Launcher: public Subsystem {
private:
	int willCompress;
public:
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	Solenoid* solenoidLeft;
	Solenoid* solenoidRight;
	Compressor* compressor;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	AnalogPressureTransducer* pressureTransducer;
	Launcher();
	void InitDefaultCommand();
	void Launch();
	void Compress();
	void StopLauch();
};
#endif
