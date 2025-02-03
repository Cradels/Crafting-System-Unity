using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseRecipe", menuName = "Scriptable Objects/BaseRecipe")]
public class BaseRecipe : ScriptableObject
{
    public string _name;
    public Sprite _Image;
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
