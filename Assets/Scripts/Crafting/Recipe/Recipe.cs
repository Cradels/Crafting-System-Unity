using System.Collections.Generic;

namespace Crafting.Recipe
{
    public class Recipe<T>
    {
        public List<InputStack<T>> InputStacks;
        public List<OutputStack<T>> OutputStacks;

        public List<Constraint> Constraints;
        
        public Recipe(List<InputStack<T>> inputStacks, List<OutputStack<T>> outputStacks, List<Constraint> constraints)
        {
            InputStacks = inputStacks;
            OutputStacks = outputStacks;
            Constraints = constraints;
        }
    }
}