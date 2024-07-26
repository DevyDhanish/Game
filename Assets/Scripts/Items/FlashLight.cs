using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour, Iuseable
{
    public string Name => "FlashLight";

    public int id => 1;

    public string discription => "Just a normal flashlight.";
    private bool active;
    private Light lights;

    public void Start()
    {
        lights = gameObject.GetComponent<Light>();
        //lights.enabled = active;
    }

    public void use()
    {
        active = !active;
        lights.enabled = active;    
    }

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
}
