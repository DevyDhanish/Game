using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryGUI : MonoBehaviour, IInputRecieve
{
    public List<RectTransform> pos;
    public GameObject board;
    private bool pressedInventory;
    private bool active = false;

    void Start()
    {
        board.SetActive(active);
    }

    void OnEnable()
    {
        InputBroadcaster.pressedInventory += handleInventory;
        Inventory.OnInventoryChanged += onInventoryChanged;
    }

    void OnDisable()
    {
        InputBroadcaster.pressedInventory -= handleInventory;
        Inventory.OnInventoryChanged -= onInventoryChanged;
    }

    public void onInventoryChanged()
    {
        refreshItemGUI(Inventory.Instance.getItems());
    }

    public void refreshItemGUI(List<GameObject> items)
    {
        if(items.Count > pos.Count)
        {
            Debug.Log("Inventory contain more item than it can show");
        }

        for(int i = 0; i < pos.Count; i++)
        {
            pos[i].GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            pos[i].GetComponent<ItemGUI>().Item = null;
        }

        if(items.Count == 0) return;

        for(int i = 0; i < items.Count; i++)
        {
            pos[i].GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = items[i].GetComponent<Iuseable>().Name;
            pos[i].GetComponent<ItemGUI>().Item = items[i];
        }
    }

    private void activateBoard()
    {
        active = !active;
        board.SetActive(active);
    }

    public void handleInventory(bool status)
    {
                //pressedInventory = inputStruct.pressedInventory;
        activateBoard();
    }
}
