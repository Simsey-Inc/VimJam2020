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
            "A foreign tale speaks of a terryfing cave, known as Cave Lark."
            ,"It is said that the sword of Haydrea, once wielded by the greatest of men, resides in this cave.",
        };

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<Text>();

        TextWriter.AddWriter_Static(messageText, allText[currentMessage], 0.1f, true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentMessage++;
        }

        if (currentMessage == 1)
        {
            NextPage();
            currentMessage++;
        }

        if (currentMessage > 2)
        {
            //SceneManager.LoadScene("SampleScene");
        }
    }

    private void NextPage()
    {
        messageText = transform.Find("messageText").GetComponent<Text>();

        TextWriter.AddWriter_Static(messageText, allText[1], 0.1f, true);
    }
}
