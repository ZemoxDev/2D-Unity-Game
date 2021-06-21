using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private bool isInRange;
    public string sceneName;

    public GameObject buttonPressText;

    public int spawnPoint = 3;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(sceneName);
            PlayerPrefs.SetInt("proceduralDeath", spawnPoint);
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
