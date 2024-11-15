using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the entity
    private int currentHealth;   // Current health of the entity

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Getter for current health
    public int CurrentHealth => currentHealth;

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