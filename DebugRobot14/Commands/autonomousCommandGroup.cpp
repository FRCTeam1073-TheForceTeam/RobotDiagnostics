/* FIRST Team 1073's RobotBuilder (0.0.2) for WPILibExtensions ---
Do not mix this code with any other version of RobotBuilder! */
#include "autoCollector.h"
#include "autoElevator.h"
#include "autoDriveTrain.h"
#include "autoLauncher.h"
#include "autoShiftToHigh.h"
#include "autoShiftToLow.h"
#include "autonomousCommandGroup.h"
autonomousCommandGroup::autonomousCommandGroup() {
	puts("Starting Self-Diagnostic Test...\n");
	Wait(1);
	puts("Shifting to Low Gear...\n");
	AddSequential(new autoShiftToLow());
	puts("Testing the drive Train..\n");
	AddSequential(new autoDriveTrain());
	puts("Shifting to High...\n");
	AddSequential(new autoShiftToHigh());
	puts("Testing the Drive Train in high...\n");
	AddSequential(new autoDriveTrain());
	puts("Shifting back to low...\n");
	AddSequential(new autoShiftToLow());
	puts("Testing the elevator...\n");
	AddSequential(new autoElevator());
	puts("Testing the Collector...\n");
	AddSequential(new autoCollector());
	puts("Testing the Laucher...\n");
	AddSequential(new autoLauncher());
	puts("Self-Diagnostic Test Complete!\n");
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
