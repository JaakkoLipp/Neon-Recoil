using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 0.5f;  // Adjust speed for smooth scrolling
    private Vector2 startPos;
    private float spriteWidth;

    void Start()
    {
        startPos = transform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, spriteWidth);
        transform.position = startPos + Vector2.left * newPosition;
    }
}
