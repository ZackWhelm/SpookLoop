using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LoopRunner : MonoBehaviour
{
    [Header("Hooks")]
    public UnityEvent PreMoveHooks;

    [Header("Internals")]
    public Loop LoopToRun;

    public static LoopRunner Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private IEnumerator RunLoopForSteps(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            PreMoveHooks.Invoke();
            EventLocationCombo combo = LoopToRun.CurrEventLocationCombo();
            yield return EventRunner.Instance.RunEventLocationComboRoutine(combo, i);
            LoopToRun.MoveLoopForward();
            PersonsManager.Instance.HandleBetweenRoundsFearLogic();
        }
    }

    public bool TryRunLoopWithSteps(int passedSteps)
    {
        if (LoopToRun == null)
        {
            return false;
        }

        StartCoroutine(RunLoopForSteps(passedSteps));
        return true;
    }

    public void PassLoop(Loop loop)
    {
        LoopToRun = loop;
    }
}
