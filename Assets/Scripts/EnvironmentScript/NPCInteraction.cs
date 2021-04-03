using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] GameObject buttonPressText;
    [SerializeField] GameObject dialogManager;

    private bool isInRange;

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.F))
        {
            dialogManager.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            buttonPressText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
            buttonPressText.SetActive(false);
        }
    }
}
