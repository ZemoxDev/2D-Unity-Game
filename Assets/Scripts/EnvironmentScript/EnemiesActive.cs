using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesActive : MonoBehaviour
{
    public GameObject enemies;

    public GameObject tentaclePortal;

    void Update()
    {
        if(enemies.transform.childCount == 0)
        {
            tentaclePortal.SetActive(true);
        }
    }
}
