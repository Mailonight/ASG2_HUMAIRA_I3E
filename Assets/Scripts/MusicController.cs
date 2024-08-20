using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    private void Awake()
    {
        // Ensure only one instance of MusicController exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make sure the music persists between scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        // Ensure the music starts playing
        GetComponent<AudioSource>().Play();
    }
}
