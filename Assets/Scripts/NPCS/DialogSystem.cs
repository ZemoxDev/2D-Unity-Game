using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject textBackground;

    private void Start()
    {
        StartCoroutine(Type());
        textBackground.SetActive(true);
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            textBackground.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            continueButton.SetActive(false);

            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                textDisplay.text = "";
                continueButton.SetActive(false);
                textBackground.SetActive(false);
            }
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } 
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textBackground.SetActive(false);
        }
    }
}
