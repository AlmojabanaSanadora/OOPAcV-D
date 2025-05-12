using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxMana = 100;

    private MagoAcuatico agent1;
    private MagoSelvatico agent2;
    private PlayableCarrier carrier;
    private bool usingHealth;

    public MagoAcuatico GetAgent1() => agent1;
    public MagoSelvatico GetAgent2() => agent2;

    void Start()
    {
        agent1 = new MagoAcuatico(maxHealth, maxMana);
        agent2 = new MagoSelvatico(maxHealth, maxMana);
        carrier = agent2;
        usingHealth = false;
    }

    void Update() {
    if (Input.GetKeyDown(KeyCode.H)) {
        usingHealth = !usingHealth;
        carrier = usingHealth ? agent1 : agent2;
    }

    if (carrier.GetHealth().GetCurrentHealth() <= 0 ||
        carrier.GetMana().GetCurrentMana() <= 0) {
        Destroy(gameObject);
        return;
    }

    if (Input.GetKeyDown(KeyCode.Alpha1)) carrier.UseSkill(0);
    if (Input.GetKeyDown(KeyCode.Alpha2)) carrier.UseSkill(1);
    if (Input.GetKeyDown(KeyCode.Alpha3)) carrier.UseSkill(2);
}

    public PlayableCarrier GetCarrier() => carrier;
    public bool IsUsingHealth() => usingHealth;
    
}


