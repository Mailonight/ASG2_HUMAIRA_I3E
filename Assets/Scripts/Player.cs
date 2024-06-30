/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * Player's abilities and functions like increasing score, door, etc.
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CollectibleManager collectibleManager;

    private void Start()
    {
        // Find the CollectibleManager in the scene
        collectibleManager = FindObjectOfType<CollectibleManager>();
    }

    // Called when the player interacts with a collectible
    public void CollectCollectible()
    {
        // Call the CollectCollectible method in CollectibleManager
        if (collectibleManager != null)
        {
            collectibleManager.CollectCollectible();
            Debug.Log("Collectible collected.");
        }
    }

    public TextMeshProUGUI overallScoreText;
    public TextMeshProUGUI uniqueScoreText;

    private Door currentDoor; // Declaration for currentDoor variable
    private Coins currentCoins; // Declaration for currentCoins variable

    private int overallScore = 0;
    private int uniqueScore = 0;

    /// <summary>
    /// The current score of the player
    /// </summary>
    /// 


    /// <summary>
    /// Increases the score of the player by <paramref
    /// </summary>
    /// <param name="scoreToAdd">The amount to increase</param>
 
    public void IncreaseOverallScore(int scoreToAdd)
    {
        //increase overall score 
        overallScore += scoreToAdd;
        //update ui to display updated score
        overallScoreText.text = "Overall Score: " + overallScore.ToString();
    }
    public void IncreaseUniqueScore(int scoreToAdd)
    {
        //increase unique score
        uniqueScore += scoreToAdd;
        //update ui to display updated score in the right column
        uniqueScoreText.text = "Unique Items Score: " + uniqueScore.ToString();
        IncreaseOverallScore(scoreToAdd); // Also increase overall score when unique score is increased
    }
    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }

    void Update()
    {
        // Check for player interaction
        if (Input.GetKeyDown(KeyCode.E) && currentDoor != null)
        {
            // Call the OpenDoor method of the current door
            currentDoor.OpenDoor();
        }
    }
    void OnInteract()
    {
        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
            currentDoor = null;
        }
    }


}
