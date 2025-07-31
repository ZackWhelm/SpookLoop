public static class HauntEventTypeHelper
{
    public static string GetDisplayName(HauntEventType type)
    {
        switch (type)
        {
            case HauntEventType.FreezingTemps: return "Freezing Temps";
            case HauntEventType.Knocking: return "Knocking";
            case HauntEventType.DoorShake: return "Door Shake";
            case HauntEventType.DoorUnlockLock: return "Door Unlock/Lock";
            case HauntEventType.ItemShaking: return "Item Shaking";
            case HauntEventType.LightSwitchClick: return "Light Switch Click";
            default: return type.ToString();
        }
    }
}