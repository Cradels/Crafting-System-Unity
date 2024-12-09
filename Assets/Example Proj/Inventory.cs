using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


//temp
public class Item
{
    public string name { get; private set; } // The name property

    // Constructor to initialize the name
    public Item(string itemName)
    {
        name = itemName;
    }
}

public class Wood : Item
{
    public Wood() : base("Wood") { }
}

public class Stone : Item
{
    public Stone() : base("Stone") { }
}

public class Steel : Item
{
    public Steel() : base("Steel") { }
}





public class Inventory : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI Wood;
    [SerializeField] private TextMeshProUGUI Stone;
    [SerializeField] private TextMeshProUGUI Steel;

    private List<Item> myInventory = new List<Item>{};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button();
        Wood.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateItems()
    {
        string output = "";
        foreach(Item item in myInventory){
            output += item.name;
            output += "\n";
        }

       Wood.text = output;
    }

    void addItem (Item newItem, int amount)
    {
        for(int i = 0; i <= amount; i++)
        {
            myInventory.Add(newItem);
        }
        updateItems();
    }

    public void Button(){
        addRandomItem();
        addRandomItem();
        addRandomItem();

    }

    void addRandomItem()
    {
        int RandomItem = Random.Range(0,3);
        int RandomAmount = Random.Range(0,4);

        switch(RandomItem)
        {
            case 0:
                print("Wood");
                addItem(new Wood(), RandomAmount);
                break;
            case 1:
                print("Stone");
                addItem(new Stone(), RandomAmount);
                break;
            case 2:
                print("Steel");
                addItem(new Steel(), RandomAmount);
                break;

            default:
                print("default");
                break;
        };
    }
}
