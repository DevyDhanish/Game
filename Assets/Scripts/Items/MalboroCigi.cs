using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalboroCigi : MonoBehaviour, Iuseable, Iinteractable
{
    public string Name => "Malboro cigi";

    public int id => 2;

    public string discription => "Cigi";

    public void activate()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void deactivate()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
    }

    public void interact()
    {
        Inventory.Instance.addItem(this.gameObject);
    }

    public void use()
    {
        Debug.Log("Cigi used");
    }
}
