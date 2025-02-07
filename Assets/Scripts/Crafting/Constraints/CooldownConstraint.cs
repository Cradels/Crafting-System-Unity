using Crafting.Recipe;
using UnityEngine;

[CreateAssetMenu(fileName = "Constraint", menuName = "Scriptable Objects/Constraints/CooldownConstraint")]
public class CooldownConstraint : Constraint
{
    public float cooldownTime;
    public float lastActionTime;

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
