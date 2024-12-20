using Crafting.Recipe;
using UnityEngine;

public class NotConstraint : Constraint
{
    private readonly Constraint _constraint;

    public NotConstraint(Constraint constraint)
    {
        _constraint = constraint;
    }

    public override bool IsFullfilled()
    {
        return !_constraint.IsFullfilled();
    }
}
