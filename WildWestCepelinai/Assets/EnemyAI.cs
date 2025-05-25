using System.Collections;
using UnityEngine;
using UnityEngine.UI; 


public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 8f;
    public float jump = 40f;
    public bool isFacingRight = true;
    public float detectionRange = 25f;
    public float stopRange = 7f;
    public float shootCooldown = 0.5f;
    public float jumpCooldown = 2f;

    //public GameObject bulletPrefab;
    public Transform LaunchOfSet;
    public WeaponData[] levelWeapons;
    private WeaponData currentWeapon;
    public SpriteRenderer gunSpriteRenderer;

    public Transform player;

    private float nextShootTime = 0f;
    private float nextJumpTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        int level = PlayerPrefs.GetInt("Level", 1);
        level = Mathf.Clamp(level, 1, levelWeapons.Length);
        currentWeapon = levelWeapons[level - 1];

        if (gunSpriteRenderer != null && currentWeapon.gunSprite != null)
        {
            gunSpriteRenderer.sprite = currentWeapon.gunSprite;
            LaunchOfSet.localPosition = currentWeapon.launchOffsetLocalPosition;
            gunSpriteRenderer.transform.localScale = currentWeapon.gunScale;
        }

        SetupHealthBarVisuals();
        SetupSettingsButton();

        switch (level)
        {
            case 2:
                rigidbody.gravityScale = 7; jump = 50f; break;
            case 3:
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); jump = 60f; break;
        }
        enabled = false;
        yield return new WaitForSeconds(3); // fixed delay
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverMenu.isGameOver)
        {
            rigidbody.linearVelocity = Vector2.zero;
            return;
        }

        MoveTowardPlayer();
        TryJump();
        TryShoot();
    }

    private void MoveTowardPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= detectionRange && distance >= stopRange)
        {
            float direction = player.position.x - transform.position.x;
            rigidbody.linearVelocity = new Vector2(Mathf.Sign(direction) * speed, rigidbody.linearVelocity.y);
            Flip(direction);
            AudioManager.instance?.PlaySound(AudioManager.instance.walkingSound);
        }
    }

    private void Flip(float direction)
    {
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void TryJump()
    {
        if (Time.time >= nextJumpTime && rigidbody.linearVelocity.y == 0 && player.position.y > transform.position.y + 10f)
        {
            rigidbody.linearVelocity = Vector2.up * jump;
            nextJumpTime = Time.time + jumpCooldown;
            AudioManager.instance?.PlaySound(AudioManager.instance.jumpSound);
        }
    }

    private void TryShoot()
    {
        if (Time.time >= nextShootTime && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            GameObject bullet = Instantiate(currentWeapon.bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
            BulletScript bulletScript = bullet.GetComponent<BulletScript>();
            if (bulletScript != null)
            {
                bulletScript.Speed = currentWeapon.bulletSpeed;
                bulletScript.damage = currentWeapon.damage;
                bulletScript.shooterTag = gameObject.tag;
            }

            nextShootTime = Time.time + currentWeapon.fireRate + shootCooldown;
            AudioManager.instance?.PlaySound(AudioManager.instance.shootingSound);
            AudioManager.instance?.PlaySound(AudioManager.instance.hitSound);
        }
    }

    [System.Serializable]
    public class UIStyle
    {
        [Header("Health Bar")]
        public Sprite frameSprite;
        public Sprite fillSprite;
        public Sprite mushroomSprite; // Added back shroom
        public Color fillColor = Color.green;

        [Header("Settings Button")]
        public Sprite settingsIcon;
    }

    public UIStyle[] levelUIStyles;
    private Image healthBarFill;
    private Image mushroomIconImage; // Added back shroom reference

    private void SetupHealthBarVisuals()
    {
        int levelIndex = Mathf.Clamp(PlayerPrefs.GetInt("Level") - 1, 0, levelUIStyles.Length - 1);
        UIStyle style = levelUIStyles[levelIndex];

        // Using P2 HealthBar as requested
        GameObject healthBarObj = GameObject.Find("P2 HealthBar");

        if (healthBarObj == null)
        {
            Debug.LogError("P2 HealthBar not found!");
            return;
        }

        // 1. Handle Slider fill
        Slider slider = healthBarObj.GetComponent<Slider>();
        if (slider != null && slider.fillRect != null)
        {
            healthBarFill = slider.fillRect.GetComponent<Image>();
            healthBarFill.color = style.fillColor;
            healthBarFill.sprite = style.fillSprite;
        }

        // 2. Handle Frame/Border
        Transform border = healthBarObj.transform.Find("Border");
        if (border != null)
        {
            Image borderImage = border.GetComponent<Image>();
            if (borderImage != null) borderImage.sprite = style.frameSprite;
        }

        // 3. Handle Mushroom icon - EXACTLY like PlayerScript
        Transform shroom = healthBarObj.transform.Find("Shroom");
        if (shroom != null)
        {
            mushroomIconImage = shroom.GetComponent<Image>();
            if (mushroomIconImage != null)
                mushroomIconImage.sprite = style.mushroomSprite;
        }
    }

    private void SetupSettingsButton()
    {
        // Identical to PlayerScript implementation
        int levelIndex = Mathf.Clamp(PlayerPrefs.GetInt("Level") - 1, 0, levelUIStyles.Length - 1);
        UIStyle style = levelUIStyles[levelIndex];

        GameObject settingsButton = GameObject.Find("Button_settings");
        if (settingsButton != null && style.settingsIcon != null)
        {
            Image buttonImage = settingsButton.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = style.settingsIcon;
            }
        }
    }


}
