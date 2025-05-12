using UnityEngine;
using System.Collections;

public class SkillsUI : MonoBehaviour {
    public PlayableCharacter player;
    public SkillsSlotUI[] slots;

    void Start() {
        StartCoroutine(WaitForCarrierAndAssignSkills());
    }

    IEnumerator WaitForCarrierAndAssignSkills() {
        if (player == null) {
            Debug.LogError("SkillUI: Player no asignado.");
            yield break;
        }

        int tries = 0;
        while (player.GetCarrier() == null && tries < 20) {
            yield return null; // espera un frame
            tries++;
        }

        var carrier = player.GetCarrier();

        if (carrier == null) {
            Debug.LogError("SkillUI: El jugador nunca tuvo Carrier.");
            yield break;
        }

        var skills = carrier.GetSkillSystem().GetSkills();

        for (int i = 0; i < slots.Length && i < skills.Count; i++) {
            Debug.Log($"Asignando skill [{skills[i].GetName()}] al slot {i}");
            slots[i].SetSkill(skills[i]);
        }
    }
}
