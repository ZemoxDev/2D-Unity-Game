using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;

    private float currentHealth;
    private float maxHealth;
    PlayerStats player;
    GameManager manager;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        currentHealth = player.currentHealth;
        maxHealth = player.maxHealth;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, Time.deltaTime * 3f);

        if(manager.respawn == true)
        {
            StartCoroutine(WaitForRespawn());
        }
    }

    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(4f);

        player = FindObjectOfType<PlayerStats>();
    }
}
