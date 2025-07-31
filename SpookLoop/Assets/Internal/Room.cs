using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    [Header("Setup")]
    public HouseLocation LocationRepresenting;
    public List<HouseLocation> ConnectedHouseLocations = new List<HouseLocation>();
    public List<HouseLocation> AdjacentHouseLocations = new List<HouseLocation>();

    [Header("Internals")]
    public List<Person> PersonsInRoom = new List<Person>();

    public void AddPerson(Person person)
    {
        PersonsInRoom.Add(person);
    }

    public void RemovePerson(Person person)
    {
        if (PersonsInRoom.Contains(person))
        {
            PersonsInRoom.Remove(person);
        }
        else
        {
            Debug.LogError("Why are we removing non existant - person");
        }
    }

    public void TriggerFearForPersonsInRoom(int fear, int global_step)
    {
        Debug.Log("TriggerFearForPersonsInRoom (" + fear + "," + LocationRepresenting + " ) at step" + global_step);
        foreach (Person person in PersonsInRoom)
        {
            person.AddFear(fear);
        }
    }
}
