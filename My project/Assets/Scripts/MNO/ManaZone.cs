using UnityEngine;
using System.Collections.Generic;

public class ManaZone : MonoBehaviour {
    public int hAmount = 5;
    private float duration = 3f;

    private Dictionary<Carrier, float> timers = new Dictionary<Carrier, float>();
    private void Start() {
        Destroy(gameObject, duration);
    }

    private void OnTriggerStay(Collider other) {
        Carrier target = null;

        var playable = other.GetComponent<PlayableCharacter>();
        if (playable != null) target = playable.GetCarrier();

        var npc = other.GetComponent<NPCTarget>();
        if (npc != null) target = npc.GetCarrier();

        if (target != null) {
            if (!timers.ContainsKey(target)) timers[target] = 0f;

            timers[target] += Time.deltaTime;

            if (timers[target] >= 1f) {
                target.Heal(hAmount);
                target.GetMana().Increase(hAmount); 
                timers[target] = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
{
    var pc = other.GetComponent<PlayableCharacter>();
    if (pc == null) return;

    var carrier = pc.GetCarrier();
    if (carrier == null) return;

    var mana = carrier.GetMana();
    if (mana == null) return;

    if (timers.ContainsKey(carrier)) {
        timers.Remove(carrier);
        Debug.Log("Cooldown de maná eliminado del jugador al salir del área.");
    }
}
}
