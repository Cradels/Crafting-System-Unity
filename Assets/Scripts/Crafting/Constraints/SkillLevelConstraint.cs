using System;
using Crafting.Recipe;
using UnityEngine;

public class SkillLevelConstraint : Constraint
{
    public Func<int> getCurrentSkillLevel;
    public int requiredLevel;

    public override bool IsFullfilled()
    {
        return getCurrentSkillLevel() >= requiredLevel;
    }
}
