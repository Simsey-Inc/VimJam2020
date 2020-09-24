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
            "And thus ends the tale of Ramon, his imagination grand, and his dreams grander. We hope you enjoyed playing as much as we enjoyed making!"
        };

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<Text>();

        TextWriter.AddWriter_Static(messageText, allText[currentMessage], 0.1f, true);
    }
}
