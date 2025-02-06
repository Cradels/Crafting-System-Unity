using UnityEngine;

[CreateAssetMenu(fileName = "BaseItem", menuName = "Scriptable Objects/BaseItem")]
public class BaseItem : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
}
