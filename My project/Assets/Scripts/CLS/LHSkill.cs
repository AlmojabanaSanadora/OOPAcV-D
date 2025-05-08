using UnityEngine;

public class LHSkill : Skills 
{
    private int healAmount;

    public LHSkill(string name, Sprite icon, float cooldown, int healAmount)
        : base(name, icon, cooldown) {
        this.healAmount = healAmount;
    }

    public override void Use(Carrier user) {
        lastUseTime = Time.time;
        user.Heal(healAmount);
    }
}
