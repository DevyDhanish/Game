using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player state and switching between them
/// </summary>
public class PlayerState
{
    protected PlayerController controller;
    private PlayerState currentState;
    public bool canChangeState { get; private set; }
    
    /// <summary>
    /// this method will get called when player enters this state
    /// </summary>
    /// <param name="controller"></param>
    public virtual void OnEnter(PlayerController controller) { }

    /// <summary>
    /// this method will get called every Update aka every frame
    /// </summary>
    /// <param name="controller"></param>
    public virtual void OnUpdate(PlayerController controller) { }
    
    /// <summary>
    /// this method will get called when player leaves this state
    /// </summary>
    /// <param name="controller"></param>
    public virtual void OnExit(PlayerController controller) { }

    /// <summary>
    /// Initiates PlayerState class
    /// </summary>
    /// <param name="initState">Default State to start with</param>
    /// <param name="pcontroller">PlayerController in case the state need to access something from it</param>
    public void initState(PlayerState initState, PlayerController pcontroller)
    {
        controller = pcontroller;
        currentState = initState;
        canChangeState = true;
    }

    /// <summary>
    /// Returns the current state the player is in
    /// </summary>
    /// <returns></returns>
    public PlayerState getState()
    {
        return currentState;
    }

    /// <summary>
    /// This method will change one state to another
    /// </summary>
    /// <param name="newState"></param>
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

    /// <summary>
    /// The player can change state only if the internal `canChangeState` is true (defualt value). this method is used to change the value of this bool
    /// </summary>
    /// <param name="status"></param>
    public void setCanChangeState(bool status)
    {
        canChangeState = status;
    }
}
