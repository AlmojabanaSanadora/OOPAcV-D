using UnityEngine;

public abstract class Carrier
{
    protected HealthSystem health;
    protected ManaSystem mana;

    public Carrier(int maxHealth, int maxMana) {
        this.health = new HealthSystem(maxHealth);
        this.mana = new ManaSystem(maxMana);
    }

    public HealthSystem GetHealth() => health;
    public ManaSystem GetMana() => mana;

    public void TakeDamage(int amount) => health.TakeDamage(amount);
    public void Heal(int amount) => health.Heal(amount);
}
