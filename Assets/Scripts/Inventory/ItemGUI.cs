using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGUI : MonoBehaviour
{
    public GameObject Item;

    public void onClick()
    {
        if(Item != null) Inventory.Instance.equipItem(Item.GetComponent<Iuseable>().id);
    }
}
