using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    //public GameObject inventoryGui;
    [SerializeField] private int maxItem;
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    public Iuseable currentEquipedItem {get; private set;}
    public int totalItems {get; private set; }
    public static event Action OnInventoryChanged;

    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        } 
        else
        {
            Instance = this;
        }

        totalItems = items.Count;
        currentEquipedItem = null;
        //inventoryGui.GetComponent<InventoryGUI>().refreshItemGUI(items);
    }

    /// <summary>
    /// Returs the list of items in the Inventory.
    /// </summary>
    /// <returns>List<GameObject></returns>
    public List<GameObject> getItems()
    {
        return items;
    }

    /// <summary>
    /// Equips the item with the given index, item must inherit the Iuseable interface.
    /// </summary>
    /// <param name="index">id of the useable item</param>
    public void equipItem(int index)
    {
        // hide prev obj before equiping the new one
        if(currentEquipedItem != null)
        {
            GameObject prevObj = findItem(currentEquipedItem.id);

            if(prevObj) prevObj.SetActive(false);
        }

        GameObject item = findItem(index);

        item.SetActive(true);

        currentEquipedItem = item.GetComponent<Iuseable>();
        //currentEquipedItem = items[index].GetComponent<Iuseable>();
    }

    /// <summary>
    /// Adds the item to the inventory list, sets it's position and rotation and invokes the items `activate()` method. This method will also
    /// set the `Inventory` gameobject as it's parent
    /// </summary>
    /// <param name="item">the item to add to the inventory can be any gameobject in `useable` layer and inherits `Iuseable`</param>
    public void addItem(GameObject item)
    {
        if(item.GetComponent<Iuseable>() == null) return; // if the item does not have Iuseable don't add it.

        if(items.Count >= maxItem) return;  // return for now might wanna publish a event like `InventoryFull` to display some UI

        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
        item.transform.SetParent(transform);
        item.GetComponent<Iuseable>().activate();
        item.gameObject.SetActive(false);

        items.Add(item);

        totalItems = items.Count;
        OnInventoryChanged?.Invoke();
    }

    /// <summary>
    /// Removes the item with the given id from the Inventory and invokes the items deactivate() method. This method will also remove the item from the 
    /// parent
    /// </summary>
    /// <param name="itemId">id of the item to remove</param>
    public void removeItem(int itemId)
    {
        GameObject obj = findItem(itemId);
        obj.GetComponent<Iuseable>().deactivate();
        obj.transform.SetParent(null);

        items.Remove(obj);
        totalItems = items.Count;
        
        currentEquipedItem = null;
        
        OnInventoryChanged?.Invoke();
    }

    /// <summary>
    /// Finds the Item with with given id in the inventory list.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public GameObject findItem(int id)
    {
        foreach(var item in items)
        {
            if(item.GetComponent<Iuseable>().id == id)
            {
                return item;
            }
        }

        return null;
    }
}
