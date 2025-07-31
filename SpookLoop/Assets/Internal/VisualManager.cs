using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    [Header("Setup")]
    public List<LocationVisual> locationVisuals = new List<LocationVisual>();
    public List<PersonVisual> personVisuals = new List<PersonVisual>();

    // Vector 2 for now because drawing in 2d
    public Vector2 GetDisplayLocationForGuestVisualAtLocation(HouseLocation location)
    {
        foreach (var locVis in locationVisuals)
        {
            if (locVis.houseLocation == location)
            {
                if (locVis.Visual != null)
                    return locVis.Visual.anchoredPosition;
                else
                    Debug.LogError("Visual RectTransform not assigned for " + LocationTypeHelper.GetDisplayName(location));
            }
        }
        Debug.LogError("Visual not setup for " + LocationTypeHelper.GetDisplayName(location));
        return Vector2.zero;
    }


    public void RenderPersonVisuals()
    {
        foreach (var person in personVisuals)
        {
            if (person.PersonRef == null || person.Visual == null)
            {
                Debug.Log("Person broken inside im going to cry");
                continue;
            }
            Vector2 targetPos = GetDisplayLocationForGuestVisualAtLocation(person.PersonRef.CurrLocation);
            person.Visual.anchoredPosition = targetPos;
        }
    }
}