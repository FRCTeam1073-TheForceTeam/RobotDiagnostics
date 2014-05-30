/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "autoCollector.h"
#include "autoElevator.h"
#include "autoDriveTrain.h"
#include "autoLauncher.h"
#include "autoShiftToHigh.h"
#include "autoShiftToLow.h"
#include "autonomousCommandGroup.h"
#include "isRobotReady.h"
autonomousCommandGroup::autonomousCommandGroup() {
	AddSequential(new autoShiftToLow());
	AddSequential(new autoDriveTrain());
	AddSequential(new autoShiftToHigh());
	AddSequential(new autoDriveTrain());
	AddSequential(new autoShiftToLow());
	AddSequential(new autoElevator());
	AddSequential(new autoCollector());
	AddSequential(new autoLauncher());
	AddSequential(new isRobotReady());
	// Add Commands here:
	// e.g. AddSequential(new Command1());
	//      AddSequential(new Command2());
	// these will run in order.

	// To run multiple commands at the same time,
	// use AddParallel()
	// e.g. AddParallel(new Command1());
	//      AddSequential(new Command2());
	// Command1 and Command2 will run in parallel.

	// A command group will require all of the subsystems that each member
	// would require.
	// e.g. if Command1 requires chassis, and Command2 requires arm,
	// a CommandGroup containing them would require both the chassis and the
	// arm.
}
