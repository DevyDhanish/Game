using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class le : CommandHandler
{
    public void handle(Command cmd)
    {
        String word = "";
        foreach(var w in cmd.parameters)
        {
            word += w + " ";
        }
        Console.Instance.LogError(word);
        word = "";
    }
}
