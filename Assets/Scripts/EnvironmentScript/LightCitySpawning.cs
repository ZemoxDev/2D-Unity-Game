using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCitySpawning : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;

    public GameObject player;

    private bool isInRange;
    public GameObject buttonPressText;

    void Start()
    {
        if (PlayerPrefs.GetInt("proceduralDeath") == 0)
        {
            player.transform.position = point1.transform.position;
        }

        if (PlayerPrefs.GetInt("proceduralDeath") == 1)
        {
            player.transform.position = point2.transform.position;
        }

        if(PlayerPrefs.GetInt("proceduralDeath") == 2)
        {
            player.transform.position = point3.transform.position;
        }

        if (PlayerPrefs.GetInt("proceduralDeath") == 3)
        {
            player.transform.position = point4.transform.position;
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt("proceduralDeath", 0);
            player.transform.position = point3.transform.position;
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
