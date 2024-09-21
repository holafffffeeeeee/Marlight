using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryScript : MonoBehaviour
{

    // A list to hold the items in the inventory
    public List<Item> items = new List<Item>();

    void Start()
    {
        // For testing: Create a food item and add it to the inventory at the start
        Item apple = new Item();
        apple.itemName = "Apple";
        apple.isConsumable = true;
        apple.healAmount = 20f;  // Heals the player by 20 HP

        // Add the apple to the inventory
       
        Item chocolate = new Item();
        chocolate.itemName = "Apple";
        chocolate.isConsumable = true;
        chocolate.healAmount = 500f;  // Heals the player by 20 HP

        // Add the apple to the inventory
        AddItem(apple);
        AddItem(chocolate);
    }

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        items.Add(item);
        items.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory.");
    }

    // Use an item (e.g., food to heal)
    public void UseItem(Item item)
    {
        if (item.isConsumable)
        {
            // Call the PlayerStats script to heal the player
            FindObjectOfType<PlayerStats>().RegenerateHealth(item.healAmount);
            Debug.Log("Used " + item.itemName + ", healed for " + item.healAmount);

            // Remove the item from the inventory after use
            items.Remove(item);
        }
    }
    void Update()
    {
        // Press 'U' to use the first item in the inventory (for testing)
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (items.Count > 0)  // Check if the inventory has items
            {
                UseItem(items[0]);  // Use the first item in the inventory
            }
        }
    }
}

[System.Serializable]
public class Item
{
    public string itemName;        // Name of the item
    public bool isConsumable;      // Is the item consumable (like food)?
    public float healAmount;       // How much it heals, if it's food
}
