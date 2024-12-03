using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OvenController : MonoBehaviour
{
    public Slider timeSlider;
    public TMP_Dropdown ovenControlDropdown;
    public TextMeshProUGUI emergencyStopText;
    public TextMeshProUGUI chosenTimeText;
    public OvenableObject ovenableObject; // Reference to the object script
    public Light ovenLight; // Reference to the light component
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI statusText;
    public AudioSource alarmAudioSource; // Reference to the AudioSource component
    public AudioSource ovenStartAudioSource; // Reference to the audio source for oven start
    public GameObject lightorobj;
    public GameObject emergencyPanel; // Reference to the emergency panel

    private bool isOvenOn = false;
    public bool isEmergencyStop = false;
    private float currentTime = 0f;
    private float targetTime = 0f;
    private float temperature = 25f;

    private void Update()
    {
        if (isOvenOn)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                TurnOffOven();
            }
            else
            {
                IncreaseTemperature();

                // Log the live temperature to the console only when the oven is on
                Debug.Log($"Live Temperature: {temperature}°C");

                // Check for emergency stop condition
                if (temperature > 1200f)
                {
                    if (!isEmergencyStop)
                    {
                        EmergencyStop();
                    }
                }
            }
        }

        // Update the UI status text
        if (statusText != null)
        {
            statusText.text = isOvenOn ? "ON" : "OFF";
        }

        // Update the UI temperature text
        if (temperatureText != null)
        {
            temperatureText.text = $"Temperature: {temperature}°C";
        }

        // Update the chosen time text on the canvas
        if (chosenTimeText != null)
        {
            chosenTimeText.text = $"{timeSlider.value}";
        }
    }

    public void OvenControlDropdownChanged()
    {
        string selectedOption = ovenControlDropdown.options[ovenControlDropdown.value].text;

        switch (selectedOption)
        {
            case "Start Oven":
                StartOven();
                break;
            case "Stop Oven":
                StopOven();
                break;
            default:
                Debug.LogError("Invalid option selected in the dropdown.");
                break;
        }
    }

    public void PressEmergencySwitch()
    {
        if (isOvenOn)
        {
            // If the oven is on, perform emergency stop
            EmergencyStop();
        }
        else
        {
            // If the oven is off, you can implement other actions or leave it empty
            Debug.Log("Emergency switch pressed, but the oven is already off.");
        }
    }

    private void StartOven()
    {
        if (!isOvenOn)
        {
            // Ensure the target time is between 0 and 15 seconds
            targetTime = Mathf.Clamp(timeSlider.value, 0f, 15f);
            currentTime = targetTime;
            isOvenOn = true;

            // Play the oven start audio
            if (ovenStartAudioSource != null)
            {
                ovenStartAudioSource.Play();
            }

            // Clear the emergency stop message and hide the text when starting the oven
            if (emergencyStopText != null)
            {
                emergencyStopText.text = "";
                emergencyStopText.gameObject.SetActive(false);
            }

            // Hide the chosen time text when starting the oven
            if (chosenTimeText != null)
            {
                chosenTimeText.text = "";
                chosenTimeText.gameObject.SetActive(false);
            }

            // Turn on the oven light and set it to yellow when starting the oven
            ToggleOvenLight(true, Color.yellow);

            // Notify the object script that it is entering the oven
            if (ovenableObject != null)
            {
                ovenableObject.EnterOven();
            }
        }
    }

    private void StopOven()
    {
        if (isOvenOn)
        {
            TurnOffOven();
        }
    }

    private void TurnOffOven()
    {
        isOvenOn = false;
        currentTime = 0f;
        temperature = 25f; // Set the initial temperature to 25 degrees Celsius

        // Stop the oven start audio
        if (ovenStartAudioSource != null)
        {
            ovenStartAudioSource.Stop();
        }

        // Clear the emergency stop message and hide the text when stopping the oven
        if (emergencyStopText != null)
        {
            emergencyStopText.text = "";
            emergencyStopText.gameObject.SetActive(false);
        }

        // Show the chosen time text when stopping the oven
        if (chosenTimeText != null)
        {
            chosenTimeText.gameObject.SetActive(true);
        }

        // Turn off the oven light and set it to green when stopping the oven
        ToggleOvenLight(false, Color.green);

        // Notify the object script that the oven is switched off
        if (ovenableObject != null)
        {
            ovenableObject.OvenSwitchedOff();
        }

        // Reset the emergency stop flag when stopping the oven
        isEmergencyStop = false;
    }

    private void IncreaseTemperature()
    {
        temperature += 100f * Time.deltaTime;
    }

    private void EmergencyStop()
    {
        Debug.LogWarning("Emergency stop! Temperature exceeded 1200°C.");
        TurnOffOven();
        isEmergencyStop = true;

        // Display the emergency stop message on the canvas
        if (emergencyStopText != null)
        {
            emergencyStopText.text = "Emergency Stop! Safety Limit Reached";
            emergencyStopText.gameObject.SetActive(true);
        }

        // Play the alarm sound and toggle the light
        if (alarmAudioSource != null)
        {
            alarmAudioSource.Play();
            lightorobj.SetActive(!lightorobj.activeSelf);
        }

        // Activate the emergency panel
        if (emergencyPanel != null)
        {
            emergencyPanel.SetActive(true);
        }
    }

    private void ToggleOvenLight(bool isOn, Color color)
    {
        if (ovenLight != null)
        {
            ovenLight.enabled = isOn;
            ovenLight.color = color;
        }
    }
}
