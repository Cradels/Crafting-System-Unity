using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "LesserConstraint", menuName = "Scriptable Objects/Constraints/LesserConstraint")]
public class LesserEqualsConstraint : Constraint
{
    public Func<float> inputValue;
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() <= value;
    }
}

