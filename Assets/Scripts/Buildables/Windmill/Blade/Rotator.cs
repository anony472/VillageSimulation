using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the speed as needed
    Coroutine c;
    void Start()
    {
        c = StartCoroutine(Rotate());
        EventsAndStuff.OnPauseEvent += PauseEventHandler;
        EventsAndStuff.OnResumeEvent += ResumeEventHandler;
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            // Rotate the GameObject around its z axis at a constant speed
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            yield return null;
        }
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
            c = StartCoroutine(Rotate());
        }
    }
}
