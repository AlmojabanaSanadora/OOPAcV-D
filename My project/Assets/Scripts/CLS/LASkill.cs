using UnityEngine;

public class LASkill : Skills
{
    private int damage;
    private Transform center;
    private GameObject explosionPrefab;

    public LASkill(string name, float cooldown, GameObject prefab, Transform center, int damage)
        : base(name, cooldown) {
        this.explosionPrefab = prefab;
        this.damage = damage;
        this.center = center;
    }

    public override void Use(Carrier user) {
        lastUseTime = Time.time;

        GameObject instance = Object.Instantiate(explosionPrefab, center.position, Quaternion.identity);
        AreaDamage area = instance.GetComponent<AreaDamage>();

        if (area != null) {
            area.SetOwner(user);
            area.SetDamage(damage);
        }
    }
}

