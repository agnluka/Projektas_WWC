using Unity.VisualScripting;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    //public static event Action OnPlayerDeath;

    public GameOverMenu gameoverUi;

    private bool isDead;

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

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Die();
            gameoverUi.gameOver();
            //OnPlayerDeath?.Invoke();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has been defeated!");
        gameObject.SetActive(false);
         // Disables the player, you can add respawn logic here.
    }
}
