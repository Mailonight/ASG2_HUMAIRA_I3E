/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * This script is about UI displaying the items left for player to collect.
 */

using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public TextMeshProUGUI ItemsLeftTxt; // Changed variable name to match "ItemsLeftTxt"
    private int totalCollectibles; // Total number of collectibles needed to be collected

    private int collectedCollectibles = 0;

    private void Start()
    {
        // Calculate the total number of collectibles in your scene dynamically
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        UpdateCollectiblesLeftUI();
    }

    public void CollectCollectible()
    {
        collectedCollectibles++;
        UpdateCollectiblesLeftUI();
        Debug.Log("Collectible collected. Total collected: " + collectedCollectibles);
    }

    private void UpdateCollectiblesLeftUI()
    {
        // Calculate the number of remaining collectibles
        int remainingCollectibles = totalCollectibles - collectedCollectibles;

        // Update the UI text to display the number of remaining collectibles
        ItemsLeftTxt.text = "Items Left: " + remainingCollectibles.ToString(); // Updated text to "Items Left"
    }
}
