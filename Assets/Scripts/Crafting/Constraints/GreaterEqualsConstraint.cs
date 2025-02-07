using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "GreaterEqualsConstraint", menuName = "Scriptable Objects/Constraints/GreaterEqualsConstraint")]
public class GreaterEqualsConstraint : Constraint
{
    public Func<float> inputValue;
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() >= value;
    }
}
