using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is basically for clicking pause button in game; 
//on clicking pause button in game onClickPause function will be called
//to pause anything if i left 
//add[SerializeField] PauseGame pg;
//add if(!pg.isPause) condition;
public class PauseGame : ScriptableObject
{
    // Start is called before the first frame update
    // public static PauseGame Instance { get; set; }
    public bool isPause=false;
    [SerializeField] Button pauseButton;
    [SerializeField] GameStates gs;
    // public Button pauseButton;
    void Start()
    {
        isPause=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPause(){
        if(!isPause){
        isPause=true;
        pauseButton.GetComponent<Text>().text="Resume";
        }
        else{
        isPause=false;
        pauseButton.GetComponent<Text>().text="Pause";
        }

    }

    // public void onClickResume(){
    //     isPause=false;
    // }

}
