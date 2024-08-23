using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IInputRecieve
{
    void OnEnable()
    {
        InputBroadcaster.pressedDrop += handleDrop;
    }

    void OnDisable()
    {
        InputBroadcaster.pressedDrop -= handleDrop;
    }

    void drop()
    {
        if(Inventory.Instance.currentEquipedItem != null)
        {
            Console.Instance.Log("Dropped Object " + Inventory.Instance.currentEquipedItem.Name);
            Inventory.Instance.removeItem(Inventory.Instance.currentEquipedItem.id);
        }
    }

    public void handleDrop(bool status)
    {
        if(status) drop();
    }
}
