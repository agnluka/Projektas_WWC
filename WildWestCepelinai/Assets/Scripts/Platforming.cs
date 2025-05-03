using System.Collections;
using UnityEngine;

public class Platforming : MonoBehaviour
{
    private MovingPlatform playerPlatform; // buvæs GameObject, dabar MovingPlatform

    [SerializeField] private CapsuleCollider2D playerCollider;

    public bool isPlayer1 = true;

    void Update()
    {
        if (isPlayer1 && !TogglePause.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.S) && playerPlatform != null)
            {
                StartCoroutine(DisaableCollision());
            }
        }
        else if (!isPlayer1 && !TogglePause.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && playerPlatform != null)
            {
                StartCoroutine(DisaableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") &&
            collision.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            playerPlatform = platform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") &&
            collision.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            if (playerPlatform == platform)
                playerPlatform = null;
        }
    }

    private IEnumerator DisaableCollision()
    {
        BoxCollider2D platformCollider = playerPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);

        transform.position += new Vector3(0, -0.1f, 0);

        yield return new WaitForSeconds(0.4f);

        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private void LateUpdate()
    {
        if (playerPlatform != null)
        {
            transform.position += playerPlatform.Velocity * Time.deltaTime;
        }
    }
}
