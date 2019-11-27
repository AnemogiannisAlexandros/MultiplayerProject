using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will be the template of Every Item.
/// </summary>

public class Item : IItem
{

    protected string ItemName;
    protected ItemTypes itemType;
    protected ItemTiers itemTier;

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

    public Item(ItemTiers tier, ItemTypes type, string ItemName) 
    {
        this.itemTier = tier;
        this.itemType = type;
        this.ItemName = ItemName;
    }
}
