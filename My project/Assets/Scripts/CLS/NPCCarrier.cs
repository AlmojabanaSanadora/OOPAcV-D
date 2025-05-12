using UnityEngine;

public class NPCCarrier : Carrier {
    public NPCCarrier(int maxHealth) : base(maxHealth, 0) {}

    public override void OnDeath() {
        Debug.Log("NPC ha muerto");
    }

    public override void TakeDamage(int amount) {
        base.TakeDamage(amount);
        Debug.Log("NPC recibió daño. Vida actual: " + GetHealth().GetCurrentHealth());
    }
}