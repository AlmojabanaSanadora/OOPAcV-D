using UnityEngine;

public class MagoAcuatico : UsableCarrier
{
    public MagoAcuatico(int maxHealth, int maxMana)
    : base(maxHealth, maxMana) {}
    
    public override void UseSkill(int slot) {
        health.TakeDamage(10);
        base.UseSkill(slot);
    }
}
