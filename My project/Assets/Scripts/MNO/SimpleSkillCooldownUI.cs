using UnityEngine;
using UnityEngine.UI;

public class SimpleSkillCooldownUI : MonoBehaviour
{
    public Image[] cooldownOverlays = new Image[3];
    public float[] cooldownDurations = new float[3] { 2f, 2f, 2f };
    private float[] cooldownTimers = new float[3];

    void Start()
    {
        Debug.Log("Cooldown system initialized");

        for (int i = 0; i < cooldownOverlays.Length; i++)
        {
            if (cooldownOverlays[i] != null)
            {
                cooldownOverlays[i].enabled = false;
                Debug.Log($"Overlay {i} initialized and hidden");
            }
            else
            {
                Debug.LogWarning($"Overlay {i} is null");
            }
        }
    }

    void Update()
    {
        // Check timers and turn off overlays
        for (int i = 0; i < cooldownTimers.Length; i++)
        {
            if (cooldownTimers[i] > 0f)
            {
                cooldownTimers[i] -= Time.deltaTime;
                Debug.Log($"Cooldown {i} ticking: {cooldownTimers[i]:0.00}s left");

                if (cooldownTimers[i] <= 0f && cooldownOverlays[i] != null)
                {
                    cooldownOverlays[i].enabled = false;
                    Debug.Log($"Cooldown {i} ended — overlay hidden");
                }
            }
        }

        // Key input debug
        if (Input.GetKeyDown(KeyCode.Alpha1)) { Debug.Log("Pressed 1"); TriggerCooldown(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { Debug.Log("Pressed 2"); TriggerCooldown(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { Debug.Log("Pressed 3"); TriggerCooldown(2); }
    }

    public void TriggerCooldown(int index)
    {
        if (index < 0 || index >= cooldownTimers.Length)
        {
            Debug.LogWarning($"Invalid cooldown index: {index}");
            return;
        }

        cooldownTimers[index] = cooldownDurations[index];
        Debug.Log($"Cooldown {index} triggered for {cooldownDurations[index]}s");

        if (cooldownOverlays[index] != null)
        {
            cooldownOverlays[index].enabled = true;
            Debug.Log($"Overlay {index} shown");
        }
        else
        {
            Debug.LogWarning($"Overlay {index} is null");
        }
    }
}
