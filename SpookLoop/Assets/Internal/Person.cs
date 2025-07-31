using UnityEngine;
using System.Collections.Generic;

public class Person : MonoBehaviour
{
    [Header("Internals")]
    public string DisplayName = "Bob";
    public PersonVisual Visual;
    public HouseLocation CurrLocation;

    // 0 / 1 and above /  3 and above  / 5 and above 
    // Every 2 steps a person doesn't get scared reduce down by 1  
    // TODO (add fear state) calm / spooked / scared / terrified (maybe 3 fears to go from spooked to scared -> terrified)
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

    // I think i'll need to store recent haunt data (door shaking) to dictate where a fleeing person would go and if they should move
    // also will need to keep track of recent haunt locations to make persons don't go back into a scary room they recently went into. 
    public void TryMoveFromCurrRoom()
    {
        Room currRoom = RoomsManager.Instance.GetRoomRepresentingLoc(CurrLocation);
        List<HouseLocation> nextLocations = RoomsManager.Instance.GetConnectedRoomsToLocation(CurrLocation);

        if (nextLocations == null || nextLocations.Count == 0)
            return;

        HouseLocation nextLocation = nextLocations[Random.Range(0, nextLocations.Count)];
        Room nextRoom = RoomsManager.Instance.GetRoomRepresentingLoc(nextLocation);

        RoomsManager.Instance.HandlePersonMovesBetweenRooms(this, nextRoom, currRoom);
    }
}
