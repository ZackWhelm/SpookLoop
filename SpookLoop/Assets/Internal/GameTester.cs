using System.Collections;
using UnityEngine;

public class GameTester : MonoBehaviour
{
    [Header("Setup")]
    public Loop loopToRun;
    public int currLoopSteps = 12;

    public void TriggerLoopStart()
    {
        LoopRunner.Instance.PassLoop(loopToRun);
        if (!LoopRunner.Instance.TryRunLoopWithSteps(currLoopSteps))
        {
            Debug.Log("Error with TryRunLoopWithSteps");
        }
    }
    

}
