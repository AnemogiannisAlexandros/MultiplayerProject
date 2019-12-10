using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHandler : MonoBehaviour
{
    public UnityEvent OnItemPickUp;
    private Character character;
    private void Awake()
    {
        character = GetComponent<PlayerHandler>().GetCharacter();
    }
    public void PickUpItem(Item item) 
    {
        Item.ItemTypes itemType = item.GetItemType();
        switch (itemType)
        {
            case Item.ItemTypes.Armor:
                character.SetArmor((Armor)item);
                break;
            case Item.ItemTypes.Helmet:
                character.SetHelmet((Helmet)item);
                break;
            case Item.ItemTypes.Weapon:
                character.SetWeapon((Weapon)item);
                break;
        }
        OnItemPickUp.Invoke();
    }

}
