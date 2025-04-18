using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum ItemType{
    Potion,
    Health,
    Gem
}

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemType, int> inventoryItems;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryItems = new Dictionary<ItemType, int>();
    }
    
    public void AddToInventory(ItemType item, int count)
    {
        if (inventoryItems.ContainsKey(item))
        {
            inventoryItems[item] += count;
        }
        else
        {
            inventoryItems.Add(item, count);
        }

        DisplayInventory();
    }

    private void DisplayInventory()
    {
        foreach (var item in inventoryItems)
        {
            // update the ui
            Debug.Log($"{item.Key}, {item.Value}");
        }
    }
}
