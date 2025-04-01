using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script
    public Slider healthSlider; // Reference to the health bar slider

    void Start()
    {
        // Initialize the slider's max value
        healthSlider.maxValue = playerHealth.maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.value = playerHealth.health;
        }
        else
        {
            healthSlider.value = playerHealth.health;
        }
    }
}