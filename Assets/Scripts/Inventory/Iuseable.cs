using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iuseable 
{
    public string Name { get; }
    public int id {get;}
    public string discription { get; }
    public void activate();
    public void deactivate();
    public void use();
}
