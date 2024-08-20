using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages scene transitions in the game.
/// </summary>
public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// Called when the Play button is pressed.
    /// Changes the scene to the game scene.
    /// </summary>
    public void PlayGame()
    {
        // Change scene to the game scene by loading the scene with build index 0
        SceneManager.LoadScene(0);
    }
}
