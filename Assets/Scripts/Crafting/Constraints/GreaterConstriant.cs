using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "GreaterConstriant", menuName = "Scriptable Objects/Constraints/GreaterConstriant")]
public class GreaterConstriant : Constraint
{
    public Func<float> inputValue;
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() > value;
    }
}
