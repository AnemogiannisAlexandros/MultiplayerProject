using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHandler : MonoBehaviour
{
    private Item item;
    public UnityEvent OnItemPickUp;
    private Character character;
    private void Awake()
    {
        character = GetComponent<PlayerHandler>().GetCharacter();
    }
    private void AssignItem(Item item) 
    {
        this.item = item;
    }
    public void PickUpItem(Item item) 
    {
        Item.ItemTypes itemType = item.GetItemType();
        Debug.Log(itemType);
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
