using UnityEngine;

public class ItemDetails : MonoBehaviour
{
    public string Name { get; }
    public ItemDetails(string name)
    {
        Name = name;
    }

}
