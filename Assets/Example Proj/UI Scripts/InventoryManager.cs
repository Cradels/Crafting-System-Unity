using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public BaseItem[] possibleItems;
    public BaseRecipe[] possibleRecepies;

    public Transform inventoryUIParent;
    public Transform recipeUIParent;
    public GameObject ItemPrefab;
    public GameObject RecipePrefab;

    // A list to store references to the created inventory slots
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    private void Start()
    {
        PopulateInventory();
        PopulateRecepies();
    }

    public void PopulateInventory()
    {
        foreach (BaseItem item in possibleItems)
        {
            GameObject newSlot = Instantiate(ItemPrefab, inventoryUIParent);
            InventorySlot slot = newSlot.GetComponent<InventorySlot>();
            slot.SetItem(item);
            inventorySlots.Add(slot);
        }
    }

    public void PopulateRecepies()
    {
        foreach (BaseRecipe r in possibleRecepies)
        {
            GameObject newSlot = Instantiate(RecipePrefab, recipeUIParent);
            RecipeSlot slot = newSlot.GetComponent<RecipeSlot>();
            slot.SetItem(r);
        }
    }    
    
}
