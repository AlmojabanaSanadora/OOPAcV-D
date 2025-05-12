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
                if (cooldownTimers[i] <= 0f && cooldownOverlays[i] != null)
                {
                    cooldownOverlays[i].enabled = false;
                }
            }
        }
    }

    public void TriggerCooldown(int index)
    {
        if (index < 0 || index >= cooldownTimers.Length)
        {
            return;
        }

        cooldownTimers[index] = cooldownDurations[index];
        if (cooldownOverlays[index] != null)
        {
            cooldownOverlays[index].enabled = true;
        }
    }
}
