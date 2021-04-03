using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleStart : MonoBehaviour
{
    public GameObject bossEnemy;

    public GameObject topbar;
    public GameObject downbar;

    public GameObject chest;
    public GameObject crackedDirt;

    private void LateUpdate()
    {
        if(bossEnemy == null)
        {
            chest.SetActive(true);
            crackedDirt.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            bossEnemy.SetActive(true);
            topbar.SetActive(true);
            downbar.SetActive(true);
        }
    }
}
