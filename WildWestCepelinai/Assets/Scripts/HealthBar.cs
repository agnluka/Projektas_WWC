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
    }
}

//using UnityEngine;
//using UnityEngine.UI;

//public class HealthBar : MonoBehaviour
//{
//    public PlayerHealth playerHealth; // Reference to the PlayerHealth script
//    public Slider healthSlider; // Reference to the health bar slider

//    [Header("Level-based Appearance")] // --- NEW SECTION
//    public Image fillImage;            // Drag your Fill object here
//    public Image shroomImage;          // Drag your Shroom image here

//    public Sprite level1Shroom;
//    public Sprite level2Shroom;
//    public Sprite level3Shroom;

//    public Color level1Color = Color.red;
//    public Color level2Color = Color.green;
//    public Color level3Color = Color.magenta;

//    void Start()
//    {
//        if (playerHealth != null)
//            healthSlider.maxValue = playerHealth.maxHealth;

//        UpdateHealthBar();

//        // NEW: Apply visuals based on current level
//        int level = PlayerPrefs.GetInt("Level", 1);
//        ApplyLevelAppearance(level);
//    }

//    void Update()
//    {
//        UpdateHealthBar();
//    }

//    void UpdateHealthBar()
//    {
//        if (playerHealth != null && healthSlider != null)
//        {
//            healthSlider.value = playerHealth.health;
//        }
//    }

//    // === NEW METHOD ===
//    void ApplyLevelAppearance(int level)
//    {
//        switch (level)
//        {
//            case 1:
//                if (shroomImage != null) shroomImage.sprite = level1Shroom;
//                if (fillImage != null) fillImage.color = level1Color;
//                break;
//            case 2:
//                if (shroomImage != null) shroomImage.sprite = level2Shroom;
//                if (fillImage != null) fillImage.color = level2Color;
//                break;
//            case 3:
//                if (shroomImage != null) shroomImage.sprite = level3Shroom;
//                if (fillImage != null) fillImage.color = level3Color;
//                break;
//        }
//    }
//}
