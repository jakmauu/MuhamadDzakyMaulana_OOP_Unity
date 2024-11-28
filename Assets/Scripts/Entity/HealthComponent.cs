using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public float maxHealth;

    [SerializeField] private float currentHealth;
    
    public float CurrentHealth => currentHealth;   // Current health of the entity

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Method to subtract health when taking damage
    public void Subtract(int damage)
    {
        currentHealth -= damage;
        
        // Check if health has dropped to or below zero
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destroy the GameObject if health is zero
        }
    }
}