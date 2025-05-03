using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 8f;
    public float jump = 40f;
    public bool isFacingRight = true;
    public bool isPlayer1 = true;

    public Transform LaunchOfSet;
    public SpriteRenderer gunSpriteRenderer; 
    public WeaponData[] levelWeapons;
    private WeaponData currentWeapon;
    private float fireCooldown = 0f;

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
}
