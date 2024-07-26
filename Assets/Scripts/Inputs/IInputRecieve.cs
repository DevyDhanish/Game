using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputRecieve
{
    public abstract void handleInput(InputStruct inputStruct);

    public abstract void handleInteract(bool status);
    public abstract void handleDrop(bool status);
    public abstract void handleInventory(bool status);
    public abstract void handleUtility(bool status);

}
