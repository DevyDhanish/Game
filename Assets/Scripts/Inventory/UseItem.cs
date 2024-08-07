using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour, IInputRecieve
{
    void OnEnable()
    {
        InputBroadcaster.pressedUtility += handleUtility;
    }

    void OnDisable()
    {
        InputBroadcaster.pressedUtility -= handleUtility;
    }

    private void use()
    {
        if(Inventory.Instance.currentEquipedItem != null) Inventory.Instance.currentEquipedItem.use();
    }

    public void handleInput(InputStruct inputStruct)
    {

    }

    public void handleInteract(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleDrop(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleInventory(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleUtility(bool status)
    {
        if(status) use();   // if the button has been pressed
    }
}
