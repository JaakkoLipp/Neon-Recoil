using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // Enemy health
    public float speed = 2f; // Movement speed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage! Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Remove enemy from scene
        Debug.Log("Enemy destroyed!");
    }
}
