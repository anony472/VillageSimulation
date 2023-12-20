using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HappinessScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HappinessData hd;
    public Text value;
    void Start()
    {
        value.text=RoundUpToDecimalPlaces(hd.currentHappiness, 4).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        value.text=RoundUpToDecimalPlaces(hd.currentHappiness, 4).ToString();
    }
    double RoundUpToDecimalPlaces(double number, int decimalPlaces)
    {
        double multiplier = Math.Pow(10, decimalPlaces);
        return Math.Ceiling(number * multiplier) / multiplier;
    }
}
