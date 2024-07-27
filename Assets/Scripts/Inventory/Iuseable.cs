using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Any object that can be useable ie player can pick it up add it to the Inventory to use it
/// </summary>
public interface Iuseable 
{
    /// <summary>
    /// Name this will be displayed in the Inventory
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Id of this object
    /// </summary>
    public int id {get;}

    /// <summary>
    /// discription of the item
    /// </summary>
    public string discription { get; }

    /// <summary>
    /// This method will be called by the `Inventory` when the Item get's added to the Inventory
    /// </summary>
    public void activate();

    /// <summary>
    /// This method will be called by the `Inventory` when the Item get's removed from the Inventory
    /// </summary>
    public void deactivate();

    /// <summary>
    /// This method will be called when the player presses the Utility Key (F key default)
    /// </summary>
    public void use();
}
