using UnityEngine;

public abstract class Skills
{
    protected string name;
    protected float cooldown;
    protected float lastUseTime;

    public Skills(string name, float cooldown) {
        this.name = name;
        this.cooldown = cooldown;
        this.lastUseTime = -cooldown; 
    }
     
     public abstract void Use(Carrier user);

     public bool CanUse() {
         return Time.time >= lastUseTime + cooldown;
     }

     public float GetCooldownRemaining() {
        return Mathf.Max(0, lastUseTime + cooldown - Time.time);
     }

    public float GetCooldownTime() => cooldown;
    public string GetName() => name;

     public (string, float) GetSkillInfo() {
         return (name, cooldown);
     }


}
