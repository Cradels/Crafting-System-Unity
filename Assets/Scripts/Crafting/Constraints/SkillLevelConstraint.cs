using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillLevelConstraint", menuName = "Scriptable Objects/Constraints/SkillLevelConstraint")]
public class SkillLevelConstraint : Constraint
{
    public Func<int> getCurrentSkillLevel;
    public int requiredLevel;

    public override bool IsFullfilled()
    {
        return getCurrentSkillLevel() >= requiredLevel;
    }
}
