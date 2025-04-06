using System.Collections;
using UnityEngine;

public class Platforming : MonoBehaviour
{
    private GameObject playerPlatform;

    [SerializeField] private CapsuleCollider2D playerCollider;

    public bool isPlayer1 = true;

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1 && !TogglePause.isPaused)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                if(playerPlatform != null)
                {
                    StartCoroutine(DisaableCollision());
                }
            }
        }
        else if (!isPlayer1 && !TogglePause.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (playerPlatform != null)
                {
                    StartCoroutine(DisaableCollision());
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            playerPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerPlatform = null;
        }
    }

    private IEnumerator DisaableCollision()
    {
        BoxCollider2D platformCollider = playerPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
