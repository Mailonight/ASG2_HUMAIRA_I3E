//Description: Handle triggering the damage over time effect,'TakeDamage'
//when the player enters the toxic gas area & stops the effect,
//'RestoreHealth' when the player exits.
using UnityEngine;
using UnityEngine.UI;

public class ToxicGas : MonoBehaviour
{
    public GameObject deathCanvas; // Reference to the DeathCanvas
    public float damagePerSecond = 10f; // Adjust as per your game's balance
    public float healthReductionInterval = 1f; // Interval in seconds for health reduction

    private PlayerHealth playerHealth;
    private GameObject redScreenPanel; // Reference to the red screen panel
    private float timeSinceLastDamage = 0f;

    void Start()
    {
        redScreenPanel = deathCanvas.transform.Find("redScreenPanel").gameObject;
        redScreenPanel.SetActive(false); // Initially hide the red screen panel
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Show red screen panel with 50% transparency
                redScreenPanel.SetActive(true);
                SetRedScreenTransparency(111); // Adjust transparency as needed
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Damage the player over time
            timeSinceLastDamage += Time.deltaTime;
            if (timeSinceLastDamage >= healthReductionInterval)
            {
                timeSinceLastDamage = 0f;
                playerHealth.TakeDamage(Mathf.RoundToInt(damagePerSecond));
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide red screen panel when player exits the trigger zone
            redScreenPanel.SetActive(false);
            // Restore player health upon leaving the trigger zone
            playerHealth.RestoreHealth();
        }
    }

    void SetRedScreenTransparency(int alpha)
    {
        // Get the RectTransform component of the UI panel
        RectTransform panelRectTransform = redScreenPanel.GetComponent<RectTransform>();
        if (panelRectTransform != null)
        {
            // Set the alpha value of the color
            Image panelImage = redScreenPanel.GetComponent<Image>();
            Color panelColor = panelImage.color;
            panelColor.a = alpha / 255f;
            panelImage.color = panelColor;
        }
    }
}