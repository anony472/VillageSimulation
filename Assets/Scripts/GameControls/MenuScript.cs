using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMenuOpen=false;
    public GameObject menuObject;
    // public InputField initialValue;
    // [SerializeField] RequirementsToBuild rb;
    void Start()
    {
        menuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpenMenu(){
        // SceneManager.LoadScene(3);
        if(!isMenuOpen){
            isMenuOpen=true;
            menuObject.SetActive(true);
        }
        else{
            isMenuOpen=false;
            menuObject.SetActive(false);
        }
        
    }
    // public void onCloseMenu(){
    //     SceneManager.LoadScene(2);
    // }

    

    


}