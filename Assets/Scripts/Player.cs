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

    public TextMeshProUGUI overallScoreText;
    public TextMeshProUGUI uniqueScoreText;

    private int overallScore = 0;
    private int uniqueScore = 0;

    private Door currentDoor;

    private void Start()
    {
        collectibleManager = FindObjectOfType<CollectibleManager>();
    }

    public void IncreaseOverallScore(int scoreToAdd)
    {
        overallScore += scoreToAdd;
        overallScoreText.text = "Overall Score: " + overallScore.ToString();
        Debug.Log("Overall Score updated to: " + overallScore);
    }

    public void IncreaseUniqueScore(int scoreToAdd)
    {
        uniqueScore += scoreToAdd;
        uniqueScoreText.text = "Unique Items Score: " + uniqueScore.ToString();
        IncreaseOverallScore(scoreToAdd); // Also increase overall score when unique score is increased
    }

    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentDoor != null)
        {
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
