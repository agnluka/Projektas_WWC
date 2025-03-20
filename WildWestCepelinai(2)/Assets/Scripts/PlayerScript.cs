using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 8f;
    public bool isFacingRight = true;
    public bool isPlayer1 = true;

    public GameObject bulletPrefab;
    public Transform LaunchOfSet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        enabled = false;
        yield return new WaitForSeconds(3); // fixed delay
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if(tim.remainingTime == 0)
        {
            enabled = false;
        }

        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.W) && rigidbody.linearVelocityY == 0)
            {
                rigidbody.linearVelocity = Vector2.up * 40;
            } // jump

            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.linearVelocity = new Vector2(xInput * speed, rigidbody.linearVelocityY);
            } // right

            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.linearVelocity = new Vector2(xInput * speed, rigidbody.linearVelocityY);
            } // left

            Flip(isPlayer1);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
            } // shoot
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && rigidbody.linearVelocityY == 0)
            {
                rigidbody.linearVelocity = Vector2.up * 40;
            } // jump

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody.linearVelocity = new Vector2(xInput * speed, rigidbody.linearVelocityY);
            } // right

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidbody.linearVelocity = new Vector2(xInput * speed, rigidbody.linearVelocityY);
            } // left

            Flip(isPlayer1);

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Instantiate(bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
            } // shoot
        }

    }

    private void Flip(bool pl1)
    {
        if (pl1)
        {
            if (isFacingRight && Input.GetKey(KeyCode.A) || !isFacingRight && Input.GetKey(KeyCode.D))
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
        else
        {
            if (isFacingRight && Input.GetKey(KeyCode.LeftArrow) || !isFacingRight && Input.GetKey(KeyCode.RightArrow))
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }
}
