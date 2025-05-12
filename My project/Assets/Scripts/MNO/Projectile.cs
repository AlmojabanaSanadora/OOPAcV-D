using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private float speed;
    private Carrier source;

    public void Initialize(int damage, float speed, Carrier source) {
        this.damage = damage;
        this.speed = speed;
        this.source = source;
        Destroy(gameObject, 3.5f); 
    }

    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
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

    if (target != null && target != source) {
        target.TakeDamage(damage);
        Destroy(gameObject);
    }
}
}
