using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cmdHandler : MonoBehaviour
{
    public Char prefix;
    public TMP_InputField inputField;
    private CommandDispatcher cmdDispatch = new CommandDispatcher();

    void Start()
    {
        cmdDispatch.InitCommandDispatcher();
    }

    public void OnExecute()
    {
        if(inputField.text[0] != prefix)
        {
            Console.Instance.Log(inputField.text);
            return;
        }

        List<String> tokens = parse(inputField.text);

        Command commandObj = new Command();

        commandObj.keyword = tokens[0];
        tokens.Remove(commandObj.keyword);
        commandObj.parameters = tokens;

        cmdDispatch.dispatchCommand(commandObj);
    }

    private List<String> parse(String input)
    {
        List<String> tokens = new List<String>();

        String temp_word = "";
        foreach(var word in input)
        {
            if(word == ' ')
            {
                tokens.Add(temp_word);
                temp_word = "";
            }
            else
            {
                temp_word += word;
            }
        }
        tokens.Add(temp_word);

        return tokens;
    }
}
