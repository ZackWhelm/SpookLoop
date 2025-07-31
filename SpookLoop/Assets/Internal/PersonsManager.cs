using System.Collections.Generic;
using UnityEngine;

public class PersonsManager : MonoBehaviour
{
    [Header("Setup")]
    public List<Person> Persons = new List<Person>();

    public static PersonsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        InitPersons();
        VisualManager.Instance.RenderPersonVisuals();
    }

    public void InitPersons()
    {
        foreach (var person in Persons)
        {
            RoomsManager.Instance.AddPersonToRoomViaLocation(person, person.CurrLocation);
        }
    }

    public void HandleBetweenRoundsFearLogic()
    {
        foreach (var person in Persons)
        {
            if (!person.DidPersonGetFearedThisTurn())
            {
                person.ResetFearCombo();
            }
            person.ResetFearAddedForTurn();
        }
    }
}