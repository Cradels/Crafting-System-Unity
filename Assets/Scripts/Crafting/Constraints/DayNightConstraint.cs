using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "DayNightConstraint", menuName = "Scriptable Objects/Constraints/DayNightConstraint")]
public class DayNightConstraint : Constraint
{
    public Func<bool> isDayTime;

    public override bool IsFullfilled()
    {
        return isDayTime();
    }
}
