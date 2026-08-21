using System;

public static class GasExperimentFlowTests
{
    private static int failures;

    public static int Main()
    {
        AdvancesThroughExhaustAndProductionByElapsedTime();
        RequiresBottleBeforeOverflow();
        AllowsFinishingOnlyAfterOverflowCompletes();
        LocksTheCompletedFlowAfterFinishIsPressed();
        ResetReturnsToIdle();

        if (failures == 0)
        {
            Console.WriteLine("PASS: GasExperimentFlow tests");
            return 0;
        }

        return 1;
    }

    private static void AdvancesThroughExhaustAndProductionByElapsedTime()
    {
        var flow = new GasExperimentFlow(2f, 3f, 1f);
        flow.Tick(2f, true, false);
        AssertEqual(GasExperimentPhase.ProducingGas, flow.Phase, "exhaust phase should finish after its configured duration");
        flow.Tick(3f, true, false);
        AssertEqual(GasExperimentPhase.ProducingGas, flow.Phase, "production should wait for the collection bottle");
    }

    private static void RequiresBottleBeforeOverflow()
    {
        var flow = new GasExperimentFlow(1f, 2f, 1f);
        flow.Tick(1f, true, false);
        flow.Tick(2f, true, true);
        AssertEqual(GasExperimentPhase.Overflowing, flow.Phase, "a correctly positioned bottle should unlock overflow after stable production");
        flow.Tick(1f, true, true);
        AssertEqual(GasExperimentPhase.Completed, flow.Phase, "overflow should end in a completed collection state");
    }

    private static void AllowsFinishingOnlyAfterOverflowCompletes()
    {
        var flow = new GasExperimentFlow(1f, 1f, 1f);
        flow.Tick(1f, true, false);
        flow.Tick(1f, true, true);
        AssertEqual(false, flow.CanFinishCollection, "the finish button must stay hidden while overflow is starting");
        flow.Tick(1f, true, true);
        AssertEqual(true, flow.CanFinishCollection, "the finish button must appear after collection succeeds");
    }
    private static void LocksTheCompletedFlowAfterFinishIsPressed()
    {
        var flow = new GasExperimentFlow(1f, 1f, 1f);
        flow.Tick(1f, true, false);
        flow.Tick(1f, true, true);
        flow.Tick(1f, true, true);
        flow.FinishCollection();
        AssertEqual(true, flow.IsCollectionFinished, "finishing collection must lock the completed flow");
    }
    private static void ResetReturnsToIdle()
    {
        var flow = new GasExperimentFlow(1f, 1f, 1f);
        flow.Tick(3f, true, true);
        flow.Reset();
        AssertEqual(GasExperimentPhase.Idle, flow.Phase, "reset must not retain a prior experiment's progress");
        AssertEqual(0f, flow.PhaseElapsed, "reset must clear phase time");
    }

    private static void AssertEqual<T>(T expected, T actual, string message)
    {
        if (!Equals(expected, actual))
        {
            failures++;
            Console.Error.WriteLine("FAIL: " + message + "; expected " + expected + ", actual " + actual);
        }
    }
}
