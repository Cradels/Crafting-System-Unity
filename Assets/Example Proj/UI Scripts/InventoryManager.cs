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
    private Dictionary<Recipe<BaseItem>, BaseRecipe> recipeMapping = new Dictionary<Recipe<BaseItem>, BaseRecipe>();


    private void Start(){
        //PopulateInventory();
        PopulateRecepies(possibleRecepies);
    }

    public void PopulateInventory(){
    foreach (BaseItem item in possibleItems)
    {
        GameObject newSlot = Instantiate(ItemPrefab, inventoryUIParent);
        InventorySlot slot = newSlot.GetComponent<InventorySlot>();
        int amount = Random.Range(10, 15);
        slot.SetItem(item, amount);
        
        InputStack<BaseItem> stack = new InputStack<BaseItem>
        {
            Item = item,
            Amount = amount
        };
        inventory.Add(stack);
    }
}


    public void PopulateRecepies(BaseRecipe[] reccipes){
        foreach (BaseRecipe r in reccipes)
        {
            GameObject newSlot = Instantiate(RecipePrefab, recipeUIParent);
            RecipeSlot slot = newSlot.GetComponent<RecipeSlot>();
            slot.SetItem(r);

            Recipe<BaseItem> newRecipe = new Recipe<BaseItem>(r.inputs, r.outputs, r.constraints);
            craftSys.AddRecipe(newRecipe);

            recipeMapping.Add(newRecipe, r);
        }
    }   
    

    public void Filter()
    {
        foreach (Transform child in recipeUIParent)
        {
            Destroy(child.gameObject);
            Debug.Log("CLEARED");
        }

        List<Recipe<BaseItem>> craftableRecipes = craftSys.GetRecipes(inventory);
        print(craftableRecipes);

        foreach (Recipe<BaseItem> recipe in craftSys.Recipes)
        {
            GameObject newSlot = Instantiate(RecipePrefab, recipeUIParent);
            RecipeSlot slot = newSlot.GetComponent<RecipeSlot>();

            // Look up the BaseRecipe for display purposes.
            if (recipeMapping.TryGetValue(recipe, out BaseRecipe baseRecipe))
            {
                slot.SetItem(baseRecipe);
            }
            else
            {
                Debug.LogWarning("No BaseRecipe mapping found for recipe!");
            }

            // Use craftSys.GetRecipes() to check craftability.
            if (craftableRecipes.Contains(recipe))
            {
                slot.Enable();  // The recipe is craftable.
            }
            else
            {
                slot.Disable(); // The recipe is not craftable.
            }
        }

    }
    public void DeleteRandomInventoryItems(int numberOfItems)
    {
        // Remove as many items as requested, or stop if the inventory is empty.
        for (int i = 0; i < numberOfItems && inventory.Count > 0; i++)
        {
            // Pick a random index based on the current inventory count.
            int randomIndex = Random.Range(0, inventory.Count);

            // Remove the inventory data.
            inventory.RemoveAt(randomIndex);

            // Remove the corresponding UI element.
            if (inventoryUIParent.childCount > randomIndex)
            {
                Transform child = inventoryUIParent.GetChild(randomIndex);
                Destroy(child.gameObject);
            }
        }

        Filter();
    }

    public void addRandomItems(int numberOfItems)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            int randomItemIndex = Random.Range(0, possibleItems.Length);
            BaseItem randomItem = possibleItems[randomItemIndex];
            
            int randomAmount = Random.Range(1, 31);

            InputStack<BaseItem> stack = new InputStack<BaseItem>
            {
                Item = randomItem,
                Amount = randomAmount
            };
            inventory.Add(stack);

            GameObject newSlot = Instantiate(ItemPrefab, inventoryUIParent);
            InventorySlot slot = newSlot.GetComponent<InventorySlot>();
            
            slot.SetItem(randomItem, randomAmount);
        }

        Filter();
    }


}
