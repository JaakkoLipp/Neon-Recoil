using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // Set max health
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Player starts with full health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage! Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player Died! Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart game
    }
}
