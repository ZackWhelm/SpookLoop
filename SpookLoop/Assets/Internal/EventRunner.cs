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


        Debug.Log("Triggered " + HauntEventTypeHelper.GetDisplayName(combo.ev.EventType)+ " at " + combo.location.DisplayName + " at  step " + step);
        yield return new WaitForSeconds(0.5f);
    }
}