using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Traits")]
    public LoopSlot Slot = null;

    protected Transform originalParent;
    protected CanvasGroup canvasGroup;
    protected bool wasDroppedOnSlot = false;

    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        wasDroppedOnSlot = false;

        if (Slot != null)
        {
            Slot.ClearCardReference(this);
            Slot = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!wasDroppedOnSlot)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }

        canvasGroup.blocksRaycasts = true;
    }

    public void MarkDropped(LoopSlot newSlot)
    {
        wasDroppedOnSlot = true;
        Slot = newSlot;
    }
}