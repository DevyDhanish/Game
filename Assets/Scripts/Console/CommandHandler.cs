using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CommandHandler 
{
    public abstract void handle(Command cmd);
}