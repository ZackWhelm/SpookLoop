using System.Collections.Generic;
using UnityEngine;

public class FearCurrencyManager : MonoBehaviour
{
    [Header("Setup")]
    public int Fear = 0;
    public int MaxFearComboThisLoop = 0;
    public int FearGainedThisLoop = 0;
    public int MaxFearComboTotal = 0;

    public static FearCurrencyManager Instance
    { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Hooked into pre move hooks
    public void RefreshStats()
    {
        CheckMaxCombo();
        MaxFearComboThisLoop = 0;
        FearGainedThisLoop = 0;
    }

    public void CheckMaxCombo()
    {
        if (MaxFearComboThisLoop > MaxFearComboTotal)
        {
            MaxFearComboTotal = MaxFearComboThisLoop;
        }
    }
}