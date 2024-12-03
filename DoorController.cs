using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private Quaternion startRotation;
    private bool isOpen = false;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        startRotation = transform.rotation;

        // Subscribe to events
        interactable.onSelectEntered.AddListener(ToggleDoor);
    }

    void ToggleDoor(XRBaseInteractor interactor)
    {
        if (!isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        transform.rotation = startRotation * Quaternion.Euler(0, 90f, 0);
        isOpen = true;
    }

    void CloseDoor()
    {
        transform.rotation = startRotation;
        isOpen = false;
    }
}