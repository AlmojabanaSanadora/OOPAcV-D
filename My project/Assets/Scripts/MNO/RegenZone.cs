using UnityEngine;

public class RegenZone : MonoBehaviour
{
    [SerializeField] private int regenAmount = 10;
    [SerializeField] private float regenInterval = 1f; 
    private float regenTimer;

    void Start()
    {
        
    }

    void Update()
    {
        regenTimer += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        PlayableCharacter player = other.GetComponent<PlayableCharacter>();
        if (player != null && regenTimer >= regenInterval)
        {
            if (player.IsUsingHealth())
            {
                player.GetCarrier().GetHealth().Heal(regenAmount);
            }
            else
            {
                player.GetCarrier().GetMana().Increase(regenAmount);
            }
            regenTimer = 0f; 
        }
    }
}
