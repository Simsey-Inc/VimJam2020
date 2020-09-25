using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText1 : MonoBehaviour
{

    private Text messageText;
    int currentMessage;
    string[] allText = new string[]
        {
            "With his grand imagination, Ramon collected Haydrea and escaped Cave Lark all in one piece. We hope you enjoyed playing as much as we enjoyed making!"
        };

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<Text>();

        TextWriter.AddWriter_Static(messageText, allText[currentMessage], 0.1f, true);
    }
}
