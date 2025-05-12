using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class NPCTarget : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private NPCCarrier carrier;
    public NPCCarrier GetCarrier() => carrier;
    public GameObject healthBarPrefab;

    private GameObject healthBarInstance;


    void Start() {
    carrier = new NPCCarrier(maxHealth);

    if (healthBarPrefab != null) {
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        healthBarInstance.GetComponent<NPCHealthBar>().target = this;
    }
}

    void Update()
    {
        if (carrier.GetHealth().GetCurrentHealth() <= 0) {
            carrier.OnDeath();
            if (healthBarInstance != null) {
                Destroy(healthBarInstance);
            }
            Destroy(gameObject);
        }
    }
}
