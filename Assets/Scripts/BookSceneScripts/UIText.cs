using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    private Text messageText;

    int currentMessage;

    string[] allText = new string[]
        {
            "Cave Lark is known by many as one of the most dangerous caves in the world. Only a few men have been able to enter the cave and return unscathed. It is said that the sword of Haydrea, once wielded by the greatest of men, resides there. This sword drives many explorers to delve into the depths of the cave in an attempt to collect the relic.",
        };

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<Text>();

        TextWriter.AddWriter_Static(messageText, allText[currentMessage], 0.05f, true);

    }
}
