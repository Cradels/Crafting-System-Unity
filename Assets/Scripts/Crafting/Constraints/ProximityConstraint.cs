using System;
using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "ProximityConstraint", menuName = "Scriptable Objects/Constraints/ProximityConstraint")]
public class ProximityConstraint : Constraint
{
    public Func<Vector3> getPlayerPosition;
    public Vector3 targetPosition;
    public float requiredDistance;

    public override bool IsFullfilled()
    {
        return Vector3.Distance(getPlayerPosition(), targetPosition) <= requiredDistance;
    }
}
