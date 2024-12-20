using System;
using Crafting.Recipe;
using UnityEngine;

public class DayNightConstraint : Constraint
{
    public Func<bool> isDayTime;

    public override bool IsFullfilled()
    {
        return isDayTime();
    }
}
