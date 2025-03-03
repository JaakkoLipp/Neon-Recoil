using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;  // The bullet prefab to shoot
    public Transform firePoint;      // Position where bullets spawn
    public float bulletSpeed = 10f;  // Speed of the bullet

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left Mouse Button / Ctrl
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * bulletSpeed;
    }
}
