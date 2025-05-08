using UnityEngine;

public class ManaSystem
{
    private int currentMana;
    private int maxMana;
    private ManaCondition condition; 

    public ManaSystem(int maxMana) {
        this.maxMana = maxMana;
        currentMana = maxMana;
    }
    public void Increase(int amount) {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
    }

    public void Decrease(int amount) {
        currentMana = Mathf.Max(currentMana - amount, 0);
    }

    public void SetCondition(ManaCondition condition) {
        this.condition = condition;
    }

    public ManaCondition GetCondition() => condition;


}
