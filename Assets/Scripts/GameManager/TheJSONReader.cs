using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using Unity.VisualScripting;

public class Vector2d
{
    public double x;
    public double z;

    public Vector2d(double x, double z)
    {
        this.x = x;
        this.z = z;
    }
}

public class TheJSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public List<Vector2d> cords = new List<Vector2d>();
    void Awake()
    {
        JSONNode jsonData = JSON.Parse(jsonFile.text);
        double global_avg_x = 0, global_avg_z = 0; //sd = StandardDeviation
        int globalCountVertices = 0;
        List<Vector2d> tempCords = new List<Vector2d>();
        foreach (JSONNode feature in jsonData["features"])
        {
            double local_avg_x = 0, local_avg_z = 0;
            int localCountVertices = 0;
            foreach (JSONNode cord in feature["coordinates"])
            {
                global_avg_x += cord[0];
                global_avg_z += cord[1];
                local_avg_x += cord[0];
                local_avg_z += cord[1];
                globalCountVertices++;
                localCountVertices++;
            }
            local_avg_x /= localCountVertices;
            local_avg_z /= localCountVertices;
            tempCords.Add(new Vector2d(local_avg_x, local_avg_z));
        }
        global_avg_x /= globalCountVertices;
        global_avg_z /= globalCountVertices;

        foreach (Vector2d cord in tempCords)
        {
            cords.Add(new Vector2d(cord.x - global_avg_x, cord.z - global_avg_z));
        }

    }
}
