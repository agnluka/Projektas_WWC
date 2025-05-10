using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI; 

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 8f;
    public float jump = 40f;
    public bool isFacingRight = true;
    public bool isPlayer1 = true;
    public Animator anima;

    public Transform LaunchOfSet;
    public SpriteRenderer gunSpriteRenderer;
    public WeaponData[] levelWeapons;
    private WeaponData currentWeapon;
    private float fireCooldown = 0f;

    private Image mushroomIconImage; // for mushroom UI


    /// <summary>
    /// ////
    /// 
    /// </summary>

    [System.Serializable]
    public class UIStyle
    {
        [Header("Health Bar")]
        public Sprite frameSprite;
        public Sprite fillSprite;
        public Sprite mushroomSprite;
        public Color fillColor = Color.green;

        [Header("Settings Button")]
        public Sprite settingsIcon; // Add this line
    }
    public UIStyle[] levelUIStyles;
   // public HealthBarStyle[] levelHealthBarStyles; // Assign in Inspector
    private Image healthBarFill; // Reference to the fill image

    //public GameObject hats;
    //public GameObject outfits;

    private bool isWalking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        int level = PlayerPrefs.GetInt("Level");
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
                Vector3 pos = transform.position;
                pos.y = -3.8f;
                transform.position = pos;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); jump = 50f; break;
        }
        enabled = false;
        yield return new WaitForSeconds(3); // fixed delay
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //if(tim.remainingTime == 0)
        //{
        //    //enabled = false;

        //}
        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (isPlayer1 && !TogglePause.isPaused)
        {
            // Jump
            if (Input.GetKeyDown(KeyCode.W) && rigidbody.linearVelocity.y == 0)
            {
                rigidbody.linearVelocity = Vector2.up * jump;
                AudioManager.instance.PlaySound(AudioManager.instance.jumpSound);
            }

            // Right movement
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.linearVelocity = new Vector2(speed, rigidbody.linearVelocity.y);
                if (!isWalking)
                {
                    AudioManager.instance.PlaySound(AudioManager.instance.walkingSound);
                    isWalking = true;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rigidbody.linearVelocity = new Vector2(-speed, rigidbody.linearVelocity.y);
                if (!isWalking)
                {
                    AudioManager.instance.PlaySound(AudioManager.instance.walkingSound);
                    isWalking = true;
                }
            }
            else
            {
                rigidbody.linearVelocity = new Vector2(0, rigidbody.linearVelocity.y);
                isWalking = false;
            }
            Flip();

            // Shoot
            bool firePressed = currentWeapon.automaticFire ? Input.GetKey(KeyCode.E) : Input.GetKeyDown(KeyCode.E);
            if (firePressed && fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = currentWeapon.fireRate;
            }
        }
        else if (!isPlayer1 && !TogglePause.isPaused)
        {
            // Jump
            if (Input.GetKeyDown(KeyCode.UpArrow) && rigidbody.linearVelocity.y == 0)
            {
                rigidbody.linearVelocity = Vector2.up * 40;
                if (PlayerPrefs.GetInt("Level") == 2)
                {
                    rigidbody.linearVelocity = Vector2.up * 50;
                }
                AudioManager.instance.PlaySound(AudioManager.instance.jumpSound);
            }

            // Right movement
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody.linearVelocity = new Vector2(speed, rigidbody.linearVelocity.y);
                if (!isWalking)
                {
                    AudioManager.instance.PlaySound(AudioManager.instance.walkingSound);
                    isWalking = true;
                }
            }
            // Left movement
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidbody.linearVelocity = new Vector2(-speed, rigidbody.linearVelocity.y);
                if (!isWalking)
                {
                    AudioManager.instance.PlaySound(AudioManager.instance.walkingSound);
                    isWalking = true;
                }
            }
            else
            {
                rigidbody.linearVelocity = new Vector2(0, rigidbody.linearVelocity.y);
                isWalking = false;
            }
            Flip();

            // Shoot
            bool firePressed = currentWeapon.automaticFire ? Input.GetKey(KeyCode.RightControl) : Input.GetKeyDown(KeyCode.RightControl);
            if (firePressed && fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = currentWeapon.fireRate;
            }
        }
    }

    private void Flip()
    {
        if (isPlayer1)
        {
            if (isFacingRight && Input.GetKey(KeyCode.A) || !isFacingRight && Input.GetKey(KeyCode.D))
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
                //Vector3 newPos = outfits.transform.localPosition;
                //newPos.z *= -1f;
                //outfits.transform.localPosition = newPos;
                //hats.transform.localPosition = newPos;
            }
        }
        else
        {
            if (isFacingRight && Input.GetKey(KeyCode.LeftArrow) || !isFacingRight && Input.GetKey(KeyCode.RightArrow))
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
                //Vector3 newPos = outfits.transform.localPosition;
                //newPos.z *= -1f;
                //outfits.transform.localPosition = newPos;
                //hats.transform.localPosition = newPos;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(currentWeapon.bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        if (bulletScript != null)
        {
            bulletScript.Speed = currentWeapon.bulletSpeed;
            bulletScript.damage = currentWeapon.damage;
            bulletScript.shooterTag = gameObject.tag;
        }
        AudioManager.instance.PlaySound(AudioManager.instance.shootingSound);
        AudioManager.instance.PlaySound(AudioManager.instance.hitSound);

    }

    ////
    private void SetupHealthBarVisuals()
    {
        int levelIndex = Mathf.Clamp(PlayerPrefs.GetInt("Level") - 1, 0, levelUIStyles.Length - 1);
        UIStyle style = levelUIStyles[levelIndex];

        string healthBarName = isPlayer1 ? "P1 HealthBar" : "P2 HealthBar";
        GameObject healthBarObj = GameObject.Find(healthBarName);

        if (healthBarObj == null)
        {
            Debug.LogError($"{healthBarName} not found!");
            return;
        }

        // 1. Handle Slider fill
        Slider slider = healthBarObj.GetComponent<Slider>();
        if (slider != null)
        {
            if (slider.fillRect != null)
            {
                Image fillImage = slider.fillRect.GetComponent<Image>();
                fillImage.color = style.fillColor;
                fillImage.sprite = style.fillSprite;
            }
        }

        // 2. Handle Frame/Border
        Transform border = healthBarObj.transform.Find("Border");
        if (border != null)
        {
            Image borderImage = border.GetComponent<Image>();
            if (borderImage != null && style.frameSprite != null)
            {
                borderImage.sprite = style.frameSprite;
            }
        }

        // 3. Handle Mushroom icon - CRITICAL FIX
        Transform shroom = healthBarObj.transform.Find("Shroom");
        if (shroom != null)
        {
            mushroomIconImage = shroom.GetComponent<Image>();
            if (mushroomIconImage != null && style.mushroomSprite != null)
            {
                mushroomIconImage.sprite = style.mushroomSprite;
                Debug.Log($"Set mushroom sprite to {style.mushroomSprite.name}");
            }
        }
        else
        {
            Debug.LogError("Shroom object not found under health bar!");
        }
    }

    private void SetupSettingsButton()
    {
        int levelIndex = Mathf.Clamp(PlayerPrefs.GetInt("Level") - 1, 0, levelUIStyles.Length - 1);
        UIStyle style = levelUIStyles[levelIndex];

        // Find and update settings button
        GameObject settingsButton = GameObject.Find("Button_settings");
        if (settingsButton != null && style.settingsIcon != null)
        {
            Image buttonImage = settingsButton.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = style.settingsIcon;
                Debug.Log($"Updated settings icon to {style.settingsIcon.name}");
            }
        }
    }
}


