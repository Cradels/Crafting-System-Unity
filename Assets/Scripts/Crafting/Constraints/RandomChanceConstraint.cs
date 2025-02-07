using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomChanceConstraint", menuName = "Scriptable Objects/Constraints/RandomChanceConstraint")]
public class RandomChanceConstraint : Constraint
{
    private readonly float successChance; // Value between 0 and 1

    public RandomChanceConstraint(float successChance)
    {
        this.successChance = successChance;
    }

    public override bool IsFullfilled()
    {
        return UnityEngine.Random.value <= successChance;
    }
}
