using System.Collections.Generic;
using UnityEngine;
// using System;

public class PolygonInstantiator : MonoBehaviour
{
    public GameObject cubePrefab; 
    

    void Start()
    {
        float startTime = Time.realtimeSinceStartup;
        TheJSONReader jr = gameObject.GetComponent<TheJSONReader>();
        Debug.Log(jr.cords.Count);
        for (int i = 0; i < jr.cords.Count; i++)
        {
            GameObject cubeInstance = Instantiate(cubePrefab, transform.position, Quaternion.identity);

            cubeInstance.transform.position = new Vector3((float)jr.cords[i].x, 0.05f, (float)jr.cords[i].z);
            cubeInstance.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            Destroy(cubeInstance.GetComponent<BuildingManager>());
            EventsAndStuff.TriggerHutSpawnedEvent(cubeInstance);
            // Debug.Log(jr.cords[i].x + " " + jr.cords[i].z);
        }
        float elapsedTime = Time.realtimeSinceStartup - startTime;
        Debug.Log("Start method took: " + elapsedTime + " seconds");
    }
}



