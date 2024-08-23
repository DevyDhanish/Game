using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Console : MonoBehaviour
{
    public int maxLog;
    public Transform contentContainer;
    public GameObject textObj;
    public static Console Instance;

    void Start()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    public void Log(String msg)
    {
        GameObject text = createNewTextObj(msg);
        text.GetComponent<TextMeshProUGUI>().color = Color.green;
        addTextToConsole(text);
    }

    public void LogError(String msg)
    {
        GameObject text = createNewTextObj(msg);
        text.GetComponent<TextMeshProUGUI>().color = Color.red;
        addTextToConsole(text);
    }

    public void LogWarning(String msg)
    {
        GameObject text = createNewTextObj(msg);
        text.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        addTextToConsole(text);
    }

    public void CleanViewPort()
    {
        for(int i = 0; i < contentContainer.childCount; i++)
        {
            Destroy(contentContainer.GetChild(i - 1).gameObject);
        }
    }

    private void addTextToConsole(GameObject text)
    {
        if(contentContainer.childCount > maxLog)
        {
            for(int i = contentContainer.childCount; i > 5; i--)
            {
                Destroy(contentContainer.GetChild(i - 1).gameObject);
            }
        }

        text.transform.SetParent(contentContainer);
    }

    GameObject createNewTextObj(String msg)
    {
        GameObject text = Instantiate(textObj, new Vector3(0,0,0), Quaternion.identity);

        RectTransform textRect = text.GetComponent<RectTransform>();
        text.GetComponent<TextMeshProUGUI>().SetText(DateTime.Now + ": " + msg);

        text.transform.name = msg;

        text.transform.SetParent(contentContainer);

        textRect.anchoredPosition = new Vector2(0, 0);

        textRect.offsetMax = Vector2.zero;
        textRect.offsetMin = Vector2.zero;

        textRect.sizeDelta = new Vector2(0, 50);

        return text;
    }
}