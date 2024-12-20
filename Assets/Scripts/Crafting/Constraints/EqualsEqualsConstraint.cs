using System;
using Crafting.Recipe;
using UnityEngine;

public class EqualsEqualsConstraint : Constraint
{
    public Func<float> inputValue;
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() == value;
    }
}
