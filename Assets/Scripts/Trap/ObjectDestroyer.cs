using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float Lifetime;

    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}
