using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public int damage = 10; // Damage dealt by this entity

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a HitboxComponent
        if (other.TryGetComponent(out HitboxComponent hitbox))
        {
            // Prevent self-damage by checking tags or other identifiers if needed
            if (other.CompareTag(gameObject.tag))
                return;

            // Apply damage to the other entity
            hitbox.Damage(damage);
        }
    }
}