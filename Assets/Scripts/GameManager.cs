/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * To control the UI for Congratulations text.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI congratsText;
    public GameObject congratsPanel; // Reference to the parent GameObject containing the image and the congratulatory text
    public GameObject instructionsPanel; // Reference to the parent GameObject containing the instructions UI
    public float displayTime = 5f; // Display time for instructions UI
    private int totalCoins = 0;
    private bool congratsDisplayed = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        congratsPanel.SetActive(false); // Deactivate CongratsPanel initially
        instructionsPanel.SetActive(true); // Activate InstructionsPanel initially

        // Start coroutine to hide the instructions UI after a delay
        StartCoroutine(HideInstructionsPanel());
    }

    public void CollectCollectible()
    {
        totalCoins++;
        CheckForCongrats();
    }

 
    private void CheckForCongrats()
    {
        if (totalCoins >= 5 && !congratsDisplayed)
        {
            congratsText.gameObject.SetActive(true); // Activate congratulatory text
            congratsPanel.SetActive(true); // Activate the parent GameObject (containing the image and the text)
            congratsDisplayed = true;

            StartCoroutine(DeactivateCongratsPanelAfterDelay(10f)); // Deactivate after 10 seconds
        }
    }

    private IEnumerator DeactivateCongratsPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for specified delay
        congratsText.gameObject.SetActive(false); // Deactivate congratulatory text
        congratsPanel.SetActive(false); // Deactivate the parent GameObject (containing the image and the text)
    }

    private IEnumerator HideInstructionsPanel()
    {
        yield return new WaitForSeconds(displayTime); // Wait for specified display time
        instructionsPanel.SetActive(false); // Deactivate instructions panel after display time
    }
}

   
