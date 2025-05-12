using UnityEngine;

public class MagoSelvatico : PlayableCarrier 
{
    public MagoSelvatico(int maxHealth, int maxMana)
    : base(maxHealth, maxMana) {}

    public override void UseSkill(int slot) {
        var skill = GetSkillSystem().GetSkill(slot);
        if (skill != null && skill.CanUse()) {
            GetMana().Decrease(10); 
            base.UseSkill(slot);
        }
    }
}
