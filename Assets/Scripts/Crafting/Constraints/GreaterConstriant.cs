using System;
using Crafting.Recipe;
using Unity.VisualScripting;
using UnityEngine;

public class GreaterConstriant : Constraint
{
    public Func<float> inputValue;
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() > value;
    }
}
