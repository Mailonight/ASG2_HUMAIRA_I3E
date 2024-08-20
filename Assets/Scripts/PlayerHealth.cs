/*Script purpose: In this script I hope to update the player health 
 and display the death screen canvas when player collide with a hazard,
in my game's case, the hazard would be a toxic gas. 

 Done by: Nur Humaira Binte Ahmad Nazim
*/


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the player's health, handles damage, and displays the death UI.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// The maximum health the player can have.
    /// </summary>
    public int maxHealth = 100;

    /// <summary>
    /// The current health of the player.
    /// </summary>
    public int currentHealth;

    /// <summary>
    /// Reference to the death UI canvas that is shown when the player dies.
    /// </summary>
    public GameObject deathCanvas;

    /// <summary>
    /// Reference to the health UI canvas that displays the player's health.
    /// </summary>
    public GameObject hpCanvas;

    /// <summary>
    /// The UI Image component for displaying the health bar.
    /// </summary>
    public Image healthFillImage;

    /// <summary>
    /// The TextMeshProUGUI component that displays the death message.
    /// </summary>
    public TextMeshProUGUI deathMessageText;

    /// <summary>
    /// The red screen panel that is activated during the death sequence.
    /// </summary>
    public GameObject redScreenPanel;

    private bool isDead = false;
    private float timeSinceLastDamage = 0f;
    private float damageInterval = 1f; // Interval in seconds for damage over time

    /// <summary>
    /// Initializes the player health and UI references.
    /// </summary>
    void Awake()
    {
        GameObject foundDeathCanvas = GameObject.Find("DeathCanvas");

        if (foundDeathCanvas != null)
        {
            deathCanvas = foundDeathCanvas;
        }
        else
        {
            Debug.LogError("Failed to find GameObject named 'DeathCanvas'. Ensure it exists in the scene.");
        }

        if (healthFillImage == null)
        {
            Debug.LogError("Health Fill Image reference not set in PlayerHealth script.");
        }
    }

    /// <summary>
    /// Sets initial values and checks UI references at the start of the game.
    /// </summary>
    void Start()
    {
        if (deathMessageText != null)
        {
            Debug.Log("Death Message Text reference is set.");
        }
        else
        {
            Debug.LogError("Death Message Text reference not set in PlayerHealth script.");
        }

        if (hpCanvas != null)
        {
            hpCanvas.SetActive(true);
        }

        currentHealth = maxHealth;
        ToggleDeathUI(false);

        UpdateHealthBar();
    }

    /// <summary>
    /// Updates the player's health and manages damage over time.
    /// </summary>
    void Update()
    {
        if (!isDead)
        {
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

    /// <summary>
    /// Applies damage to the player and checks for death.
    /// </summary>
    /// <param name="damage">The amount of damage to apply.</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    /// <summary>
    /// Handles the player's death, displays the death UI, and pauses the game.
    /// </summary>
    void Die()
    {
        ToggleDeathUI(true);
        Time.timeScale = 0f; // Pause the game
        isDead = true;
    }

    /// <summary>
    /// Updates the health bar UI based on the current health.
    /// </summary>
    void UpdateHealthBar()
    {
        if (healthFillImage != null)
        {
            float fillAmount = (float)currentHealth / maxHealth;
            healthFillImage.fillAmount = fillAmount;
        }
    }

    /// <summary>
    /// Restores the player's health to maximum and updates the health bar.
    /// </summary>
    public void RestoreHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    /// <summary>
    /// Restarts the current level by reloading the scene and resumes game time.
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Resume game time
    }

    /// <summary>
    /// Returns to the main menu scene and resumes game time.
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Resume game time
    }

    /// <summary>
    /// Toggles the visibility of the death UI and updates the death message.
    /// </summary>
    /// <param name="active">If true, activates the death UI; otherwise, deactivates it.</param>
    void ToggleDeathUI(bool active)
    {
        if (deathCanvas != null)
        {
            deathCanvas.SetActive(active);

            if (active)
            {
                if (redScreenPanel != null)
                {
                    redScreenPanel.SetActive(true);
                }

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

    /// <summary>
    /// Indicates whether the player is currently dead.
    /// </summary>
    public bool IsDead => isDead;
}