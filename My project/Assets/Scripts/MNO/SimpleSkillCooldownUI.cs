using UnityEngine;
using UnityEngine.UI;

public class SimpleSkillCooldownUI : MonoBehaviour
{
    public Image[] cooldownOverlays = new Image[3];
    public float[] cooldownDurations = new float[3] { 2f, 2f, 2f };
    private float[] cooldownTimers = new float[3];

    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.Alpha1)) { Debug.Log("Pressed 1"); TriggerCooldown(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { Debug.Log("Pressed 2"); TriggerCooldown(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { Debug.Log("Pressed 3"); TriggerCooldown(2); }
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
        else
        {
            Debug.LogWarning($"Overlay {index} is null");
        }
    }
}
