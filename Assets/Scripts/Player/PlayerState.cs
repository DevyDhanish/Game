using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerController controller;
    private PlayerState currentState;
    public bool canChangeState { get; private set; }
    public virtual void OnEnter(PlayerController controller) { }
    public virtual void OnUpdate(PlayerController controller) { }
    public virtual void OnExit(PlayerController controller) { }

    public void initState(PlayerState initState, PlayerController pcontroller)
    {
        controller = pcontroller;
        currentState = initState;
        canChangeState = true;
    }
    public PlayerState getState()
    {
        return currentState;
    }

    public void switchState(PlayerState newState)
    {
        if (!canChangeState) return;

        if(currentState != null)
        {
            currentState.OnExit(controller);
        }

        currentState = newState;
        currentState.OnEnter(controller);
    }

    public void setCanChangeState(bool status)
    {
        canChangeState = status;
    }
}
