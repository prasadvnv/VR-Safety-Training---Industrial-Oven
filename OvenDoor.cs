using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float interactionDistance = 2f;
    public LayerMask layers;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if (hit.collider.gameObject.GetComponent<door>())
            {
                // You can highlight the door or provide feedback when it's in focus
                Debug.Log("Door in focus. Press UI button to open.");
            }
            else
            {
                // Reset any feedback if not looking at the door
                Debug.Log("No door in focus.");
            }
        }
        else
        {
            // Reset any feedback if not looking at anything
            Debug.Log("Nothing in focus.");
        }
    }

    // Method to be called by the UI button click event
    public void OpenDoorWithUI()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            door door = hit.collider.gameObject.GetComponent<door>();
            if (door)
            {
                door.openClose();
                Debug.Log("Door opened/closed.");
            }
            else
            {
                Debug.LogWarning("No door found on click.");
            }
        }
    }
}
