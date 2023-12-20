using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUpdater : MonoBehaviour
{
    [SerializeField] GameStates gs;
    // Update is called once per frame
    void LateUpdate()
    {
        gs.currentState = gs.nextState;
        gs.wasButtonClicked = false;
    }
}
