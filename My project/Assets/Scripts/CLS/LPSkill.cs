using UnityEngine;
using UnityEngine.Pool;

public class LPSkill : Skills 
{
    private GameObject projectilePrefab;
    private Transform firePoint;
    private int damage;
    private float speed;

    public LPSkill(string name, Sprite icon, float cooldown, int damage, float speed, GameObject projectilePrefab, Transform firePoint)
        : base(name, icon, cooldown) {
        this.damage = damage;
        this.speed = speed;
        this.projectilePrefab = projectilePrefab;
        this.firePoint = firePoint;
    }

    public override void Use(Carrier user) {
        lastUseTime = Time.time;

        GameObject instance = Object.Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = instance.GetComponent<Projectile>();
        projectile.Initialize(damage, speed, user);
    }
}
