using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent healthComponent; // Reference to the entity's health component

    private void Awake()
    {
        // Automatically find the HealthComponent attached to the same GameObject
        healthComponent = GetComponent<HealthComponent>();
    }

    // Method to deal damage based on an integer value
    public void Damage(int damage)
    {
        if (healthComponent != null)
        {
            healthComponent.Subtract(damage);
        }
    }

    // Overloaded method to deal damage based on a Bullet object
    public void Damage(Bullet bullet)
    {
        if (healthComponent != null)
        {
            healthComponent.Subtract(bullet.damage);
        }
    }
}