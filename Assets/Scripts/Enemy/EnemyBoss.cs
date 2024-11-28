using UnityEngine;

public class EnemyBoss : Enemy
{
    private Vector2 direction;
    private float speed = 2f; // Set your desired speed

    protected override void Start()
    {
        base.Start();
        // Determine spawn direction: move left if spawned on the right side, and vice versa
        direction = transform.position.x > 0 ? Vector2.left : Vector2.right;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Reverse direction when the enemy goes beyond the screen bounds
        if (transform.position.x < -10 || transform.position.x > 10) // Adjust screen boundaries as needed
        {
            direction = -direction;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destroy or return to object pool
    }   
}