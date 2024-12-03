using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public ParticleSystem smokeParticleSystem;

    void Start()
    {
        // Ensure particle system is stopped initially
        smokeParticleSystem.Stop();
    }

    void Update()
    {
        // Example: Trigger particle system on key press (F key)
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivateFireExtinguisher();
        }
    }

    void ActivateFireExtinguisher()
    {
        // Play the particle system
        smokeParticleSystem.Play();
    }
}
