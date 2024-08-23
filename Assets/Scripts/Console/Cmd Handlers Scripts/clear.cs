using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : CommandHandler
{
    public void handle(Command cmd)
    {
        Console.Instance.CleanViewPort();
    }
}
