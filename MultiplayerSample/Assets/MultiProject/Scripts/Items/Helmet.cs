using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : Item
{
    public Helmet(ItemTiers tier, ItemTypes type, string ItemName) : base(tier, ItemTypes.Helmet, ItemName) 
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
