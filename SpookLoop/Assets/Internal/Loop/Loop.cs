using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    [Header("Internals")]
    [SerializeField] private List<EventLocationCombo> values = new List<EventLocationCombo>();
    [SerializeField] private int CurrLoopLocation = 0;

    public void MoveLoopForward()
    {
        if (values.Count == 0) return;

        CurrLoopLocation = (CurrLoopLocation + 1) % values.Count;
    }

    public int GetCurrLoopIndex()
    {
        return CurrLoopLocation;
    }

    public int GetCurrLoopLength()
    {
        return values.Count;
    }

    public EventLocationCombo CurrEventLocationCombo()
    {
        return values[CurrLoopLocation];
    }
}
