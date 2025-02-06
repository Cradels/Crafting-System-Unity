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

    public BaseItem _inputItem1;
    public int _inputAmount1;
    public BaseItem _inputItem2;
    public int _inputAmount2;
    public BaseItem _inputItem3;
    public int _inputAmount3;
    public BaseItem _inputItem4;
    public int _inputAmount4;
    public BaseItem _inputItem5;
    public int _inputAmount5;
    public BaseItem _outputItem1;
    public int _outputAmount1;
    public int _skillValue1;
    public BaseItem _outputItem2;
    public int _outputAmount2;
    public int _skillValue2;
}
