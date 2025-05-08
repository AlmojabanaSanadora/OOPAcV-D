using UnityEngine;

public class UsableCarrier : Carrier
{
    protected SkillSystem skills;

    public UsableCarrier(int maxHealth, int maxMana) 
    : base(maxHealth, maxMana) {
    skills = new SkillSystem();
    }
    
    public SkillSystem GetSkillSystem() => skills;

    public virtual void UseSkill(int slot) {
        skills.UseSkill(slot, this);
    }
}
