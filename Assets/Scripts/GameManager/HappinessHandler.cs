using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> allPlacedBuildings = new List<GameObject>();
    [SerializeField] List<GameObject> allPlacedHuts = new List<GameObject>();
    [SerializeField] List<GameObject> allPlacedHospitals = new List<GameObject>();
    [SerializeField] List<GameObject> allPlacedBiogasPlants = new List<GameObject>();
    [SerializeField] List<HutData> hutDatas = new List<HutData>();
    [SerializeField] HappinessData hd;
    void Awake()
    {
        EventsAndStuff.OnHutSpawnedEvent += HutSpawnedEventHandler;
        EventsAndStuff.OnHospitalSpawnedEvent += HospitalSpawnedEventHandler;
        EventsAndStuff.OnBiogasSpawnedEvent += BiogasSpawnedEventHandler;
    }
    void HutSpawnedEventHandler(GameObject hut)
    {
        // Debug.Log("Hi hut from hh");
        allPlacedHuts.Add(hut);
        allPlacedBuildings.Add(hut);
        hutDatas.Add(hut.GetComponent<HutData>());
    }
    void HospitalSpawnedEventHandler(GameObject hospital)
    {
        // Debug.Log("Hi hosp from hh");
        allPlacedHospitals.Add(hospital);
        allPlacedBuildings.Add(hospital);
        if (allPlacedHuts.Count != 0)
        {
            for (int i = 0; i < allPlacedHuts.Count; i++)
            {
                double dist = Vector3.Distance(hospital.transform.position, allPlacedHuts[i].transform.position);
                if (hutDatas[i].nearestHospitalDistance == -1 || hutDatas[i].nearestHospitalDistance > dist)
                {
                    hutDatas[i].nearestHospitalDistance = dist;
                }
            }
            hd.currentHappiness = CalculateHappiness();
        }
    }
    void BiogasSpawnedEventHandler(GameObject bp)
    {
        // Debug.Log("Hi bp from hh");
        allPlacedBiogasPlants.Add(bp);
        allPlacedBuildings.Add(bp);
        if (allPlacedHuts.Count != 0)
        {
            for (int i = 0; i < allPlacedHuts.Count; i++)
            {
                double dist = Vector3.Distance(bp.transform.position, allPlacedHuts[i].transform.position);
                if (hutDatas[i].nearestBiogasPlantDistance == -1 || hutDatas[i].nearestBiogasPlantDistance > dist)
                {
                    hutDatas[i].nearestBiogasPlantDistance = dist;
                }
            }
            hd.currentHappiness = CalculateHappiness();
        }
    }
    double CalculateHappiness()
    {
        double happiness = 0;
        foreach(HutData hutData in hutDatas)
        {
            happiness += HospitalHappinessFunction(hutData.nearestHospitalDistance);
            happiness += BiogasPlantHappinessFunction(hutData.nearestBiogasPlantDistance);
        }
        happiness /= hutDatas.Count;
        return happiness;
    }
    double HospitalHappinessFunction(double dist)
    {
        return 100/dist + 0.0125;
    }
    double BiogasPlantHappinessFunction(double dist)
    {
        Debug.Log(dist);
        Debug.Log(1 - 100/dist);
        return 1 - 100/dist;
    }
}
