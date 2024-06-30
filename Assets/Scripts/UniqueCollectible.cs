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
        // Destroy the attached GameObject
        Destroy(gameObject);

        // Increase both unique score and overall score
        var player = FindObjectOfType<Player>();
        if (player != null)
        {
            //calls the increaseuniquescore method of the player script
            //passes the myScore value of the unique collectible as a parameter.
            player.IncreaseUniqueScore(myScore);
        }
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>

    //This happens when a product touches player:
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object that touched me has a 'Player' tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Collected();
        }

    }
}


