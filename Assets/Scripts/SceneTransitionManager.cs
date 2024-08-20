/// <summary>
/// Manages scene transitions and saves/loads game data across scenes.
/// </summary>
/// 

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the SceneTransitionManager.
    /// </summary>
    public static SceneTransitionManager Instance { get; private set; }

    /// <summary>
    /// Indicates whether the player has collected a unique crystal.
    /// </summary>
    public bool HasUniqueCrystal { get; set; }

    /// <summary>
    /// The total number of coins collected by the player.
    /// </summary>
    public int TotalCoins { get; set; }

    /// <summary>
    /// Initializes the singleton instance and ensures it persists across scenes.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Loads the next scene and saves the current game data.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void LoadNextScene(string sceneName)
    {
        // Save current data before loading the next scene
        SaveData();

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Saves the current game data to PlayerPrefs.
    /// </summary>
    private void SaveData()
    {
        // Save the state of collected items and other relevant data
        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        PlayerPrefs.SetInt("HasUniqueCrystal", HasUniqueCrystal ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Loads the saved game data from PlayerPrefs.
    /// </summary>
    public void LoadData()
    {
        // Load the state of collected items and other relevant data
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        HasUniqueCrystal = PlayerPrefs.GetInt("HasUniqueCrystal", 0) == 1;
    }
}
