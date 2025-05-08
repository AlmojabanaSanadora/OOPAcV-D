using UnityEngine;

public class HealthSystem
{
    private int maxHealth;
    private int currentHealth;

    public HealthSystem(int maxHealth) {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;

    public void TakeDamage(int amount) {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
    }

    public void Heal(int amount) {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
}
