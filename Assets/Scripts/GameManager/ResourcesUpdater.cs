using UnityEngine;
using System.Collections;

public class YourScript : MonoBehaviour
{
    [SerializeField] Money money;
    Coroutine c;
    // [SerializeField] PauseGame pg;
    void Start()
    {
        // Start the coroutine that calls YourFunction() every 1 second.
        c = StartCoroutine(CallFunctionEverySecond());
        EventsAndStuff.OnPauseEvent += PauseEventHandler;
        EventsAndStuff.OnResumeEvent += ResumeEventHandler;
    }

    IEnumerator CallFunctionEverySecond()
    {
        while (true)
        {
            // Your code to be executed every second.
            UpdateResources();

            // Wait for 1 second before the next iteration.
            yield return new WaitForSeconds(1f);
        }
    }

    void UpdateResources()
    {
        // bool isPause=PauseGame.Instance.isPause;
        // Debug.Log(pg.isPause);
        // if(!pg.isPause){
        money.money += money.incRate;
        // }
    }
    void PauseEventHandler()
    {
        if (c != null)
        {
            StopCoroutine(c);
            c = null;
        }
    }

    void ResumeEventHandler()
    {
        if (c == null)
        {
            c = StartCoroutine(CallFunctionEverySecond());
        }
    }
}
