/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * This coin is a collectible. It will destroy itself after being collided with the player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages collectible coins in the game. 
/// When a coin is collected by the player, it increases the player's score and is destroyed.
/// </summary>
public class Coins : MonoBehaviour
{
    /// <summary>
    /// Reference to the GameManager instance.
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// The score value associated with this coin.
    /// </summary>
    public int myScore = 5;

    /// <summary>
    /// Initializes the game manager reference at the start of the game.
    /// </summary>
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// Handles the actions when the coin is collected by the player.
    /// Destroys the coin and updates the game manager with the collectible event.
    /// </summary>
    public void Collected()
    {
        Destroy(gameObject); // Destroy the coin object
        if (gameManager != null)
        {
            gameManager.CollectCollectible(); // Notify the game manager about the collectible
        }
    }

    /// <summary>
    /// Detects when another collider enters the trigger collider attached to the coin.
    /// If the collider belongs to the player, it increases the player's score, 
    /// notifies the CollectibleManager, and calls the Collected method to handle the destruction of the coin.
    /// </summary>
    /// <param name="other">The collider that entered the trigger collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().IncreaseOverallScore(myScore); // Increase the player's score
            FindObjectOfType<CollectibleManager>().CollectCollectible(); // Notify the CollectibleManager about the collectible
            Collected(); // Call Collected to handle the destruction of the coin
        }
    }
}

