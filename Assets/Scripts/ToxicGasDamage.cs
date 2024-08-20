using System.Collections; // Required for IEnumerator
using UnityEngine;

/// <summary>
/// Handles damage inflicted by toxic gas and manages the display of the death canvas.
/// </summary>
public class ToxicGasDamage : MonoBehaviour
{
    /// <summary>
    /// Amount of damage applied to the player per interval.
    /// </summary>
    public int damageAmount = 10;

    /// <summary>
    /// Time between consecutive damage applications, in seconds.
    /// </summary>
    public float damageInterval = 1f;

    /// <summary>
    /// Reference to the Death Canvas GameObject, which is displayed when the player dies.
    /// </summary>
    public GameObject deathCanvas;

    private float nextDamageTime; // Time when the next damage application is allowed

    /// <summary>
    /// Called every frame while a collider is within the trigger collider.
    /// Applies damage to the player if they are within the toxic gas and updates the damage timer.
    /// </summary>
    /// <param name="other">The collider that is currently within the trigger collider.</param>
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is tagged as "Player"
        {
            if (Time.time >= nextDamageTime) // Check if it's time to apply damage
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount); // Apply damage to the player
                    nextDamageTime = Time.time + damageInterval; // Update the next damage time

                    if (playerHealth.IsDead) // Check if the player is dead
                    {
                        StartCoroutine(ShowDeathCanvas()); // Show death canvas if player is dead
                    }
                }
            }
        }
    }

    /// <summary>
    /// Displays the death canvas for a short period and then hides it.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    private IEnumerator ShowDeathCanvas()
    {
        if (deathCanvas != null)
        {
            deathCanvas.SetActive(true); // Show the death canvas
            yield return new WaitForSeconds(10f); // Wait for 10 seconds
            deathCanvas.SetActive(false); // Hide the death canvas
        }
    }
}