using UnityEngine;

public class DamageZone : MonoBehaviour {
    public int damage = 10;

    private void OnTriggerEnter(Collider other) {
        Carrier carrier = null;

        var playable = other.GetComponent<PlayableCharacter>();
        if (playable != null) {
            carrier = playable.GetCarrier();
        } else {
            var npc = other.GetComponent<NPCTarget>();
            if (npc != null) {
                carrier = npc.GetCarrier();
            }
        }

        if (carrier != null) {
            carrier.TakeDamage(damage);
        }
    }
}