using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemCollection : MonoBehaviour
{
    public GameObject greenFireParticles;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            greenFireParticles.SetActive(true);
        }
    }
}
