using System;
using Crafting.Recipe;

public class LesserConstraint : Constraint
{
    public Func<float> inputValue;
    
    public float value;
    public override bool IsFullfilled()
    {
        return inputValue() < value;
    }
}
