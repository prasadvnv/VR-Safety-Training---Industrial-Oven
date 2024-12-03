//oven door
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OvenDoorController : MonoBehaviour
{
    public Animator doorAnimator; // Make this variable public

    private bool isDoorOpen = false;
    private XRBaseInteractable xrInteractable;

    void Start()
    {
        // Add XR Simple Interactable component to the GameObject if not already added.
        xrInteractable = GetComponent<XRBaseInteractable>();
        
        // Subscribe to the selectEntered event.
        xrInteractable.onSelectEntered.AddListener(OnSelectEntered);
    }

    private void OnDestroy()
    {
        // Ensure to unsubscribe from the event to prevent memory leaks.
        xrInteractable.onSelectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        // Check if doorAnimator is not null before accessing it.
        if (doorAnimator != null)
        {
            // Toggle the state of the door and trigger the corresponding animation.
            isDoorOpen = !isDoorOpen;
            doorAnimator.SetBool("Open", isDoorOpen);
        }
        else
        {
            Debug.LogError("Animator is not assigned to the OvenDoorController script. Please assign it in the Inspector.");
        }
    }
}
