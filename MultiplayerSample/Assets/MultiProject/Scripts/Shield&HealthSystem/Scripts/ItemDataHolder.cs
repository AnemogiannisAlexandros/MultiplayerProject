using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataHolder : MonoBehaviour
{
    [Tooltip("Place here any Created Scriptable object that inherits from the Class : Item")]
    public Item thisItemData;

    //Passes implementation over to The ItemHandler Class with given Item
    public void PickUp() 
    {
        FindObjectOfType<ItemHandler>().PickUpItem(thisItemData);
    }
}
