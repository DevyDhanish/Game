using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    //public GameObject inventoryGui;
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

        //inventoryGui.GetComponent<InventoryGUI>().refreshItemGUI(items);
    }

    public List<GameObject> getItems()
    {
        return items;
    }

    public void equipItem(int index)
    {
        
        GameObject item = findItem(index);

        item.SetActive(true);

        currentEquipedItem = item.GetComponent<Iuseable>();
        //currentEquipedItem = items[index].GetComponent<Iuseable>();
    }

    public void addItem(GameObject item)
    {
        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
        item.transform.SetParent(transform);

        item.gameObject.SetActive(false);

        item.GetComponent<Iuseable>().activate();

        if(item.GetComponent<Iuseable>() != null)
            items.Add(item);
        totalItems = items.Count;
        OnInventoryChanged?.Invoke();
    }

    public void removeItem(int index)
    {
        GameObject obj = findItem(index);

        obj.GetComponent<Iuseable>().deactivate();

        obj.transform.SetParent(null);

        items.Remove(obj);

        if(items.Count == 0) currentEquipedItem = null;
        
        OnInventoryChanged?.Invoke();
    }

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
