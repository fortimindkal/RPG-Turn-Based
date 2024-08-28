using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public ItemType type;

    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        Miscellaneous
    }
}