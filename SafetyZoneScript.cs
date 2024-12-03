// SafetyZoneScript.cs
using UnityEngine;


    public class SafetyZoneScript : MonoBehaviour
    {
        public AudioSource safetyAudioSource;
        public AudioClip emergencyStopAudio;

        // Other members and methods of your script...

        // Custom method for handling emergency stop in the safety zone
        public void HandleEmergencyStop()
        {
            Debug.Log("Emergency Stop in Safety Zone! Playing audio...");

            // Check if AudioSource and AudioClip are set
            if (safetyAudioSource != null && emergencyStopAudio != null)
            {
                // Play the emergency stop audio
                safetyAudioSource.PlayOneShot(emergencyStopAudio);
            }
        }
    }

