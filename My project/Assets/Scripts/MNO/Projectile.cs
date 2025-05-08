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
        Carrier target = other.GetComponent<Carrier>();
        if (target != null && target != source) {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
