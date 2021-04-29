using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDamage : MonoBehaviour
{
    public PlayerStats stats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
