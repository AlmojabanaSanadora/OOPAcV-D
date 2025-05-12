using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public PlayableCharacter character;
    public Slider healthBar;
    public Slider manaBar;
    public SkillsUI[] skillUIs;

    void Update() {
    var carrier = character.GetCarrier();
    var health = carrier.GetHealth();
    var mana = carrier.GetMana();

    healthBar.maxValue = health.GetMaxHealth();
    healthBar.value = health.GetCurrentHealth();

    manaBar.maxValue = mana.GetMaxMana();
    manaBar.value = mana.GetCurrentMana();

    // var skills = carrier.GetSkillSystem().GetSkills();
    // for (int i = 0; i < skillUIs.Length; i++) {
    //     if (i < skills.Count)
    //         skillUIs[i].SetSkill(null, skills[i].GetCooldown());
    //     else
    //         skillUIs[i].SetSkill(null, 0);
    // }
}
}
