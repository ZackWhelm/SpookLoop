using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomsManager : MonoBehaviour
{
    [Header("Setup")]
    public List<Room> Rooms = new List<Room>();

    public static RoomsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        ValidateOneRoomForEachLocation();
    }

    private void ValidateOneRoomForEachLocation()
    {
        var grouped = Rooms.GroupBy(r => r.LocationRepresenting);
        foreach (var group in grouped)
        {
            if (group.Count() > 1)
            {
                Debug.LogError($"Multiple rooms assigned to location {group.Key}");
            }
        }

        foreach (HouseLocation loc in System.Enum.GetValues(typeof(HouseLocation)))
        {
            bool found = Rooms.Exists(r => r.LocationRepresenting == loc);
            if (!found)
            {
                Debug.LogError($"No room found for location {loc}");
            }
        }
    }

    public void AddPersonToRoomViaLocation(Person person, HouseLocation location)
    {
        Room targetRoom = Rooms.Find(r => r.LocationRepresenting == location);

        if (targetRoom != null)
        {
            person.CurrLocation = location;
            targetRoom.AddPerson(person);
        }
        else
        {
            Debug.LogError($"No room found for location {location} when trying to add person.");
        }
    }

    public void HandlePersonMovesBetweenRooms(Person person, Room to, Room from)
    {
        person.CurrLocation = to.LocationRepresenting;
        to.AddPerson(person);
        from.RemovePerson(person);
    }

    public void HandleEventAtLocation(Event ev, HouseLocation loc, int global_step)
    {
        Room targetRoom = Rooms.Find(r => r.LocationRepresenting == loc);
        targetRoom.TriggerFearForPersonsInRoom(ev.ScareValue, global_step);
    }
}