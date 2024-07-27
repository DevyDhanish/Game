using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBroadcaster : MonoBehaviour
{
    public static InputBroadcaster Instance;

    private Controlls inputActions;
    private InputStruct inputStruct = new InputStruct();
    private List<IInputRecieve> inputRecievers = new List<IInputRecieve>();

    public static event Action<bool> pressedInteract;
    public static event Action<bool> pressedDrop;
    public static event Action<bool> pressedInventory;
    public static event Action<bool> pressedUtility;

    private void Awake()
    {
        inputActions = new Controlls();
        inputActions.Enable();

        inputActions.GamePlay.Look.started += onMouseMovement;
        inputActions.GamePlay.Look.performed += onMouseMovement;
        inputActions.GamePlay.Look.canceled += onMouseMovement;

        inputActions.GamePlay.Movement.started += onWASDMovement;
        inputActions.GamePlay.Movement.performed += onWASDMovement;
        inputActions.GamePlay.Movement.canceled += onWASDMovement;

        inputActions.GamePlay.Interact.started += onInteractKeyPressed;
        inputActions.GamePlay.Interact.canceled += onInteractKeyPressed;

        inputActions.GamePlay.Use.started += onUtilityKeyPressed;
        inputActions.GamePlay.Use.canceled += onUtilityKeyPressed;

        inputActions.GamePlay.Inventory.started += onInventoryKeyPressed;
        inputActions.GamePlay.Inventory.canceled += onInventoryKeyPressed;

        inputActions.GamePlay.Sprint.started += onSprintKeyPressed;
        inputActions.GamePlay.Sprint.canceled += onSprintKeyPressed;

        inputActions.GamePlay.Drop.started += onDropKeyPressed;
        inputActions.GamePlay.Drop.canceled += onDropKeyPressed;
    }

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        IInputRecieve[] handlers = FindObjectsOfType<MonoBehaviour>().OfType<IInputRecieve>().ToArray();
        inputRecievers.AddRange(handlers);
    }

    void broadcast()
    {
        if (inputRecievers.Count == 0) return;

        foreach(var inputReciever in inputRecievers)
        {
            inputReciever.handleInput(inputStruct);
        }
    }

    private void OnDisable()
    {
        inputActions.Disable();

        inputActions.GamePlay.Look.started -= onMouseMovement;
        inputActions.GamePlay.Look.performed -= onMouseMovement;
        inputActions.GamePlay.Look.canceled -= onMouseMovement;

        inputActions.GamePlay.Movement.started -= onWASDMovement;
        inputActions.GamePlay.Movement.performed -= onWASDMovement;
        inputActions.GamePlay.Movement.canceled -= onWASDMovement;

        inputActions.GamePlay.Interact.started -= onInteractKeyPressed;
        inputActions.GamePlay.Interact.canceled -= onInteractKeyPressed;

        inputActions.GamePlay.Use.started -= onUtilityKeyPressed;
        inputActions.GamePlay.Use.canceled -= onUtilityKeyPressed;

        inputActions.GamePlay.Inventory.started -= onInventoryKeyPressed;
        inputActions.GamePlay.Inventory.canceled -= onInventoryKeyPressed;

        inputActions.GamePlay.Sprint.started -= onSprintKeyPressed;
        inputActions.GamePlay.Sprint.canceled -= onSprintKeyPressed;

        inputActions.GamePlay.Drop.started -= onDropKeyPressed;
        inputActions.GamePlay.Drop.canceled -= onDropKeyPressed;
    }

    private void onMouseMovement(InputAction.CallbackContext context)
    {
        inputStruct.mouseAxisVector  = context.ReadValue<Vector2>();
        broadcast();
    }

    private void onWASDMovement(InputAction.CallbackContext context)
    {
        inputStruct.movementVector = context.ReadValue<Vector2>();
        broadcast();
    }

    private void onSprintKeyPressed(InputAction.CallbackContext context)
    {
        inputStruct.pressedSprint = context.ReadValueAsButton();
        broadcast();
    }

    private void onDropKeyPressed(InputAction.CallbackContext context)
    {
        //inputStruct.pressedDrop = context.ReadValueAsButton();
        //broadcast();
        pressedDrop?.Invoke(context.ReadValueAsButton());
    }


    private void onInteractKeyPressed(InputAction.CallbackContext context)
    {
        //inputStruct.pressedInteract = context.ReadValueAsButton();
        //broadcast();
        pressedInteract?.Invoke(context.ReadValueAsButton());
    }

    private void onUtilityKeyPressed(InputAction.CallbackContext context)
    {
        //inputStruct.pressedUtility = context.ReadValueAsButton();
        //broadcast();
        pressedUtility?.Invoke(context.ReadValueAsButton());
    }

    private void onInventoryKeyPressed(InputAction.CallbackContext context)
    {
        //inputStruct.pressedInventory = context.ReadValueAsButton();
        //broadcast();
        pressedInventory?.Invoke(context.ReadValueAsButton());
    }

}
