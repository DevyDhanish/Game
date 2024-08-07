using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour, IInputRecieve
{
    public float maxDistance;
    public LayerMask pickableLayer;

    void OnEnable()
    {
        InputBroadcaster.pressedDrop += handleDrop;
        InputBroadcaster.pressedInteract += handleInteract;
    }

    void OnDisable()
    {
        InputBroadcaster.pressedDrop -= handleDrop;
        InputBroadcaster.pressedInteract -= handleInteract;
    }

    void pickUp()
    {
        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, pickableLayer);

        if(hit.transform)
        {
            if(hit.transform.GetComponent<Iuseable>() != null)
                Inventory.Instance.addItem(hit.transform.gameObject);
            //Debug.Log(hit.transform.name);
        }
    }

    void drop()
    {
        if(Inventory.Instance.currentEquipedItem != null)
            Inventory.Instance.removeItem(Inventory.Instance.currentEquipedItem.id);
    }

    public void handleInput(InputStruct inputStruct)
    {
           
    }

    public void handleInteract(bool status)
    {
        //if(status) pickUp();
    }

    public void handleDrop(bool status)
    {
        if(status) drop();
    }

    public void handleInventory(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void handleUtility(bool status)
    {
        throw new System.NotImplementedException();
    }
}
