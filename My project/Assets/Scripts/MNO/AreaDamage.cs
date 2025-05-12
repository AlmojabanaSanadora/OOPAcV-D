using UnityEngine;
using System.Collections.Generic;

public class AreaDamage : MonoBehaviour {
    public int damagePS = 5;
    private float duration = 5f;
    private Carrier owner;

    private Dictionary<Carrier, float> timers = new Dictionary<Carrier, float>();


    public void SetDamage(int damage) {
        damagePS = damage;
    }
    
    public void SetOwner(Carrier source) {
        owner = source;
    }

    private void Start() {
        Destroy(gameObject, duration); 
    }

    private void OnTriggerStay(Collider other) {
        Carrier target = null;

        var playable = other.GetComponent<PlayableCharacter>();
        if (playable != null) target = playable.GetCarrier();

        var npc = other.GetComponent<NPCTarget>();
        if (npc != null) target = npc.GetCarrier();

        if (target != null && target != owner) {
            if (!timers.ContainsKey(target)) timers[target] = 0f;

            timers[target] += Time.deltaTime;

            if (timers[target] >= 1f) {
                target.TakeDamage(damagePS);
                timers[target] = 0f; 
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        Carrier target = null;

        var playable = other.GetComponent<PlayableCharacter>();
        if (playable != null) {
        target = playable.GetCarrier();
            } else {
                var npc = other.GetComponent<NPCTarget>();
                if (npc != null) {
                target = npc.GetCarrier();
            }
        }
    }
}