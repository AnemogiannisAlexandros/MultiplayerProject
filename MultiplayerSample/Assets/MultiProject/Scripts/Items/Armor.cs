using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public Armor(ItemTiers tier, ItemTypes type, string ItemName) : base(tier, ItemTypes.Armor, ItemName) 
    {

    }
    public ItemTypes GetType()
    {
        return itemType;
    }
    public ItemTiers GetTier()
    {
        return itemTier;
    }
    public string GetItemName()
    {
        return ItemName;
    }
}
