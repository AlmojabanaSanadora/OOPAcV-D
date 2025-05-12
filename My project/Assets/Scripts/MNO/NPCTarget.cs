using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class NPCTarget : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private NPCCarrier carrier;
    public NPCCarrier GetCarrier() => carrier;
    public GameObject healthBarPrefab;


    void Start() {
    carrier = new NPCCarrier(maxHealth);

    if (healthBarPrefab != null) {
        GameObject bar = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        bar.GetComponent<NPCHealthBar>().target = this;
    }
}

    void Update()
    {
        if (carrier.GetHealth().GetCurrentHealth() <= 0) {
            carrier.OnDeath();
            Destroy(gameObject);
        }
    }
}
