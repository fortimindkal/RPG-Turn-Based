using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemContainer;
    public GameObject itemPrefab;
    public Button sortButton; // Add Button UI element for sorting

    private List<GameObject> itemObjects = new List<GameObject>();
    private bool isSorted = false; // Flag to track sorting state

    void Start()
    {
        UpdateInventoryUI();
        inventory.inventoryUI = this;

        // Initialize sortButton
        sortButton.onClick.AddListener(SortItems);
    }

    public void UpdateInventoryUI()
    {
        foreach (GameObject itemObject in itemObjects)
        {
            Destroy(itemObject);
        }

        itemObjects.Clear();

        // Sort items based on sorting state
        List<Item> sortedItems = isSorted ? SortItemsByType(inventory.items) : inventory.items;

        foreach (Item item in sortedItems)
        {
            GameObject itemObject = Instantiate(itemPrefab, itemContainer);
            Image iconImage = itemObject.transform.Find("Icon").GetComponent<Image>();
            Button removeButton = itemObject.transform.Find("RemoveButton").GetComponent<Button>();
            if (iconImage != null)
            {
                iconImage.sprite = item.icon;
            }
            removeButton.onClick.AddListener(() => inventory.RemoveItem(item));
            itemObjects.Add(itemObject);
        }
    }

    // Sort items by type
    List<Item> SortItemsByType(List<Item> items)
    {
        return items.OrderBy(x => x.type).ThenBy(x => x.name).ToList();
    }

    // Toggle sorting state and update inventory UI
    void SortItems()
    {
        isSorted = !isSorted;
        UpdateInventoryUI();
    }
}