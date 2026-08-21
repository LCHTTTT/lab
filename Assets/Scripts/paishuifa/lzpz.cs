using UnityEngine;
using UnityEngine.UI;

public class lzpz : MonoBehaviour
{
    public static int pzjs = 0;
    public static int jg = 0;
    public static int jqb = 0;
    public static int ypqtgb = 0;
    public static bool CollectionCompleted { get; private set; }

    public Button jqbtn, hcbtn;
    public GameObject d, pnqt, ypqt, ycqt;
    public InputField yp;
    public GameObject TagerObject;

    [Header("Stable experiment timing (seconds)")]
    [SerializeField] private float exhaustAirDuration = 3f;
    [SerializeField] private float gasCollectionDuration = 6f;
    [SerializeField] private float overflowDuration = 2f;

    private static lzpz activeController;
    private GasExperimentFlow flow;
    private bool hasFireReachedTestTube;
    private bool finishButtonShown;

    private void Awake()
    {
        activeController = this;
        flow = new GasExperimentFlow(exhaustAirDuration, gasCollectionDuration, overflowDuration);
    }

    private void Start()
    {
        ResetExperimentFlow();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.name == "TestTube")
        {
            hasFireReachedTestTube = true;
            pzjs += 1;
        }
    }

    private void Update()
    {
        bool isHeating = fire.fireflag == 1 && hasFireReachedTestTube;
        bool isBottleInPlace = jqpguding.jqpflag == 1;

        flow.Tick(Time.deltaTime, isHeating, isBottleInPlace);
        CollectionCompleted = flow.CanFinishCollection;
        if (flow.IsCollectionFinished)
        {
            StopAllParticles();
            return;
        }

        ApplyParticleEffects(isHeating);
        ShowFinishCollectionButtonWhenReady();
    }

    public static void FinishCollection()
    {
        if (activeController != null)
        {
            activeController.flow.FinishCollection();
        }
    }
    public void ResetExperimentFlow()
    {
        ResetSharedState();
        hasFireReachedTestTube = false;
        finishButtonShown = false;
        flow.Reset();
        StopAllParticles();
    }

    public static void ResetSharedState()
    {
        pzjs = 0;
        jg = 0;
        jqb = 0;
        ypqtgb = 0;
        CollectionCompleted = false;
        ypqtlzpz.ypqt = 0;
        yichu.ycqtgb = 0;
    }

    private void ApplyParticleEffects(bool isHeating)
    {
        if (!isHeating || flow.Phase == GasExperimentPhase.Idle)
        {
            StopAllParticles();
            return;
        }

        if (flow.Phase == GasExperimentPhase.ExhaustingAir)
        {
            SetParticleState(pnqt, true);
            SetParticleState(ypqt, false);
            SetParticleState(ycqt, false);
            return;
        }

        if (flow.Phase == GasExperimentPhase.ProducingGas)
        {
            SetParticleState(pnqt, false);
            SetParticleState(ypqt, true);
            SetParticleState(ycqt, false);
            return;
        }

        SetParticleState(pnqt, false);
        SetParticleState(ypqt, false);
        SetParticleState(ycqt, true);
    }

    private void StopAllParticles()
    {
        SetParticleState(pnqt, false);
        SetParticleState(ypqt, false);
        SetParticleState(ycqt, false);
    }

    private void ShowFinishCollectionButtonWhenReady()
    {
        if (!finishButtonShown && flow.CanFinishCollection)
        {
            jqbtn.gameObject.SetActive(true);
            finishButtonShown = true;
        }
    }
    private static void SetParticleState(GameObject particleObject, bool shouldPlay)
    {
        ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
        if (shouldPlay)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else if (particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }
}