using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("Internals")]
    public string DisplayName = "Bob";
    public PersonVisual Visual;

    public HouseLocation CurrLocation;
}
