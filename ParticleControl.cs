using UnityEngine;
using UnityEngine.UI;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem smokeParticleSystem;
    public Button toggleButton;
    public AudioSource audioSource;
    public AudioClip switchOnSound;

    private bool isParticleSystemActive = false;

    void Start()
    {
        // Ensure particle system is stopped initially
        StopParticleSystem();

        // Attach the button click event
        toggleButton.onClick.AddListener(ToggleParticleSystem);
    }

    void ToggleParticleSystem()
    {
        // Toggle the state of the particle system
        isParticleSystemActive = !isParticleSystemActive;

        // Start or stop the particle system based on the state
        if (isParticleSystemActive)
        {
            StartParticleSystem();
            PlaySwitchOnSound();
        }
        else
        {
            StopParticleSystem();
        }
    }

    void StartParticleSystem()
    {
        // Play the particle system
        smokeParticleSystem.Play();
    }

    void StopParticleSystem()
    {
        // Stop the particle system
        smokeParticleSystem.Stop();
    }

    void PlaySwitchOnSound()
    {
        // Play the switch on sound
        if (audioSource != null && switchOnSound != null)
        {
            audioSource.PlayOneShot(switchOnSound);
        }
    }

    void OnDestroy()
    {
        // Remove the button click event listener to prevent memory leaks
        toggleButton.onClick.RemoveListener(ToggleParticleSystem);
    }
}
