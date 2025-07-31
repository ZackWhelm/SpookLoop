using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("Internals")]
    public string DisplayName = "Bob";
    public PersonVisual Visual;
    public HouseLocation CurrLocation;

    public int CurrentFear = 0;
    public int FearAddedThisTurn = 0;
    public int FearCombo = 0;

    public void AddFear(int fear)
    {
        CurrentFear += fear;
        FearAddedThisTurn += fear;
        FearCombo += fear;
        FearCurrencyManager.Instance.FearGainedThisLoop += fear;
        FearCurrencyManager.Instance.Fear += fear;
    }

    public void ResetFearAddedForTurn()
    {
        FearAddedThisTurn = 0;
    }

    public bool DidPersonGetFearedThisTurn()
    {
        if (FearAddedThisTurn == 0)
        {
            return false;
        }
        return true;
    }

    public void ResetFearCombo()
    {
        if (FearCombo > FearCurrencyManager.Instance.MaxFearComboThisLoop)
        {
            FearCurrencyManager.Instance.MaxFearComboThisLoop = FearCombo;
        }
        FearCombo = 0;
    }
}
