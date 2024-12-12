using System;
using System.Collections.Generic;
using System.Linq;
using Crafting.Recipe;
using UnityEngine;

namespace Crafting
{
    public class CraftingSystem<T>
    {
        private List<Recipe<T>> _recipes;

        public List<Recipe<T>> Recipes => _recipes;

        public void AddRecipe(Recipe<T> recipe)
        {
            _recipes ??= new();

            _recipes.Add(recipe);
        }
        
        public void RemoveRecipe(Recipe<T> recipe)
        {
            _recipes?.Remove(recipe);
        }
        
        /// <summary>
        /// Returns all recipes that fulfill all constraints
        /// </summary>
        public List<Recipe<T>> GetRecipes()
        {
            return _recipes.Where(recipe => recipe.Constraints.All(c => c.IsFullfilled())).ToList();
        }

        /// <summary>
        /// Returns all recipes that can be crafted with the given items and where all constraints are fullfilled
        /// </summary>
        /// <param name="items">List of Item and it's amount</param>
        /// <param name="ignoreConstraints">If true, constraints are ignored</param>
        /// <returns></returns>
        public List<Recipe<T>> GetRecipes(List<InputStack<T>> items, bool ignoreConstraints = false, bool musteBeInCorretOrder = false)
        {
            List<Recipe<T>> craftAbleRecipes = new();
            foreach (Recipe<T> recipe in _recipes)
            {
                // continue if any constraint is not fullfilled and constraints should not be ignored
                if(ignoreConstraints && recipe.Constraints.Any(c => !c.IsFullfilled()))
                    continue;
                
                if (musteBeInCorretOrder? AllItemsAvailablleInCorrectOrder(items, recipe) : AllItemsAvailable(items, recipe))
                {
                    craftAbleRecipes.Add(recipe);
                }
            }

            return craftAbleRecipes;
        }

        private bool AllItemsAvailable(List<InputStack<T>> items, Recipe<T> recipe)
        {
            foreach (InputStack<T> stack in recipe.RequiredItems)
            {
                List<InputStack<T>> allRelevantItemsFromInventory =
                    items.Where(i => i.Item.Equals(stack.Item)).ToList();

                if (allRelevantItemsFromInventory.Count == 0)
                {
                    return false;
                }

                if (allRelevantItemsFromInventory.Any(i => i.Amount < stack.Amount))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AllItemsAvailablleInCorrectOrder(List<InputStack<T>> items, Recipe<T> recipe)
        {
            List<InputStack<T>> recipeItems = recipe.RequiredItems;
            if(items.Count != recipeItems.Count)
            {
                Debug.LogError("'Inventory Items' musst be the same size as 'Recipe Items'");
                return false;
            }
            
            for(int i = 0; i < items.Count; i++)
            {
                // If the items are not the same or the amount is not enough
                if(!items[i].Item.Equals(recipeItems[i].Item) || items[i].Amount < recipeItems[i].Amount)
                {
                    return false;
                }
                
                if (items[i].Amount < recipeItems[i].Amount)
                {
                    //return false;    
                }
            }

            return true;
        }
    }
}