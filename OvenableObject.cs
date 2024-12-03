using UnityEngine;

public class OvenableObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private bool isInsideOven = false;

    private void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();
    }

    // Call this method when the object is put into the oven
    public void EnterOven()
    {
        // Mark the object as inside the oven
        isInsideOven = true;
        // Optionally, you can perform any setup for the object entering the oven
    }

    // Call this method when the oven is switched off
    public void OvenSwitchedOff()
    {
        if (isInsideOven)
        {
            // Change the color of the object to cream when the oven is switched off
            Color creamColor = new Color(1f, 0.96f, 0.87f); // RGB values for cream
            objectRenderer.material.color = creamColor;
            
            // Mark the object as no longer inside the oven
            isInsideOven = false;
        }
    }
}

