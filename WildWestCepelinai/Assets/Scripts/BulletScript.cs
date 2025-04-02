using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 25f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //Destroy(gameObject);
    }
}
