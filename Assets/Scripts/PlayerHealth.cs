using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathUI; // Reference to the death UI panel
    public Text deathMessageText; //  Reference to a Text component for death message
    public Image healthFillImage; // Reference to the UI Image component for health fill

    private bool isDead = false;
    private float timeSinceLastDamage = 0f;
    private float damageInterval = 1f; // Interval in seconds for damage over time

    void Start()
    {
        currentHealth = maxHealth;
        ToggleDeathUI(false); // Hide the death UI initially

        // Ensure health fill Image reference is set
        if (healthFillImage == null)
        {
            Debug.LogError("Health Fill Image reference not set in PlayerHealth script.");
        }

        // Update health bar UI initially
        UpdateHealthBar();
    }

    void Update() //need to check if our player is still alive , hence !isDead
    {
        if (!isDead) //still alive
        {
            // Damage over time while inside toxic gas
            if (timeSinceLastDamage >= damageInterval)
            {
                TakeDamage(5); // Adjust damage amount as needed
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
    public void RestoreHealth()
    {
        currentHealth = maxHealth;

        // Update health bar UI after restoring health
        UpdateHealthBar();
    }
    void Die()
    {
        // Show death UI elements
        ToggleDeathUI(true);
        Time.timeScale = 0f; // Pause the game
        isDead = true; //isdead to track is the player has died
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
        if (deathUI != null)
        {
            deathUI.SetActive(active);

            if (active && deathMessageText != null)
            {
                deathMessageText.text = "You Died"; // Customize death message if needed
            }
        }
        else
        {
            Debug.LogError("Death UI GameObject reference not set in PlayerHealth script.");
        }
    }
}
