using UnityEngine;
using UnityEngine.UI;

public class NPCHealthBar : MonoBehaviour {
    public NPCTarget target;
    public Slider slider;
    public Vector3 offset = new Vector3(0, 0.5f, 0); 

    void Update()
    {
    if (target == null || target.GetCarrier() == null) return;

    var health = target.GetCarrier().GetHealth();
    float current = health.GetCurrentHealth();
    float max = health.GetMaxHealth();

        Debug.Log($"NPC Health: {current}/{max}");


    slider.value = current / max;

    transform.position = target.transform.position + offset;
    transform.rotation = Camera.main.transform.rotation;
    }
}