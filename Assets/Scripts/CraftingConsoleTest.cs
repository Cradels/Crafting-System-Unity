using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Crafting;
using Crafting.Recipe;
using Sirenix.OdinInspector;

public class CraftingConsoleTest : MonoBehaviour
{
    private CraftingSystem<BaseItem> _craftingSystem;

    public CraftingSystem<BaseItem> CraftingSystem
    {
        get { return _craftingSystem ??= new CraftingSystem<BaseItem>(); }
    }


    [Button]
    public void AddRecipe(List<InputStack<BaseItem>> inputItems, List<OutputStack<BaseItem>> outputItems)
    {
        InputStack<BaseItem>[] input = new InputStack<BaseItem>[inputItems.Count];
        inputItems.CopyTo(input);
        
        OutputStack<BaseItem>[] output = new OutputStack<BaseItem>[outputItems.Count];
        outputItems.CopyTo(output);
        
        Recipe<BaseItem> recipe = new Recipe<BaseItem>(
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
        foreach (Recipe<BaseItem> recipe in CraftingSystem.Recipes)
        {
            PrintRecipe(recipe);
        }
        Debug.Log("====================================");
    }

    private void PrintRecipe(Recipe<BaseItem> recipe)
    {
        string log = "<== Recipe ==> \n";
        log += "Click to See Recipe Details \n";
        log+="InputItems: \n";
        foreach (InputStack<BaseItem> inputItem in recipe.RequiredItems)
        {
            log+= $"Item {inputItem.Item.ToString()}, Amount: {inputItem.Amount} \n";
        }
        log += "\n OutputItems: \n";
        foreach (OutputStack<BaseItem> outputItem in recipe.OutputStacks)
        {
            log+= $"Item {outputItem.Item.ToString()}, Amount: {outputItem.Amount}, Skikllvalue: {outputItem.SkillValue} \n";
        }
        Debug.Log(log);
    }

    [Button]
    public void GetAllRecipes(List<InputStack<BaseItem>> inventory)
    {
        List<Recipe<BaseItem>> recepies =  _craftingSystem.GetRecipes(inventory, true, true);
        foreach (Recipe<BaseItem> recipe in recepies)
        {
            PrintRecipe(recipe);
        }
        
    }
}
