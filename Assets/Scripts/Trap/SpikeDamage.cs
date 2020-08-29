using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float speed = 2.0f;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpikesDamage")
        {
            Destroy(gameObject);
        }
    }
}
