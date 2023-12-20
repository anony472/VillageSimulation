using UnityEngine;

[CreateAssetMenu(fileName = "GameStates", menuName = "Custom/GameStates")]
public class GameStates : ScriptableObject
{
    private GameState defaultState = GameState.Normal;
    public GameState currentState;
    public GameState nextState;
    public GameState stateBeforePause;
    public bool wasButtonClicked;


    public enum GameState
    {
        Normal,
        BuildingMode,
        DraggingMode,
        PausedMode
        // Add more values as needed
    }
    public void OnEnable()
    {
        currentState = defaultState;
        nextState = defaultState;
        wasButtonClicked = false;
        EventsAndStuff.OnPauseEvent += PauseEventHandler;
        EventsAndStuff.OnResumeEvent += ResumeEventHandler;
    }
    public void PauseEventHandler()
    {
        Debug.Log("Game paused");
        stateBeforePause = currentState;
        nextState = GameState.PausedMode;
    }
    public void ResumeEventHandler()
    {
        nextState = stateBeforePause;
    }
}
