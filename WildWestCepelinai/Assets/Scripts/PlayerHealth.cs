using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject timer;
    public GameOverMenu gameOver;
    public GameObject otherPlayer;

    public int health;
    public int maxHealth = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has been defeated!");
        gameObject.SetActive(false);

        string winner = "Enemy CPU";
        GameObject winnerObject = null;

        if (otherPlayer != null && otherPlayer.activeInHierarchy)
        {
            winner = otherPlayer.name == "Player1" ? "Player 1" : "Player 2";
            winnerObject = otherPlayer;
        }

        gameOver.ShowWinner(winner, winnerObject);
        gameOver.gameOver();
        otherPlayer.SetActive(false);
    }
}
