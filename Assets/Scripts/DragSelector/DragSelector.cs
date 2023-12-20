using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragSelector : MonoBehaviour
{
    public int nog;
    public Material validMaterial;
    public Material invalidMaterial;
    private void OnTriggerEnter()
    {
        nog++;
        ChangeObjectMaterial(invalidMaterial);
    }
    private void OnTriggerExit()
    {
        nog--;
        if (nog == 0)
        {
            ChangeObjectMaterial(validMaterial);
        }
        Debug.Log("Lamo");
    }
    void ChangeObjectMaterial(Material material)
    {
        // Get the Renderer component attached to the GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Check if a Renderer component is found
        if (renderer != null)
        {
            // Assign the new material to the renderer
            renderer.material = material;
        }
        else
        {
            Debug.LogError("Renderer component not found on the GameObject.");
        }
    }
}
