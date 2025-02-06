using System.Collections.Generic;
using Crafting.Recipe;
using Crafting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public BaseItem[] possibleItems;
    public BaseRecipe[] possibleRecepies;

    public Transform inventoryUIParent;
    public Transform recipeUIParent;
    public GameObject ItemPrefab;
    public GameObject RecipePrefab;


    private CraftingSystem<BaseItem> craftSys = new CraftingSystem<BaseItem>();
    private List<InputStack<BaseItem>> inventory = new List<InputStack<BaseItem>>();

    private void Start(){
        PopulateInventory();
        PopulateRecepies();
    }

    public void PopulateInventory(){
    foreach (BaseItem item in possibleItems)
    {
        GameObject newSlot = Instantiate(ItemPrefab, inventoryUIParent);
        InventorySlot slot = newSlot.GetComponent<InventorySlot>();
        int amount = Random.Range(1, 31);
        slot.SetItem(item, amount);
        
        InputStack<BaseItem> stack = new InputStack<BaseItem>
        {
            Item = item,
            Amount = amount
        };
        inventory.Add(stack);
    }
}


    public void PopulateRecepies(){
        foreach (BaseRecipe r in possibleRecepies)
        {
            GameObject newSlot = Instantiate(RecipePrefab, recipeUIParent);
            RecipeSlot slot = newSlot.GetComponent<RecipeSlot>();
            slot.SetItem(r);
            craftSys.AddRecipe(new Recipe<BaseItem>(r.inputs, r.outputs, r.constraints));
        }
    }    
    

    private void Filter(){
        
    }
}
