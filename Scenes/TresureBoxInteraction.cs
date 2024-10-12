using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxInteraction : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject chest_close;

    public GameObject chest_open;

    private bool isPlayerNear = false; // Check if player is close to the treasure box
    private bool isBoxOpened = false;

    void Start()
    {
        chest_close.gameObject.SetActive(true);
        chest_open.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is near the treasure box and left mouse button is clicked
        if (isPlayerNear) // 0 for left mouse button  && Input.GetMouseButtonDown(0)
        {
            OpenTreasureBox(); // Call the function to open the treasure box
        }
    }

    // Method to open the treasure box (this can be customized)
    void OpenTreasureBox()
    {
        if (isBoxOpened){
            return;
        }

        chest_close.gameObject.SetActive(false);
        chest_open.gameObject.SetActive(true);

        dialogue.ShowDialogue();
        isBoxOpened = true;
        Debug.Log("Treasure Box opened!"); // This is just a placeholder, replace with your own logic
        // You could play an animation, give a reward, etc.
    }

    // Detect when the player enters the treasure box's trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the object interacting is the player
        {
            isPlayerNear = true;
            Debug.Log("Player is near the treasure box.");
        }
    }

    // Detect when the player leaves the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left the treasure box area.");
        }
    }
}
