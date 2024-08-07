using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour, IInputRecieve
{
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask interactableLayer;

    private GameObject lookingAtObj; // obj player is currently looking at
    private RaycastHit hit;

    private void OnEnable()
    {
        InputBroadcaster.pressedInteract += handleInteract;
    }

    private void OnDisable()
    {
        InputBroadcaster.pressedInteract -= handleInteract;
    }

    private void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDistance, interactableLayer);
    
        if(hit.transform)
        {
            if(hit.transform.GetComponent<Iinteractable>() != null)
                lookingAtObj = hit.transform.gameObject;
        }
        else
        {
            lookingAtObj = null;
        }
    }

    private void onInteract()
    {
        if(lookingAtObj != null)
        {
            lookingAtObj.GetComponent<Iinteractable>().interact();
        }
    }

    public void handleDrop(bool status)
    {
        //throw new System.NotImplementedException();
    }

    public void handleInput(InputStruct inputStruct)
    {
        //throw new System.NotImplementedException();
    }

    public void handleInteract(bool status)
    {
        //throw new System.NotImplementedException();

        if(status) onInteract();
    }

    public void handleInventory(bool status)
    {
        //throw new System.NotImplementedException();
    }

    public void handleUtility(bool status)
    {
        //throw new System.NotImplementedException();
    }
}
