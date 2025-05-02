using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 8f;
    public float jump = 40f;
    public bool isFacingRight = true;
    public float detectionRange = 25f;
    public float stopRange = 7f;
    public float shootCooldown = 0.05f;
    public float jumpCooldown = 2f;

    public GameObject bulletPrefab;
    public Transform LaunchOfSet;

    public Transform player;

    private float nextShootTime = 0f;
    private float nextJumpTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        switch (PlayerPrefs.GetInt("Level"))
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
            AudioManager.instance.PlaySound(AudioManager.instance.walkingSound);
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
            AudioManager.instance.PlaySound(AudioManager.instance.jumpSound);
        }
    }

    private void TryShoot()
    {
        if (Time.time >= nextShootTime && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            Instantiate(bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
            nextShootTime = Time.time + shootCooldown;
            AudioManager.instance.PlaySound(AudioManager.instance.shootingSound);
            AudioManager.instance.PlaySound(AudioManager.instance.hitSound);
        }
            
    }
}
