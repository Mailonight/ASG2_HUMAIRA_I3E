using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPortal : MonoBehaviour
{
    public string nextSceneName = "HellDimension"; // Next scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Calling the method to handle scene transition
            SceneTransitionManager.Instance.LoadNextScene(nextSceneName);
        }
    }
}
