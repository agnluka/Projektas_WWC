using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 25f;
    public int damage = 10;
    public string shooterTag;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.right * Time.deltaTime * Speed;
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits a player and it's NOT the shooter
        if (collision.CompareTag("Player1") && shooterTag != "Player1")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player2") && shooterTag != "Player2")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Wall"))  // Destroy bullet if it hits a wall
        {
            Destroy(gameObject);
        }
    }
}
