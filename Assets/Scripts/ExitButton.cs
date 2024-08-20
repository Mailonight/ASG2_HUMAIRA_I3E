using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Method to quit the application or stop play mode in the Editor
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the Unity Editor
#else
        Application.Quit(); // Quit the application in a standalone build
#endif
    }
}