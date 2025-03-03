using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // Enemy health
    public float speed = 2f; // Movement speed
    public float patrolTime = 2f; // Time before switching direction
    public float detectionRange = 8f; // Enemy vision range
    public GameObject bulletPrefab; // Bullet prefab for shooting
    public Transform firePoint; // Fire position for bullets
    public float fireRate = 1.5f; // Time between shots
    private float nextFireTime;
    
    private bool movingRight = true;
    private Rigidbody2D rb;
    private Transform player;
    private float patrolTimer; // Timer for patrol switching

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag
        patrolTimer = patrolTime; // Initialize patrol timer
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            ShootPlayer(); // Enemy stops patrolling and shoots if player is seen
        }
        else
        {
            Patrol(); // Otherwise, patrol normally
        }
    }

    void Patrol()
    {
        rb.linearVelocity = new Vector2(movingRight ? speed : -speed, rb.linearVelocity.y);

        patrolTimer -= Time.deltaTime;
        if (patrolTimer <= 0)
        {
            Flip();
            patrolTimer = patrolTime; // Reset timer
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        transform.Rotate(0f, 180f, 0f); // Flip sprite to match direction
    }

    bool CanSeePlayer()
    {
        if (player == null) return false;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        return distanceToPlayer < detectionRange; // Returns true if player is in range
    }

    void ShootPlayer()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Calculate direction to player
            Vector2 direction = (player.position - firePoint.position).normalized;
            rb.linearVelocity = direction * 10f; // Adjust bullet speed

            Debug.Log("Enemy shoots at player!");
        }
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
