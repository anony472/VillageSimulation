using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleInput : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField legacyInputField;
    [SerializeField] RequirementsToBuild rb;
    public void Start()
    {
        legacyInputField.text=(rb.cost).ToString();
    }

    public void onEndEdit(string userInput)
    {
        // This method will be called when the user finishes typing
        Debug.Log("Typed input: " + userInput);
        if(long.TryParse(userInput, out long result))
        {
        rb.cost=result;
        Debug.Log(rb.cost);
        }
        else{
            Debug.LogError("Failed to parse the string as a long.");
        }

        // You can store the input value in a variable, use it in your game logic, or save it to a file/database.
        // For example, you can store it in a public variable for easy access from other scripts:
        // StoredInputValue = userInput;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

}
