using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Weapon(ItemTiers tier, ItemTypes type, string ItemName) : base(tier, ItemTypes.Weapon, ItemName)
    {

    }
}
