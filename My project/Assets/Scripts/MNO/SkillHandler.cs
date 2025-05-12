using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SkillHandler : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject healZonePrefab;
    public GameObject explosionPrefab;
    public Transform firePoint;
    public Transform InsPoint;

        void Start() {
            StartCoroutine(AssignSkills());
        }

        IEnumerator AssignSkills() {
            
            PlayableCharacter character = null;

            int attempts = 0;
            while (attempts < 10) {
            character = GetComponent<PlayableCharacter>();
            if (character != null && character.GetCarrier() != null) break;
            attempts++;
            yield return null;
        }

            if (character == null) {
            yield break;
        }

            if (healZonePrefab == null || explosionPrefab == null || projectilePrefab == null) {
                yield break;
            }

        var agent1 = character.GetAgent1();
        var agent2 = character.GetAgent2();

            AssignSkillsTC(agent1);
            AssignSkillsTC(agent2);

        void AssignSkillsTC(PlayableCarrier carrier) {
            carrier.GetSkillSystem().AddSkill(new LHSkill("Curar", null, 2f, healZonePrefab, InsPoint));

            carrier.GetSkillSystem().AddSkill(new LASkill("Explosión", null, 2f, explosionPrefab, InsPoint, 5));

            carrier.GetSkillSystem().AddSkill(new LPSkill("Disparo", null, 2f, 15, 10f, projectilePrefab, firePoint));
        }

    }
}

