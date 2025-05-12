using UnityEngine;
using UnityEngine.UI;

public class NPCHealthBar : MonoBehaviour {
    public NPCTarget target;
    public Slider slider;
    public Vector3 offset = new Vector3(0, 2.5f, 0); 

    void Update() {
        if (target == null || target.GetCarrier() == null) return;

        var health = target.GetCarrier().GetHealth();
        slider.maxValue = health.GetMaxHealth();
        slider.value = health.GetCurrentHealth();

        transform.position = target.transform.position + offset;
        transform.rotation = Camera.main.transform.rotation;
    }
}