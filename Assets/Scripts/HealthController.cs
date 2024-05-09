using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the terrorist
    private float currentHealth; // Current health of the terrorist

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Method to apply damage to the terrorist
    public void TakeDamage(float damage)
    {
        // Subtract damage from current health
        currentHealth -= damage;

        // Check if the terrorist has run out of health
        if (currentHealth <= 0)
        {
            Die(); // If so, destroy the terrorist
        }
    }

    // Method to handle the terrorist's death
    private void Die()
    {
        // Perform any death-related actions here (e.g., play death animation, spawn particles, etc.)
        Destroy(gameObject); // Destroy the terrorist GameObject
    }
}
