using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolConstraint", menuName = "Scriptable Objects/Constraints/BoolConstraint")]
public class BoolConstraint : Constraint
{
    [SerializeField] private bool condition;

    public bool Condition
    {
        get => condition;
        set => condition = value;
    }

    public override bool IsFullfilled()
    {
        return condition;
    }
    
    public void SetCondition(bool newCondition)
    {
        condition = newCondition;
        Debug.Log("Condition set to " + condition);
    }
}
