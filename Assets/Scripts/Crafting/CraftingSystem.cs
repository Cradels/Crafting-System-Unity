using System.Collections.Generic;
using System.Linq;
using Crafting.Recipe;

namespace Crafting
{
    public class CraftingSystem<T>
    {
        private List<Recipe<T>> _recipes;

        public List<Recipe<T>> Recipes
        {
            get => _recipes;
            private set => _recipes = value;
        }

        public void AddRecipe(Recipe<T> recipe)
        {
            _recipes ??= new();

            _recipes.Add(recipe);
        }

        // All recipes that have all constraints fullfilled
        public List<Recipe<T>> GetRecipes()
        {
            return _recipes.Where(r => r.Constraints.All(c => c.IsFullfilled())).ToList();
        }

        // All recipes that can be crafted with List<T, int> -> T: Item, int: Amount
        public List<Recipe<T>> GetRecipes(List<(T, int)> items)
        {
            List<Recipe<T>> craftAbleRecipes = new();
            foreach (Recipe<T> r in _recipes)
            {
                // continue if any constraint is not fullfilled
                if(r.Constraints.Any(c => !c.IsFullfilled()))
                    continue;
                
                bool canAddRecipe = true;
                foreach (InputStack<T> stack in r.InputStacks)
                {
                    List<(T, int)> allRelevantItemsFromInventory =
                        items.Where(i => i.Item1.Equals(stack.Item)).ToList();

                    if (allRelevantItemsFromInventory.Any(i => i.Item2 < stack.Amount))
                    {
                        canAddRecipe = false;
                    }
                }

                if (canAddRecipe)
                {
                    craftAbleRecipes.Add(r);
                }
            }

            return craftAbleRecipes;
        }
    }
}