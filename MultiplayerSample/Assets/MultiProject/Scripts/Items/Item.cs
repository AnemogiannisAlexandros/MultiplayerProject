using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will be the template of Every Item.
/// </summary>

public class Item : ScriptableObject,IItem
{



    [SerializeField]protected string ItemName;
    [SerializeField] protected ItemTypes itemType;
    [SerializeField] protected ItemTiers itemTier;

    public enum ItemTiers
    {
        None,
        Common,
        Rare,
        Epic,
        Legendary
    }

    public enum ItemTypes
    {
        Helmet,
        Armor,
        Weapon
    }

    public Item() 
    {
    }

    public Item(ItemTiers tier, ItemTypes type, string ItemName) 
    {
        this.itemTier = tier;
        this.itemType = type;
        this.ItemName = ItemName;
    }
    public virtual void Init(ItemTiers tier,string ItemName) 
    {
        this.itemTier = tier;
        this.ItemName = ItemName;
    }
    public ItemTiers GetItemTier()
    {
        return itemTier;
    }

    public ItemTypes GetItemType()
    {
        return itemType;
    }

    public string GetItemName()
    {
        return ItemName;
    }

    public void SetItemTier(ItemTiers tier)
    {
        itemTier = tier;
    }

    public void SetItemType(ItemTypes type)
    {
        itemType = type;
    }

    public void SetName(string newName)
    {
        ItemName = newName;
    }
}
