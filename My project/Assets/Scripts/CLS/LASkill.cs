using UnityEngine;

public class LASkill : Skills
{
    private float radius;
    private int damage;
    private Transform center;

    public LASkill(string name, Sprite icon, float cooldown, float radius, int damage, Transform center)
        : base(name, icon, cooldown) {
        this.radius = radius;
        this.damage = damage;
        this.center = center;
    }

    public override void Use(Carrier user) {
        lastUseTime = Time.time;

        Collider[] hits = Physics.OverlapSphere(center.position, radius);
        foreach (var hit in hits) {
            Carrier target = hit.GetComponent<Carrier>();
            if (target != null && target != user) {
                target.TakeDamage(damage);
            }
        }
    }
}

