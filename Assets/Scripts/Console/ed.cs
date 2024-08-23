using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ed : MonoBehaviour, IInputRecieve
{
    private bool active = false;
    public GameObject Console;
    void OnEnable()
    {
        InputBroadcaster.pressedDevConsoleButton += handleDevConsoleButtonPressed;
    }

    void OnDisable()
    {
        InputBroadcaster.pressedDevConsoleButton -= handleDevConsoleButtonPressed;
    }

    void enableDisableConsole()
    {
        Console.gameObject.SetActive(active);
        active = !active;
    }

    public void handleDevConsoleButtonPressed(bool status)
    {
        if(status) enableDisableConsole();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
