/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * UPDATED DATE: 07 JUL 24
 * Description: 
 * This script is about MANAGING THE COUNT OF COLLECTIBLES.
 */

using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public TextMeshProUGUI itemsLeftTxt;
    private int totalCollectibles;
    private int collectedCollectibles = 0;

    private void Start()
    {
        // Find all game objects with the "Collectible" tag and count them
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        UpdateCollectiblesLeftUI();
    }

    public void CollectCollectible()
    {
        collectedCollectibles++;
        UpdateCollectiblesLeftUI();
    }

    private void UpdateCollectiblesLeftUI()
    {
        int remainingCollectibles = totalCollectibles - collectedCollectibles;
        itemsLeftTxt.text = "Items Left: " + remainingCollectibles.ToString();
    }
}
