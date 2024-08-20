/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * UPDATED DATE: 7JUL24
 * 2ND UPDATED VERS: 10JUL24 IMPLEMENTED THE FSM.
 * Description: 
 * Controls UI updates and game-wide events using a Finite State Machine (FSM) approach.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Needed for Slider
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Enum to represent different states of the game.
/// </summary>
public enum GameState
{
    MainMenu,       // Main menu state
    Gameplay,       // Gameplay state
    GameOver,       // Game over state
    PauseMenu,      // Pause menu state
    OptionsMenu     // Options menu state
}

/// <summary>
/// Manages game state transitions and UI updates.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    // UI Elements
    public TextMeshProUGUI congratsText;          // Text component for congratulations message
    public GameObject congratsPanel;              // Panel to display congratulations
    public GameObject instructionsPanel;          // Panel to display instructions
    public TextMeshProUGUI overallScoreText;      // Text component for overall score
    public TextMeshProUGUI uniqueScoreText;       // Text component for unique score
    public TextMeshProUGUI itemsLeftText;         // Text component for items left count
    public GameObject inventory;                  // Inventory UI panel
    public AudioSource mainMenuMusic;             // AudioSource for main menu music
    public GameObject mainMenuUI;                 // Main menu UI panel
    public GameObject gameplayUI;                 // Gameplay UI panel
    public GameObject gameOverUI;                 // Game over UI panel
    public GameObject pauseMenuUI;                // Pause menu UI panel
    public GameObject optionsMenuUI;              // Options menu UI panel
    public Slider volumeSlider;                   // Slider for adjusting volume

    private int totalCoins = 0;                   // Total number of collected coins
    private bool congratsDisplayed = false;       // Flag to check if congratulations message is displayed
    private GameState currentState;               // Current game state
    public float displayTime = 50f;               // Time to display the instructions UI

    /// <summary>
    /// Ensures only one instance of GameManager exists and persists across scenes.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy this instance if another exists
            return;
        }

        Instance = this; // Set the instance to this
        DontDestroyOnLoad(gameObject); // Ensure it persists across scenes
    }

    /// <summary>
    /// Initializes the game state and sets up the volume slider.
    /// </summary>
    private void Start()
    {
        ChangeState(GameState.MainMenu); // Start at Main Menu

        // Initialize volume slider
        if (volumeSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f); // Load saved volume or default to 0.5
            volumeSlider.value = savedVolume; // Set slider value
            SetVolume(savedVolume); // Set initial volume
            volumeSlider.onValueChanged.AddListener(SetVolume); // Update volume on slider change
        }
    }

    /// <summary>
    /// Sets the volume of the main menu music and saves the setting.
    /// </summary>
    /// <param name="volume">The volume level to set.</param>
    public void SetVolume(float volume)
    {
        if (mainMenuMusic != null)
        {
            mainMenuMusic.volume = volume; // Adjust the volume of the AudioSource
            PlayerPrefs.SetFloat("MusicVolume", volume); // Save volume setting
            PlayerPrefs.Save(); // Ensure the setting is saved
        }
    }

    /// <summary>
    /// Changes the game state and activates/deactivates the appropriate UI elements.
    /// </summary>
    /// <param name="newState">The new game state to transition to.</param>
    public void ChangeState(GameState newState)
    {
        // Deactivate all UI elements
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);

        // Handle the new state
        switch (newState)
        {
            case GameState.MainMenu:
                mainMenuUI.SetActive(true); // Show Main Menu UI
                mainMenuMusic.Play(); // Start Main Menu music
                break;
            case GameState.Gameplay:
                gameplayUI.SetActive(true); // Show Gameplay UI
                mainMenuMusic.Stop(); // Stop Main Menu music
                Time.timeScale = 1.0f; // Ensure game is running
                break;
            case GameState.GameOver:
                gameOverUI.SetActive(true); // Show Game Over UI
                mainMenuMusic.Stop(); // Stop Main Menu music
                break;
            case GameState.PauseMenu:
                pauseMenuUI.SetActive(true); // Show Pause Menu UI
                Time.timeScale = 0.0f; // Pause the game
                break;
            case GameState.OptionsMenu:
                optionsMenuUI.SetActive(true); // Show Options Menu UI
                break;
        }

        currentState = newState; // Update the current game state
    }

    /// <summary>
    /// Starts the game, showing instructions and transitioning to gameplay.
    /// </summary>
    public void StartGame()
    {
        Debug.Log("StartGame method called.");
        instructionsPanel.SetActive(true); // Ensure the instructions panel is shown
        Time.timeScale = 1.0f; // Resume game time
        ChangeState(GameState.Gameplay); // Transition to Gameplay state
        Debug.Log("Time.timeScale set to 1.0f.");
    }

    /// <summary>
    /// Pauses the game and shows the pause menu.
    /// </summary>
    public void PauseGame()
    {
        Debug.Log("PauseGame method called.");
        Time.timeScale = 0.0f; // Pause game time
        ChangeState(GameState.PauseMenu);
        Debug.Log("Time.timeScale set to 0.0f.");
    }

    /// <summary>
    /// Resumes the game and transitions back to gameplay.
    /// </summary>
    public void ResumeGame()
    {
        Debug.Log("ResumeGame method called.");
        Time.timeScale = 1.0f; // Resume game time
        ChangeState(GameState.Gameplay);
        Debug.Log("Time.timeScale set to 1.0f.");
    }

    /// <summary>
    /// Opens the options menu.
    /// </summary>
    public void OpenOptionsMenu()
    {
        ChangeState(GameState.OptionsMenu);
    }

    /// <summary>
    /// Closes the options menu and returns to gameplay.
    /// </summary>
    public void CloseOptionsMenu()
    {
        ChangeState(GameState.Gameplay);
    }

    /// <summary>
    /// Updates the total coins collected and overall score.
    /// </summary>
    public void CollectCollectible()
    {
        totalCoins++;
        UpdateOverallScore(totalCoins * 5); // Update overall score based on total coins
        CheckForCongrats(); // Check if congratulations should be displayed

        // Debug log to track total coins and overall score
        Debug.Log("Total Coins: " + totalCoins);
        Debug.Log("GameManager Overall Score: " + overallScoreText.text);
    }

    /// <summary>
    /// Displays the congratulations message if the total coins meet the threshold.
    /// </summary>
    private void CheckForCongrats()
    {
        if (totalCoins >= 5 && !congratsDisplayed)
        {
            congratsText.gameObject.SetActive(true);
            congratsPanel.SetActive(true);
            congratsDisplayed = true;

            StartCoroutine(DeactivateCongratsPanelAfterDelay(10f)); // Deactivate panel after 10 seconds
        }
    }

    /// <summary>
    /// Deactivates the congratulations panel after a specified delay.
    /// </summary>
    /// <param name="delay">The delay time in seconds before deactivating the panel.</param>
    /// <returns>An IEnumerator for coroutine execution.</returns>
    private IEnumerator DeactivateCongratsPanelAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay
        congratsText.gameObject.SetActive(false); // Hide congratulations text
        congratsPanel.SetActive(false); // Hide congratulations panel
    }

    /// <summary>
    /// Updates the overall score UI with the new score.
    /// </summary>
    /// <param name="newScore">The new score value to display.</param>
    private void UpdateOverallScore(int newScore)
    {
        overallScoreText.text = "Overall Score: " + newScore.ToString();
        // Debug log to track UI score updates
        Debug.Log("UI Overall Score Updated to: " + newScore);
    }

    /// <summary>
    /// Handles game over state.
    /// </summary>
    public void GameOver()
    {
        ChangeState(GameState.GameOver); // Transition to Game Over state
    }
}

