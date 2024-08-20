using UnityEngine;
using System.Collections; // Required for IEnumerator

/// <summary>
/// Controls the opening and closing of a door by rotating it around its vertical axis.
/// </summary>
public class DoorController : MonoBehaviour
{
    /// <summary>
    /// The angle to which the door will rotate when it opens.
    /// </summary>
    public float openAngle = 90.0f;

    /// <summary>
    /// The speed at which the door will open and close.
    /// </summary>
    public float openSpeed = 2.0f;

    private bool isOpen = false; // Indicates whether the door is currently open
    private bool isMoving = false; // Indicates whether the door is currently moving

    /// <summary>
    /// Updates once per frame. Checks for user input to toggle door state.
    /// </summary>
    void Update()
    {
        if (isMoving)
            return; // Exit if the door is already moving

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the door state based on its current state
            if (isOpen)
            {
                // Close the door
                StartCoroutine(OpenDoor(transform.rotation, Quaternion.Euler(0, 0, 0)));
            }
            else
            {
                // Open the door
                StartCoroutine(OpenDoor(transform.rotation, Quaternion.Euler(0, openAngle, 0)));
            }
        }
    }

    /// <summary>
    /// Smoothly animates the door from its current rotation to the target rotation.
    /// </summary>
    /// <param name="startRotation">The initial rotation of the door.</param>
    /// <param name="endRotation">The target rotation of the door.</param>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    IEnumerator OpenDoor(Quaternion startRotation, Quaternion endRotation)
    {
        isMoving = true; // Set the door to be moving
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * openSpeed; // Increment the time factor based on the speed
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t); // Smoothly interpolate between rotations
            yield return null; // Wait for the next frame
        }
        isOpen = !isOpen; // Toggle the door state
        isMoving = false; // Reset moving flag
    }
}