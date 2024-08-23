using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOD : MonoBehaviour
{
    public List<int> layersToIgnore = new List<int>();
    public List<Collider> TriggerList = new List<Collider>();
    public String WillRenderLayer;
    public String WillNotRenderLayer;

    // Called when something enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (layersToIgnore.Contains(other.gameObject.layer)) return;
        // If the object is not already in the list
        if (!TriggerList.Contains(other))
        {
            // Add the object to the list and change its layer
            toggleLayer(other.gameObject, LayerMask.NameToLayer(WillRenderLayer), true);
            TriggerList.Add(other);
        }
    }

    // Called when something exits the trigger
    void OnTriggerExit(Collider other)
    {
        if (layersToIgnore.Contains(other.gameObject.layer)) return;
        // If the object is in the list
        if (TriggerList.Contains(other))
        {
            // Remove it from the list and change its layer
            toggleLayer(other.gameObject, LayerMask.NameToLayer(WillNotRenderLayer), true);
            TriggerList.Remove(other);
        }
    }

    void toggleLayer(GameObject obj, int layer, bool childToo)
    {
        if(childToo)
        {
            if(obj.transform.childCount > 0)
            {
                for(int i = 0; i < obj.transform.childCount; i++)
                {
                    if (obj.transform.GetChild(i).gameObject.layer == layer) return;
                    else obj.transform.GetChild(i).gameObject.layer = layer;
                }
            }
        }

        if (obj.gameObject.layer == layer) return;
        else obj.gameObject.layer = layer;
    }
}
