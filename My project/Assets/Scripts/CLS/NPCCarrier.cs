using UnityEngine;

public class NPCCarrier : Carrier {
    public NPCCarrier(int maxHealth) : base(maxHealth, 0) {}

    public void OnDeath() {
        if (health.GetCurrentHealth() <= 0) {
    }
 }
}