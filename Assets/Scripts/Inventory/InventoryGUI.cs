using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
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

    public void refreshItemGUI(List<GameObject> items)
    {
        if(items.Count > pos.Count)
        {
            Debug.Log("Inventory contain more item than it can show");
        }

        for(int i = 0; i < items.Count; i++)
        {
            pos[i].GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = items[i].name;
            pos[i].GetComponent<ItemGUI>().Item = items[i];
        }
    }

    public void handleInput(InputStruct inputStruct)
    {
        pressedInventory = inputStruct.pressedInventory;

        if(pressedInventory != active)
        {
            activateBoard();
        }
    }

    private void activateBoard()
    {
        active = !active;
        board.SetActive(active);
    }
}
