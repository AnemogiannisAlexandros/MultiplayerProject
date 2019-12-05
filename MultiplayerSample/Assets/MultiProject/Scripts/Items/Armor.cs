using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor",menuName ="Items/Armor",order =0)]

public class Armor : Item
{
    public ItemTiers tier;
    public string itmeName;
    public Item.ItemTypes itemType;
    public Armor(ItemTiers tier, ItemTypes type, string ItemName) : base(tier, ItemTypes.Armor, ItemName) 
    {
        itemType = ItemTypes.Armor;
    }
    [SerializeField]
    [Range(0, 100)]
    protected float headshotDamageReductionPercent;

    public float GetReductionPercent() 
    {
        return headshotDamageReductionPercent;
    }
    public void SetReductionPercent(float amount) 
    {
        headshotDamageReductionPercent = amount;
    }
}
