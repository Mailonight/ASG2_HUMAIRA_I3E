/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * UPDATED DATE: 7JUL24
 * Description: 
 * To control the UI UPDATES & GAME-WIDE EVENTS.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI congratsText;
    public GameObject congratsPanel;
    public GameObject instructionsPanel;
    public TextMeshProUGUI overallScoreText;

    private int totalCoins = 0;
    private bool congratsDisplayed = false;

    public float displayTime = 5f; // Display time for instructions UI

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        congratsPanel.SetActive(false);
        instructionsPanel.SetActive(true);
        StartCoroutine(HideInstructionsPanel());

        Time.timeScale = 1.0f; // Ensure game starts with normal time scale
    }


    public void CollectCollectible()
    {
        totalCoins++;
        UpdateOverallScore(totalCoins * 5); // Update overall score
        CheckForCongrats();

        // Debug log to track total coins and overall score
        Debug.Log("Total Coins: " + totalCoins);
        Debug.Log("GameManager Overall Score: " + overallScoreText.text);
    }

    private void CheckForCongrats()
    {
        if (totalCoins >= 5 && !congratsDisplayed)
        {
            congratsText.gameObject.SetActive(true);
            congratsPanel.SetActive(true);
            congratsDisplayed = true;

            StartCoroutine(DeactivateCongratsPanelAfterDelay(10f));
        }
    }

    private IEnumerator DeactivateCongratsPanelAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        congratsText.gameObject.SetActive(false);
        congratsPanel.SetActive(false);
    }

    private IEnumerator HideInstructionsPanel()
    {
        yield return new WaitForSeconds(displayTime);
        instructionsPanel.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("StartGame method called.");
        instructionsPanel.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("Time.timeScale set to 1.0f.");
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame method called.");
        Time.timeScale = 0.0f;
        Debug.Log("Time.timeScale set to 0.0f.");
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame method called.");
        Time.timeScale = 1.0f;
        Debug.Log("Time.timeScale set to 1.0f.");
    }

    private void UpdateOverallScore(int newScore)
    {
        overallScoreText.text = "Overall Score: " + newScore.ToString();
        // Debug log to track UI score updates
        Debug.Log("UI Overall Score Updated to: " + newScore);
    }
}


