using System.Collections.Generic;
using JetBrains.Annotations;

namespace Crafting.Recipe
{
    public class Recipe<T>
    {
        public readonly List<InputStack<T>> RequiredItems;
        public readonly List<OutputStack<T>> OutputStacks;

        public List<Constraint> Constraints;
        
        public Recipe(List<InputStack<T>> requiredItems, List<OutputStack<T>> outputStacks, List<Constraint> constraints)
        {
            RequiredItems = requiredItems;
            OutputStacks = outputStacks;
            Constraints = constraints;
        }
    }
}