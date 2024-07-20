/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * This unique item is in green and it is a collectible. It will destroy itself after being collided with the player.
 * Contains functions on how it would increase the score at the right text field.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueCollectible : MonoBehaviour
{
    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 10;


    /// <summary>
    /// Performs actions related to the collection of the collectible
    /// </summary>
    public void Collected()
    {
        Destroy(gameObject);

        var player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.IncreaseUniqueScore(myScore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected();
        }
    }
}


