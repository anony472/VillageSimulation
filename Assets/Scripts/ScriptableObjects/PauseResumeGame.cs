using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is basically for clicking pause button in game; 
//on clicking pause button in game onClickPause function will be called
//to pause anything if i left 
//add[SerializeField] PauseGame pg;
//add if(!pg.isPause) condition;
[CreateAssetMenu(fileName = "PauseResume", menuName = "Custom/PauseResume")]
public class PauseResumeGame : ScriptableObject
{
    // Start is called before the first frame update
    // public static PauseGame Instance { get; set; }
    public bool isPause=false;
    void OnEnable()
    {
        isPause=false;
    }

    public void PauseGame(){
        isPause=true;
    }

    public void ResumeGame(){
        isPause=false;
    }
}
