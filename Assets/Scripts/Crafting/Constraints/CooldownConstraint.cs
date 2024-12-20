using Crafting.Recipe;
using UnityEngine;

public class CooldownConstraint : Constraint
{
    private readonly float cooldownTime;
    private float lastActionTime;

    public CooldownConstraint(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
        lastActionTime = Time.time;
    }

    public override bool IsFullfilled()
    {
        return Time.time - lastActionTime >= cooldownTime;
    }

    public void ResetCooldown()
    {
        lastActionTime = Time.time;
    }
}
