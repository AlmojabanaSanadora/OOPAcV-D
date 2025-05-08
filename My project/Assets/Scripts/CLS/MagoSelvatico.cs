using UnityEngine;

public class MagoSelvatico : UsableCarrier 
{
    public MagoSelvatico(int maxHealth, int maxMana)
    : base(maxHealth, maxMana) {}

    public override void UseSkill(int slot)
    {
     mana.Decrease(10);
     base.UseSkill(slot);   
    }
}
