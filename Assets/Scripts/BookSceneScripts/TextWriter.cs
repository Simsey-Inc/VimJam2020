using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private List<TextWriterSingle> textWriterSingleList;
    private static TextWriter instance;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }

    private void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters));
    }

    private void Update()
    {
        for (int i = 0; i < textWriterSingleList.Count; i++) {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {

        #region Private Variables
        private Text uiText;
        private string textToWrite;
        private float timePerCharacter;
        private float timer;
        private int characterIndex;
        private bool invisibleCharacters;
        #endregion

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            characterIndex = 0;
          }

         public bool Update()
            {
                    timer -= Time.deltaTime;
                    while (timer <= 0f)
                    {
                        // Display next character
                        timer += timePerCharacter;
                        characterIndex++;
                        string text = textToWrite.Substring(0, characterIndex);
                        if (invisibleCharacters)
                        {
                            text += "<color=#00000000>" + textToWrite.Substring(0, characterIndex) + "</color>";
                        }
                        uiText.text = text;

                        if (characterIndex >= textToWrite.Length)
                        {
                            return true;
                        }
                    }

                return false;
          }
     }
 }
