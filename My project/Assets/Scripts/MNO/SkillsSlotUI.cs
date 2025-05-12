using UnityEngine;
using UnityEngine.UI;

public class SkillsSlotUI : MonoBehaviour {
    public Image cooldownOverlay;
    private Skills skill;

    public void SetSkill(Skills newSkill) {
        skill = newSkill;
        cooldownOverlay.enabled = false;
        Debug.Log($"[{gameObject.name}] Skill asignada: {skill?.GetName()}");
    }

    void Update() {
        if (skill == null) {
            Debug.LogWarning($"[{gameObject.name}] No hay skill asignada.");
            return;
        }

        float cooldownRemaining = skill.GetCooldownRemaining();
        float totalCooldown = skill.GetCooldownTime();

        Debug.Log($"[{gameObject.name}] Cooldown restante: {cooldownRemaining:0.00}");

        bool onCooldown = cooldownRemaining > 0f;
        cooldownOverlay.enabled = onCooldown;

        if (onCooldown) {
            Debug.Log($"[{gameObject.name}] ¡En cooldown! Overlay activado.");
        }
    }
}