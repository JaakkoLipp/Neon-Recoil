using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // Speed of the bullet
    public int damage = 1;     // Damage the bullet deals
    public float lifeTime = 10f; // Bullet despawn time

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy bullet after 10 seconds
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Move forward
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); // Destroy bullet on impact
        }
        //else if (collision.CompareTag("Wall"))
        //{
        //    Destroy(gameObject); // Bullet disappears on hitting a wall
        //}
    }
}
