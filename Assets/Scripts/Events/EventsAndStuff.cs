using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsAndStuff
{
    // Start is called before the first frame update
    public delegate void PauseEventHandler();
    public static event PauseEventHandler OnPauseEvent;
    public delegate void ResumeEventHandler();
    public static event ResumeEventHandler OnResumeEvent;
    public delegate void HutSpawnedEventHandler(GameObject hut);
    public static event HutSpawnedEventHandler OnHutSpawnedEvent;
    public delegate void HospitalSpawnedEventHandler(GameObject hospital);
    public static event HospitalSpawnedEventHandler OnHospitalSpawnedEvent;
    public delegate void BiogasPlantSpawnedEventHandler(GameObject bp);
    public static event BiogasPlantSpawnedEventHandler OnBiogasSpawnedEvent;
    public delegate void WindmillSpawnedEventHandler(GameObject bp);
    public static event WindmillSpawnedEventHandler OnWindmillSpawnedEvent;
    public delegate void FactorySpawnedEventHandler(GameObject bp);
    public static event FactorySpawnedEventHandler OnFactorySpawnedEvent;
    public delegate void SchoolSpawnedEventHandler(GameObject bp);
    public static event SchoolSpawnedEventHandler OnSchoolSpawnedEvent;
    public delegate void FarmSpawnedEventHandler(GameObject bp);
    public static event FarmSpawnedEventHandler OnFarmSpawnedEvent;
    public static void TriggerPauseEvent()
    {
        Debug.Log("Pause Event Triggered");
        OnPauseEvent?.Invoke();
    }
    public static void TriggerResumeEvent()
    {
        Debug.Log("Resume Event Triggered");
        OnResumeEvent?.Invoke();
    }
    public static void TriggerHutSpawnedEvent(GameObject hut)
    {
        Debug.Log("Hut Spawned Event Triggered");
        OnHutSpawnedEvent?.Invoke(hut);
    }
    public static void TriggerHospitalSpawnedEvent(GameObject hospital)
    {
        Debug.Log("Hospital Spawned Event Triggered");
        OnHospitalSpawnedEvent?.Invoke(hospital);
    }
    public static void TriggerBiogasPlantSpawnedEvent(GameObject bp)
    {
        Debug.Log("Biogas Plant Spawned Event Triggered");
        OnBiogasSpawnedEvent?.Invoke(bp);
    }
    public static void TriggerWindmillSpawnedEvent(GameObject hospital)
    {
        Debug.Log("Hospital Spawned Event Triggered");
        OnWindmillSpawnedEvent?.Invoke(hospital);
    }
    public static void TriggerFactorySpawnedEvent(GameObject bp)
    {
        Debug.Log("Factory Spawned Event Triggered");
        OnFactorySpawnedEvent?.Invoke(bp);
    }
    public static void TriggerSchoolSpawnedEvent(GameObject bp)
    {
        Debug.Log("Biogas Plant Spawned Event Triggered");
        OnSchoolSpawnedEvent?.Invoke(bp);
    }
    public static void TriggerFarmSpawnedEvent(GameObject bp)
    {
        Debug.Log("Biogas Plant Spawned Event Triggered");
        OnFarmSpawnedEvent?.Invoke(bp);
    }
}
