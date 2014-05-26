/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#ifndef DATASENDING_H
#define DATASENDING_H
#include "Commands/Subsystem.h"
#include "WPILib.h"
#include "../WPILibExtensions/WPILibExtensions.h"
class DataSending: public Subsystem {
private:
public:
	// BEGIN AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	StallableAnalogEncoder* batteryCurrent;
    // END AUTOGENERATED CODE, SOURCE=ROBOTBUILDER ID=DECLARATIONS
	DataSending();
	void InitDefaultCommand();
	void SendTheData();
	string GetGearSetting();
	int timesPerSecond;
private:
	int count;
	void Send(bool b);
	void Send(double f, int digs=3);
	void Send(int i);
	void Send(char *);
	static const int MaxBuffer = 1000;
	char strBuffer[MaxBuffer];
	int strIndex;
	void UpdateUserLCD();
	void GetVicInfo();
	void GetDriveJoystickInfo();
	void GetOperatorJoystickInfo();
};
#endif
