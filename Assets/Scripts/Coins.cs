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
    public int myScore = 5;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Collected()
    {
        Destroy(gameObject);
        if (gameManager != null)
        {
            gameManager.CollectCollectible(); // Tell GameManager a collectible was collected
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().IncreaseOverallScore(myScore); // Increase player score
            FindObjectOfType<CollectibleManager>().CollectCollectible(); // Notify CollectibleManager
            Collected(); // Destroy the coin object
        }
    }
}

