public enum GasExperimentPhase
{
    Idle,
    ExhaustingAir,
    ProducingGas,
    Overflowing,
    Completed
}

public sealed class GasExperimentFlow
{
    private readonly float exhaustDuration;
    private readonly float productionDuration;
    private readonly float overflowDuration;

    public GasExperimentPhase Phase { get; private set; }
    public float PhaseElapsed { get; private set; }
    public bool CanFinishCollection { get { return Phase == GasExperimentPhase.Completed; } }
    public bool IsCollectionFinished { get; private set; }

    public GasExperimentFlow(float exhaustDuration, float productionDuration, float overflowDuration)
    {
        this.exhaustDuration = exhaustDuration;
        this.productionDuration = productionDuration;
        this.overflowDuration = overflowDuration;
        Reset();
    }

    public void Tick(float deltaTime, bool isHeating, bool isBottleInPlace)
    {
        if (!isHeating || deltaTime <= 0f || Phase == GasExperimentPhase.Completed || IsCollectionFinished)
        {
            return;
        }

        if (Phase == GasExperimentPhase.Idle)
        {
            Phase = GasExperimentPhase.ExhaustingAir;
            PhaseElapsed = 0f;
        }

        if (Phase == GasExperimentPhase.ExhaustingAir)
        {
            Advance(deltaTime, exhaustDuration, GasExperimentPhase.ProducingGas);
            return;
        }

        if (Phase == GasExperimentPhase.ProducingGas)
        {
            if (isBottleInPlace)
            {
                Advance(deltaTime, productionDuration, GasExperimentPhase.Overflowing);
            }
            return;
        }

        if (Phase == GasExperimentPhase.Overflowing)
        {
            Advance(deltaTime, overflowDuration, GasExperimentPhase.Completed);
        }
    }

    public void FinishCollection()
    {
        if (CanFinishCollection)
        {
            IsCollectionFinished = true;
        }
    }

    public void Reset()
    {
        IsCollectionFinished = false;
        Phase = GasExperimentPhase.Idle;
        PhaseElapsed = 0f;
    }

    private void Advance(float deltaTime, float duration, GasExperimentPhase nextPhase)
    {
        PhaseElapsed += deltaTime;
        if (PhaseElapsed >= duration)
        {
            Phase = nextPhase;
            PhaseElapsed = 0f;
        }
    }
}
