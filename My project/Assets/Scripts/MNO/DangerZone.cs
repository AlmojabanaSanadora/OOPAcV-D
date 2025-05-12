using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float damageInterval = 1f; // Time in seconds between damage ticks
    private float damageTimer;

    void Update()
    {
        damageTimer += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        PlayableCharacter player = other.GetComponent<PlayableCharacter>();
        if (player != null && damageTimer >= damageInterval)
        {
            if (player.IsUsingHealth())
            {
                player.GetCarrier().GetHealth().TakeDamage(damageAmount);
            }
            else
            {
                player.GetCarrier().GetMana().Decrease(damageAmount);
            }
            damageTimer = 0f; // Reset the timer after applying damage
        }
    }
}
