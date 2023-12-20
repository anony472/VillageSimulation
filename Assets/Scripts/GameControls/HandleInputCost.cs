using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleInputCost : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField field1;
    public InputField field2;

    [SerializeField] Money rb;
    public void Start()
    {
        // rb.startingMoney= field1.text;
        // rb.incRate= field2.text;
        // field1.text = (rb.startingMoney).ToString();
        // field2.text = (rb.incRate).ToString();
    }

    
    public void onSubmit(){
        rb.startingMoney = long.Parse(field1.text);
        rb.incRate = long.Parse(field2.text);
        SceneManager.LoadScene(2);
    }



    // Update is called once per frame
    void Update()
    {

    }

}
