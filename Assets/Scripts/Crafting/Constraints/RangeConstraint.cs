using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeConstraint", menuName = "Scriptable Objects/Constraints/RangeConstraint")]
public class RangeConstraint : Constraint
{
    public Func<float> inputValue;
    public float minValue;
    public float maxValue;

    public override bool IsFullfilled()
    {
        float value = inputValue();
        return value >= minValue && value <= maxValue;
    }
}
