using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInputRecieve
{
    public static Inventory Instance;
    public GameObject inventoryGui;
    private bool pressedUse;
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    private Iuseable currentEquipedItem;
    public int totalItems {get; private set; }

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

        inventoryGui.GetComponent<InventoryGUI>().refreshItemGUI(items);
    }

    public void handleInput(InputStruct inputs)
    {
        pressedUse = inputs.pressedUtility;
        Debug.Log(pressedUse);
        if(pressedUse) currentEquipedItem.use();
    }

    public void equipItem(int index)
    {
        currentEquipedItem = findItem(index).GetComponent<Iuseable>();

        //currentEquipedItem = items[index].GetComponent<Iuseable>();
    }

    public void addItem(GameObject item)
    {
        if(item.GetComponent<Iuseable>() != null)
            items.Add(item);
        totalItems = items.Count;
    }

    public void removeItem(int index)
    {
        items.Remove(findItem(index));
    }

    private GameObject findItem(int id)
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
