using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField]
    private ItemDetails itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;


    List<ItemDetails> listOfUIItems = new List<ItemDetails>();


    public void InitializeInventoryUI(int size)
    {
        for(int i = 0; i < size; i++)
        {
            ItemDetails uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
        }
    }
    
    public void addItem(ItemDetails newItem)
    {
        listOfUIItems.Add(newItem);
    }
}

