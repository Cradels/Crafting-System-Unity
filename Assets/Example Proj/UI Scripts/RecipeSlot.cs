using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemName;

    public void SetItem(BaseRecipe recipe)
    {
        if (recipe != null)
        {
            icon.sprite = recipe.RecipeImage;
            icon.enabled = true;
            itemName.text = recipe.RecipeName;
        }
        else
        {
            ClearRecipeSlot();
        }
    }
    public void ClearRecipeSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        itemName.text = "";
    }

    public void Disable()
    {
        icon.color = Color.red;
        itemName.color = Color.red;
    }


    public void Enable()
    {
        icon.color = Color.white;
        itemName.color = Color.white;
    }
}