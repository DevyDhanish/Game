using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDispatcher
{
    Dictionary<String, CommandHandler> handlers = new Dictionary<String, CommandHandler>();

    public void InitCommandDispatcher()
    {
        handlers["/clear"] = new clear();
        handlers["/lw"] = new lw();
        handlers["/le"] = new le();
    }

    public void dispatchCommand(Command cmd)
    {
        handlers[cmd.keyword].handle(cmd);
    }
}
