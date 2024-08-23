using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Any Monobehaviour that needs user input must inherit this interface and provide the respective function bodies.
/// </summary>
public interface IInputRecieve
{
    /// <summary>
    /// This function will be called automatically by the `InputBroadcaster` when user interacts with MOUSE, WASD OR SPRINT button. 
    /// </summary>
    /// <param name="inputStruct">The inputStruct will contain the updated Vector2 of mouse movement, WASD and bool for sprint button</param>
    public virtual void handleInput(InputStruct inputStruct){}

    /// <summary>
    /// Gets called when the interact button has been pressed, Inheriting script must add this method to the `InputBroadcaster.pressedInteract` event
    /// </summary>
    /// <param name="status">status will be true if the button has been pressed, false otherwise</param>
    public virtual void handleInteract(bool status){}

    /// <summary>
    /// Gets called when the drop button has been pressed, Inheriting script must add this method to the `InputBroadcaster.pressedDrop` event
    /// </summary>
    /// <param name="status">status will be true if the button has been pressed, false otherwise</param>
    public virtual void handleDrop(bool status){}

    /// <summary>
    /// Gets called when the inventory button has been pressed, Inheriting script must add this method to the `InputBroadcaster.pressedInventory` event
    /// </summary>
    /// <param name="status">status will be true if the button has been pressed, false otherwise</param>
    public virtual void handleInventory(bool status){}

    /// <summary>
    /// Gets called when the Utility button has been pressed, Inheriting script must add this method to the `InputBroadcaster.pressedUtility` event
    /// </summary>
    /// <param name="status">status will be true if the button has been pressed, false otherwise</param>
    public virtual void handleUtility(bool status){}


    public virtual void handleDevConsoleButtonPressed(bool status){}
}
