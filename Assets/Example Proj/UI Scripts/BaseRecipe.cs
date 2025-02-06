using NUnit.Framework;
using UnityEngine;
using Crafting;
using Crafting.Recipe;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "BaseRecipe", menuName = "Scriptable Objects/BaseRecipe")]
public class BaseRecipe : ScriptableObject
{
    public string RecipeName;
    public Sprite RecipeImage;

    public List<InputStack<BaseItem>> inputs;
    public List<OutputStack<BaseItem>> outputs;
    public List<
}
