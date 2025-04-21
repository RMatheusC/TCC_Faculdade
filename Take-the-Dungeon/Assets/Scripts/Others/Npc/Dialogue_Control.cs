using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Control : MonoBehaviour
{
    [System.Serializable]
    public enum idion { 
        pt, 
        eng, 
        spa
    }

    public idion language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] sentences;

    public static Dialogue_Control instance;

    private void Awake()
    {
        instance = this;
    }
    public void NextSentence() {
        if (speechText.text == sentences[index]) {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Speech(string[] txt) {
        if (!isShowing) {
            dialogueObj.SetActive(true);
            sentences = txt;

            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
