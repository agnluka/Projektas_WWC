using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 8f;
    public bool isFacingRight = true;
    public bool isPlayer1 = true;

    public GameObject bulletPrefab;
    public Transform LaunchOfSet;

    public GameObject outfits;

    private bool isWalking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        List<GameObject> outfitList = AllChilds(outfits);
        if (isPlayer1)
        {
            int key = PlayerPrefs.GetInt("Player1Clothes");
            if (key - 2 >= 0)
                outfitList[key - 2].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            int key = PlayerPrefs.GetInt("Player2Clothes");
            if (key - 2 >= 0)
                outfitList[key - 2].GetComponent<SpriteRenderer>().enabled = true;
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

        if(tim.remainingTime == 0)
        {
            enabled = false;

        }

        if (isPlayer1 && !TogglePause.isPaused)
        {
            // Jump
            if (Input.GetKeyDown(KeyCode.W) && rigidbody.linearVelocity.y == 0)
            {
                rigidbody.linearVelocity = Vector2.up * 40;
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Menulis")
                {
                    rigidbody.linearVelocity = Vector2.up * 60;
                }
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
            // Left movement
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

            Flip(isPlayer1);

            // Shoot
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
                AudioManager.instance.PlaySound(AudioManager.instance.shootingSound);
                AudioManager.instance.PlaySound(AudioManager.instance.hitSound);
            }
        }
        else if (!isPlayer1 && !TogglePause.isPaused)
        {
            // Jump
            if (Input.GetKeyDown(KeyCode.UpArrow) && rigidbody.linearVelocity.y == 0)
            {
                rigidbody.linearVelocity = Vector2.up * 40;
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

            Flip(isPlayer1);

            // Shoot
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Instantiate(bulletPrefab, LaunchOfSet.position, LaunchOfSet.rotation);
                AudioManager.instance.PlaySound(AudioManager.instance.shootingSound);
                AudioManager.instance.PlaySound(AudioManager.instance.hitSound);
            }
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
                Vector3 newPos = outfits.transform.localPosition;
                newPos.z *= -1f;
                outfits.transform.localPosition = newPos;
            }
        }
        else
        {
            if (isFacingRight && Input.GetKey(KeyCode.LeftArrow) || !isFacingRight && Input.GetKey(KeyCode.RightArrow))
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
                Vector3 newPos = outfits.transform.localPosition;
                newPos.z *= -1f;
                outfits.transform.localPosition = newPos;
            }
        }
    }

    // -------------
    private List<GameObject> AllChilds(GameObject root)
    {
        List<GameObject> result = new List<GameObject>();
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(result, VARIABLE.gameObject);
            }
        }
        return result;
    }

    private void Searcher(List<GameObject> list, GameObject root)
    {
        list.Add(root);
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(list, VARIABLE.gameObject);
            }
        }
    }
}
