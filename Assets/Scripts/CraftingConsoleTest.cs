using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Crafting;
using Crafting.Recipe;
using Sirenix.OdinInspector;

public class CraftingConsoleTest : MonoBehaviour
{
    private CraftingSystem<string> _craftingSystem;

    public CraftingSystem<string> CraftingSystem
    {
        get { return _craftingSystem ??= new CraftingSystem<string>(); }
    }


    [Button]
    public void AddRecipe(List<InputStack<string>> inputItems, List<OutputStack<string>> outputItems)
    {
        InputStack<string>[] input = new InputStack<string>[inputItems.Count];
        inputItems.CopyTo(input);
        
        OutputStack<string>[] output = new OutputStack<string>[outputItems.Count];
        outputItems.CopyTo(output);
        
        Recipe<string> recipe = new Recipe<string>(
            input.ToList(),
            output.ToList(),
            new List<Constraint>()
            );
        CraftingSystem.AddRecipe(recipe);
        Debug.Log("Added Recipe:s");
        PrintRecipe(recipe);
        Debug.Log("====================================");
    }

    [Button]
    public void GetAllRecipes()
    {
        Debug.Log("All Recipes: ");
        foreach (Recipe<string> recipe in CraftingSystem.Recipes)
        {
            PrintRecipe(recipe);
        }
        Debug.Log("====================================");
    }

    private void PrintRecipe(Recipe<string> recipe)
    {
        string log = "<== Recipe ==> \n";
        log += "Click to See Recipe Details \n";
        log+="InputItems: \n";
        foreach (InputStack<string> inputItem in recipe.RequiredItems)
        {
            log+= $"Item {inputItem.Item.ToString()}, Amount: {inputItem.Amount} \n";
        }
        log += "\n OutputItems: \n";
        foreach (OutputStack<string> outputItem in recipe.OutputStacks)
        {
            log+= $"Item {outputItem.Item.ToString()}, Amount: {outputItem.Amount}, Skikllvalue: {outputItem.SkillValue} \n";
        }
        Debug.Log(log);
    }

    [Button]
    public void GetAllRecipes(List<InputStack<string>> inventory)
    {
        List<Recipe<string>> recepies =  _craftingSystem.GetRecipes(inventory, true, true);
        foreach (Recipe<string> recipe in recepies)
        {
            PrintRecipe(recipe);
        }
        
    }
}
