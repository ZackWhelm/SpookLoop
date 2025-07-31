public static class LocationTypeHelper
{
    public static string GetDisplayName(HouseLocation type)
    {
        switch (type)
        {
            case HouseLocation.MasterBedroom: return "Master Bedroom";
            case HouseLocation.SpareBedroom: return "Spare Bedroom";
            case HouseLocation.LivingRoom:    return "Living Room";
            case HouseLocation.Kitchen:       return "Kitchen";
            case HouseLocation.Hallway:       return "Hallway";
            case HouseLocation.Bathroom:      return "Bathroom";
            default: return type.ToString();
        }
    }
}