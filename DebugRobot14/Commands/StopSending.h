/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */


#ifndef STOPSENDING_H
#define STOPSENDING_H


#include "Commands/Subsystem.h"
#include "../Robot.h"
#include "WPILib.h"
#include "../WPILibExtensions/WPILibExtensions.h"

class StopSending: public Command {
public:
	StopSending();
	virtual void Initialize();
	virtual void Execute();
	virtual bool IsFinished();
	virtual void End();
	virtual void Interrupted();
};

#endif
