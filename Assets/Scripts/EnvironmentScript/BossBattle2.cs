using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattle2 : MonoBehaviour
{
    public GameObject healthBar;

    public Slider bossSlider;

    public GameObject upPanel;
    public GameObject downPanel;

    public DarkBoss2 darkBoss2;

    void Update()
    {
        bossSlider.value = Mathf.Lerp(bossSlider.value, darkBoss2.currentHealth, Time.deltaTime * 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthBar.SetActive(true);

            upPanel.SetActive(true);
            downPanel.SetActive(true);
        }
    }
}
