using UnityEngine;
using System.Collections.Generic;

public class SkillSystem
{
    private List<Skills> skills = new List<Skills>();

    public void AddSkill(Skills skill) {
        skills.Add(skill);
    }

    public void UseSkill(int index, Carrier user) {
        if (index >= 0 && index < skills.Count && skills[index].CanUse()) {
            skills[index].Use(user);
        }
    }

    public List<Skills> GetSkills() => skills;
}
