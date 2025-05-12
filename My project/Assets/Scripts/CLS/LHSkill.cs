
using UnityEngine;
public class LHSkill : Skills {
    private GameObject healPrefab;
    private Transform center;

    public LHSkill(string name, float cooldown, GameObject prefab, Transform center)
        : base(name, cooldown) {
        this.healPrefab = prefab;
        this.center = center;
    }

    public override void Use(Carrier user) {
        lastUseTime = Time.time;
        Object.Instantiate(healPrefab, center.position, Quaternion.identity);
    }
}