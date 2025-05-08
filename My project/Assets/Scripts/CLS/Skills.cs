using UnityEngine;

public abstract class Skills
{
    protected string name;
    protected Sprite icon;
    protected float cooldown;
    protected float lastUseTime;

    public Skills(string name, Sprite icon, float cooldown) {
        this.name = name;
        this.icon = icon;
        this.cooldown = cooldown;
        this.lastUseTime = -cooldown; 
    }
     
     public abstract void Use(Carrier user);

     public bool CanUse() {
         return Time.time >= lastUseTime + cooldown;
     }

     public float GetCooldown() {
        return Mathf.Max(0, lastUseTime + cooldown - Time.time);
     }

     public (string, Sprite, float) GetSkillInfo() {
         return (name, icon, cooldown);
     }
}
