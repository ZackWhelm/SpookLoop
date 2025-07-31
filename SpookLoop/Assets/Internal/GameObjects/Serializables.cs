using System;
using UnityEngine;

[Serializable]
public class EventLocationCombo
{
    public Event ev;
    public Location location;
}

[Serializable]
public class Event
{
    public HauntEventType EventType;
    public int ScareValue = 1;
}

[Serializable]
public class Location
{
    public HouseLocation LocationType;
}

public enum HauntEventType
{
    FreezingTemps,
    Knocking,
    DoorShake,
    DoorUnlockLock,
    ItemShaking,
    LightSwitchClick
}

public enum HouseLocation
{
    MasterBedroom,
    SpareBedroom,
    LivingRoom,
    Kitchen,
    Hallway,
    Bathroom
}