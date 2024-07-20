using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject deathCanvas; // Reference to the death UI canvas
    public GameObject hpCanvas;    // Reference to the health UI canvas
    public Image healthFillImage;  // Reference to the UI Image component for health fill
    public TextMeshProUGUI deathMessageText; // Reference to a TextMeshProUGUI component for death message
    public GameObject redScreenPanel; // Reference to the red screen panel under deathCanvas

    private bool isDead = false;
    private float timeSinceLastDamage = 0f;
    private float damageInterval = 1f; // Interval in seconds for damage over time

    void Awake()
    {
        // Find the "DeathCanvas" GameObject in the scene
        GameObject foundDeathCanvas = GameObject.Find("DeathCanvas");

        // Check if foundDeathCanvas is not null before assigning to deathCanvas
        if (foundDeathCanvas != null)
        {
            deathCanvas = foundDeathCanvas;
        }
        else
        {
            // Log an error if "DeathCanvas" GameObject is not found
            Debug.LogError("Failed to find GameObject named 'DeathCanvas'. Ensure it exists in the scene.");
        }

        // Check if healthFillImage is null before trying to get component
        if (healthFillImage == null)
        {
            Debug.LogError("Health Fill Image reference not set in PlayerHealth script.");
        }
    }

    void Start()
    {
        // Log to console to check if deathCanvas is assigned
        Debug.Log("Death Canvas assigned: " + (deathCanvas != null));

        // Ensure hpCanvas is active from the start if it needs to be
        if (hpCanvas != null)
        {
            hpCanvas.SetActive(true);
        }

        currentHealth = maxHealth;
        ToggleDeathUI(false); // Hide the death UI initially

        // Ensure health fill Image reference is set
        if (healthFillImage == null)
        {
            Debug.LogError("Health Fill Image reference not set in PlayerHealth script.");
        }

        // Ensure deathCanvas reference is set
        if (deathCanvas == null)
        {
            Debug.LogError("Death Canvas reference not set in PlayerHealth script.");
        }

        // Ensure death message text reference is set
        if (deathMessageText == null)
        {
            Debug.LogError("Death Message Text reference not set in PlayerHealth script.");
        }

        // Update health bar UI initially
        UpdateHealthBar();
    }

    void Update()
    {
        if (!isDead)
        {
            // Damage over time while inside toxic gas
            if (timeSinceLastDamage >= damageInterval)
            {
                TakeDamage(5);
                timeSinceLastDamage = 0f;
            }
            else
            {
                timeSinceLastDamage += Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        // Update health bar UI after taking damage
        UpdateHealthBar();
    }

    void Die()
    {
        // Show death UI elements
        ToggleDeathUI(true);
        Time.timeScale = 0f; // Pause the game
        isDead = true;
    }

    void UpdateHealthBar()
    {
        if (healthFillImage != null)
        {
            // Calculate fill amount based on current health and max health
            float fillAmount = (float)currentHealth / maxHealth;
            healthFillImage.fillAmount = fillAmount;
        }
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void RestartLevel()
    {
        // Reload the current scene (restart the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Resume game time
    }

    public void ReturnToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Resume game time
    }

    void ToggleDeathUI(bool active)
    {
        if (deathCanvas != null)
        {
            deathCanvas.SetActive(active);

            if (active)
            {
                // Activate red screen panel under deathCanvas
                if (redScreenPanel != null)
                {
                    redScreenPanel.SetActive(true);
                }

                // Set death message text
                if (deathMessageText != null)
                {
                    deathMessageText.text = "YOU DIED! GAME OVER. PRESS PAUSE > EXIT.";
                }
            }
        }
        else
        {
            Debug.LogError("Death Canvas reference not set in PlayerHealth script.");
        }
    }
}