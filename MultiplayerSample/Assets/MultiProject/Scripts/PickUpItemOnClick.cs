using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemOnClick : MonoBehaviour
{
    public IItem PickUpItem() 
    {
        return GetComponent<IItem>();
    }
}
