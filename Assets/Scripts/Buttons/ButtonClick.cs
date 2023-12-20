using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] GameObject windmill;
    [SerializeField] GameObject hospital;
    [SerializeField] GameObject hut;
    [SerializeField] GameObject school;
    [SerializeField] GameObject farm;
    [SerializeField] GameObject factory;
    [SerializeField] GameObject biogasPlant;


    [SerializeField] GameStates gs;
    public void SpawnWindmill()
    {
        Debug.Log("Windmill spawned frsegtthsr");
        windmill.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
    public void SpawnHospital()
    {
        Debug.Log("Hospital spawned wjdanefja");
        hospital.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
    public void SpawnHut()
    {
        Debug.Log("Hospital spawned wjdanefja");
        hut.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
    public void SpawnSchool()
    {
        Debug.Log("Hospital spawned wjdanefja");
        school.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
    public void SpawnFarm()
    {
        Debug.Log("Hospital spawned wjdanefja");
        farm.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
    public void SpawnFactory()
    {
        Debug.Log("Hospital spawned wjdanefja");
        factory.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
    public void SpawnBiogasPlant()
    {
        Debug.Log("Hospital spawned wjdanefja");
        biogasPlant.GetComponent<BuildingManager>().otherBuildingMethods = true;
        gs.wasButtonClicked = true;
    }
}
