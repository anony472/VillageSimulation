using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyIndex : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Money mo;
    public Text value;
    void Start()
    {
        value.text=(mo.money).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        value.text=(mo.money).ToString();
    }
}
