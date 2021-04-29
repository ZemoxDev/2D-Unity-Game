using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStartScript : MonoBehaviour
{
    public GameObject waveSpawner;
    public GameObject tentacleBoss;
    public GameObject healthBar;
    public GameObject chest;

    public GameObject player;

    public GameObject bossEndLight;
    public GameObject angel;

    public Slider bossSlider;

    public Animator tentacleAnim;


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (bossSlider.value == 0)
        {
            waveSpawner.SetActive(false);
            chest.SetActive(true);
            healthBar.SetActive(false);
            tentacleAnim.SetBool("death", true);
            StartCoroutine(AngelStart());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            waveSpawner.SetActive(true);
            tentacleBoss.SetActive(true);
            healthBar.SetActive(true);
        }   
    }

    IEnumerator AngelStart()
    {
        yield return new WaitForSeconds(7f);

        bossEndLight.SetActive(true);
        bossEndLight.transform.position = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + 28, player.transform.localPosition.z);
        angel.SetActive(true);
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(28f);

        StartCoroutine(LoadLevel());
    }

    public Animator transition;
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("CityOfLight");
    }
}
