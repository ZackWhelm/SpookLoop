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
}

[Serializable]
public class Location
{
    public HouseLocation DisplayName;
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