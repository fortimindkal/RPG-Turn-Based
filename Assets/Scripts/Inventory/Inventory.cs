using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public InventoryUI inventoryUI;

    public void AddItem(Item item)
    {
        items.Add(item);
        inventoryUI.UpdateInventoryUI();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        inventoryUI.UpdateInventoryUI();
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }
}