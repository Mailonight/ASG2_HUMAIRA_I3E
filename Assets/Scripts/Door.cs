/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * Door that opens when player is close to it & presses the interact button.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Flags if te door is open
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Flags if the door is locked
    /// </summary>
    bool locked = false;

    // Reference to the TextMeshProUGUI object for interaction prompt
    public TMPro.TextMeshProUGUI interactionPromptText;

    // Reference to the Player script
    Player playerScript;

    void Start()
    {
        // Find the Player script in the scene and store a reference to it
        playerScript = FindObjectOfType<Player>();
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player") && !opened)
        {
            // Calculate the distance between the player and the door
            float distance = Vector3.Distance(transform.position, other.transform.position);

            // Adjust this distance threshold as needed
            float interactionDistance = 2.0f;

            // Show interaction prompt text only if player is close enough and the door is not locked
            if (distance <= interactionDistance && !locked)
            {
                interactionPromptText.gameObject.SetActive(true);
                // Update the player script with a reference to this door
                playerScript.UpdateDoor(this);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Hide interaction prompt text
            interactionPromptText.gameObject.SetActive(false);
            // Update the player script with null reference to door
            playerScript.UpdateDoor(null);
        }
    }
    //XML COMMENTS!!
    /// <summary>
    /// Handles the door opening
    /// </summary>

    public void OpenDoor()
    {
        if (locked)
        {
            //TAKE NOTE:
            //CANNOT DIRECTLY MODIFY THE TRANSFORM ROTATION
            //transform.eulerAngles.y += 90f;

            //Create a new Vector3 and store the current rotation.
            //Vector3 newRotation = transform.eulerAngles;

            //Add 90 degrees to the y axis rotation
            //newRotation.y += 90f;

            //Assign 
            //transform.eulerAngles = newRotation;
            transform.Rotate(Vector3.up, 90f);
            opened = true;

            //Hide the interaction prompt text after the door is opened
            interactionPromptText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Sets the lock status of the door
    /// </summary>
    /// <param name ="lockStatus">The lock status of the door</param>
    public void SetLock(bool lockStatus)
    {
        //Assign the lockStatus value to the locked bool
        locked = lockStatus;
    }
}




  
