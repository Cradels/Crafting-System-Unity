using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemName;

    public void SetItem(BaseItem item, int amount)
    {
        if (item != null)
        {
            Debug.Log("Setting item: " + item.ItemName);
            icon.sprite = item.ItemImage;
            icon.enabled = true;
            itemName.text = amount.ToString();
        }
        else
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        itemName.text = "";
    }
}