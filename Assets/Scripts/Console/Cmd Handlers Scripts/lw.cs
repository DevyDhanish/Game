using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class lw : CommandHandler
{
    public void handle(Command cmd)
    {
        String word = "";
        foreach(var w in cmd.parameters)
        {
            word += w + " ";
        }
        Console.Instance.LogWarning(word);
        word = "";
    }
}
