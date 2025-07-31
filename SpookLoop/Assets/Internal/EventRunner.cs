using System.Collections;
using UnityEngine;

public class EventRunner : MonoBehaviour
{
    public static EventRunner Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public IEnumerator RunEventLocationComboRoutine(EventLocationCombo combo, int step)
    {
        if (combo == null)
        {
            Debug.LogError("combo is null.");
            yield break;
        }
        Debug.Log("-------------------Event Running during step " + step+ " ---------------------");
        Debug.Log("Step " + step + " : Triggered " + HauntEventTypeHelper.GetDisplayName(combo.ev.EventType) + " at " + LocationTypeHelper.GetDisplayName(combo.location.LocationType) + ".");

        HandleEventAtLocation(combo.ev, combo.location, step);
        yield return new WaitForSeconds(0.5f);
    }

    public void HandleEventAtLocation(Event ev, Location loc, int global_step)
    {
        Debug.Log("--- Event Handling for step " +  global_step + " ---");
        RoomsManager.Instance.HandleEventAtLocation(ev, loc.LocationType, global_step);
    }
}