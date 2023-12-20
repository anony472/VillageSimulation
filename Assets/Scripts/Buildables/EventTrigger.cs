using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public enum type {
        Hut,
        Hospital,
        BiogasPlant,
        School,
        Farm,
        Factory,
        Windmill
    }
     public type me;
     public void Placed()
     {
        if (me == type.Hut)
        {
            EventsAndStuff.TriggerHutSpawnedEvent(gameObject);
        }
        else if (me == type.Hospital)
        {
            EventsAndStuff.TriggerHospitalSpawnedEvent(gameObject);
        }
        else if (me == type.BiogasPlant)
        {
            EventsAndStuff.TriggerBiogasPlantSpawnedEvent(gameObject);
        }
        else if (me == type.School)
        {
            EventsAndStuff.TriggerSchoolSpawnedEvent(gameObject);
        }
        else if (me == type.Farm)
        {
            EventsAndStuff.TriggerFarmSpawnedEvent(gameObject);
        }
        else if (me == type.Factory)
        {
            EventsAndStuff.TriggerFactorySpawnedEvent(gameObject);
        }
        else if (me == type.Windmill)
        {
            EventsAndStuff.TriggerWindmillSpawnedEvent(gameObject);
        }
     }
}
