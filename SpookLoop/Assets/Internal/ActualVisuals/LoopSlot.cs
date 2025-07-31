using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoopSlot : MonoBehaviour, IDropHandler
{
    [Header("Setup")]
    public float Width;
    public float Height;
    public float OffsetFromCenterForEventCard = 50f;
    public float OffsetFromCenterForLocationCard = 50f;

    public Image slotVisual;

    public EventLocationCombo Combo { get; private set; } = new EventLocationCombo();

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out EventCard eventCard))
        {
            Combo.ev = eventCard.eventData;

            eventCard.MarkDropped(this);
            eventCard.transform.SetParent(transform);
            eventCard.transform.localPosition = new Vector3(0f, OffsetFromCenterForEventCard, 0f);
        }
        else if (eventData.pointerDrag.TryGetComponent(out LocationCard locationCard))
        {
            Combo.location = locationCard.locationData;

            locationCard.MarkDropped(this);
            locationCard.transform.SetParent(transform);
            locationCard.transform.localPosition = new Vector3(0f, OffsetFromCenterForLocationCard, 0f);
        }

        RefreshVisual();
    }

    private void RefreshVisual()
    {
        string eventName = Combo.ev != null ? Combo.ev.EventType.ToString() : "None";
        string locName = Combo.location != null ? Combo.location.LocationType.ToString() : "None";
        Debug.Log($"Slot Combo: {eventName} in {locName}");
    }

    public void ClearCardReference(Card card)
    {
        if (card is EventCard)
        {
            Combo.ev = null;
        }
        else if (card is LocationCard)
        {
            Combo.location = null;
        }

        RefreshVisual();
    }
}