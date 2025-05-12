using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public PlayableCharacter character;
    public Slider healthBar;
    public Slider manaBar;

    void Update() {
        var carrier = character.GetCarrier();
        var health = carrier.GetHealth();
        var mana = carrier.GetMana();

        bool usingHealth = character.IsUsingHealth();

        // Actualizar valores reales
        healthBar.maxValue = health.GetMaxHealth();
        healthBar.value = health.GetCurrentHealth();

        manaBar.maxValue = mana.GetMaxMana();
        manaBar.value = mana.GetCurrentMana();

        // Mostrar solo la barra relevante
        healthBar.gameObject.SetActive(usingHealth);
        manaBar.gameObject.SetActive(!usingHealth);
    }
}
