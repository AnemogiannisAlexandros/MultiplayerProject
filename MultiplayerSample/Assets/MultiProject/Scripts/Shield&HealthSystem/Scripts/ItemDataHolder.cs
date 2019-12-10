using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataHolder : MonoBehaviour
{
    public Item thisItemData;

    public void PickUp() 
    {

        FindObjectOfType<ItemHandler>().PickUpItem(thisItemData);
    }
}
