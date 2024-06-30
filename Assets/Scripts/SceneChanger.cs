using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Function to be called when Play button is pressed
    public void PlayGame()
    {
        // Change scene to the game scene
        SceneManager.LoadScene(0);
    }
}
