using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpikeDamage : MonoBehaviour
{
    public float destroy = 5.0f;

    public GameObject spikeDamage;
    public Transform spikeDamagePos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spikeDamage.SetActive(true);
            Instantiate(spikeDamage, transform.position, transform.rotation);
            Destroy(spikeDamage, destroy);
        }
    }
}
