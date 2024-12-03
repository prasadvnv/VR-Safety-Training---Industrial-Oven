using UnityEngine;
using UnityEngine.UI;

public class LightOnOff : MonoBehaviour
{
    public GameObject txtToDisplay;             // Display the UI text
    public GameObject lightorobj;
    public GameObject lightorobj2;
    public GameObject lightorobj3;

    private bool playerInZone;                  // Check if the player is in trigger

    private void Start()
    {
        playerInZone = false;                   // Player not in zone       
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        // No need for the Update method in this case
    }

    public void ToggleLights()
    {
        // Toggle the lights when the UI button is pressed
        lightorobj.SetActive(!lightorobj.activeSelf);
        lightorobj2.SetActive(!lightorobj2.activeSelf);
        lightorobj3.SetActive(!lightorobj3.activeSelf);
        //gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().Play("switch");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))     // If player in zone
        {
            txtToDisplay.SetActive(true);
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)     // If player exit zone
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
}
