using UnityEngine;
using UnityEngine.UI;

public class ExhaustFanController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust the speed as needed
    private bool isFanOn = false;

    void Start()
    {
        // Optional: You can also check if the fan GameObject is active in the hierarchy before starting it.
        // If the GameObject is inactive, you may want to activate it before setting isFanOn to true.
        // Example:
        // if (!gameObject.activeSelf) gameObject.SetActive(true);
    }

    void Update()
    {
        // Rotate the fan if it's on
        if (isFanOn)
        {
            RotateFan();
        }
    }

    void RotateFan()
    {
        // Rotate the fan around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void ToggleFanState()
    {
        // Called when the UI button is clicked
        isFanOn = !isFanOn;

        // If you want to perform additional actions when the fan state changes, you can do it here
        // For example, you can play a sound or show a message when the fan is turned on or off
        if (isFanOn)
        {
            Debug.Log("Fan is ON");
            // Add more actions as needed
        }
        else
        {
            Debug.Log("Fan is OFF");
            // Add more actions as needed
        }
    }
}
