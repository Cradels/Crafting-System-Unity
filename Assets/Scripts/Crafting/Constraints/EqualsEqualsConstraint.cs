using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "EqualsEqualsConstraint", menuName = "Scriptable Objects/Constraints/EqualsEqualsConstraint", order = 1)]
public class EqualsEqualsConstraint : Constraint
{
    public Func<float> inputValue;
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() == value;
    }
}
