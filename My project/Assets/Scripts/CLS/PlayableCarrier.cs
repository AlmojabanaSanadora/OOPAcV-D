using UnityEngine;

public class PlayableCarrier : Carrier
{
    protected SkillSystem skills;

    public PlayableCarrier(int maxHealth, int maxMana) 
    : base(maxHealth, maxMana) {
    skills = new SkillSystem();
    }
    
    public SkillSystem GetSkillSystem() => skills;

    public virtual void UseSkill(int slot) {
    var skill = skills.GetSkill(slot);
    if (skill != null && skill.CanUse()) {
        skills.UseSkill(slot, this);
    }
}
}
