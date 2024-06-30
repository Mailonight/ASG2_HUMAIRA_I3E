/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * This coin is a collectible. It will destroy itself after being collided with the player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager object and get its GameManager component
        gameManager = FindObjectOfType<GameManager>();
    }
    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 5;


    /// <summary>
    /// Performs actions related to the collection of the collectible
    /// </summary>
    public void Collected()
    {
        // Destroy the collectible GameObject
        Destroy(gameObject);

        // Notify the GameManager that a collectible has been collected
        if (gameManager != null)
        {
            gameManager.CollectCollectible();
        }
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>

    //This happens when a product touches player:
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched me has a 'Player' tag
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().IncreaseOverallScore(myScore);
            Collected();
        }

    }
}

