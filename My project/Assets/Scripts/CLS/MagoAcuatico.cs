using UnityEngine;

public class MagoAcuatico : PlayableCarrier
{
    public MagoAcuatico(int maxHealth, int maxMana)
    : base(maxHealth, maxMana) {}
    
    public override void UseSkill(int slot) {
        var skill = GetSkillSystem().GetSkill(slot);
        if (skill != null && skill.CanUse()) {
            TakeDamage(5); 
            base.UseSkill(slot);
        }
    }
}
