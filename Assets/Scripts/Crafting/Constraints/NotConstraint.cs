using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "NotConstraint", menuName = "Scriptable Objects/Constraints/NotConstraint")]
public class NotConstraint : Constraint
{
    public Constraint _constraint;

    public NotConstraint(Constraint constraint)
    {
        _constraint = constraint;
    }

    public override bool IsFullfilled()
    {
        return !_constraint.IsFullfilled();
    }
}
