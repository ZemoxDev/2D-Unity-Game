using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemScript : MonoBehaviour
{
    public GameObject fireParticle;
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && fireParticle.active == false)
        {
            fireParticle.SetActive(true);
            respawnPoint.position = transform.position;

            FindObjectOfType<AudioManager>().Play("CheckpointSound");
        }
    }
}
