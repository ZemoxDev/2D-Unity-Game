using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MissionsScene : MonoBehaviour
{
    public int neededEnemyKills = 5;

    private int enemyKills;

    [SerializeField] TextMeshProUGUI EnemiesNeeded1;
    [SerializeField] TextMeshProUGUI EnemiesNeeded2;
    [SerializeField] TextMeshProUGUI EnemyKills;

    private int enemies;
    private int lastEnemy;

    public int reward;

    private void Start()
    {
        StartCoroutine(GenStopped());
        PlayerPrefs.SetInt("missionReward", 0);
    }

    void Update()
    {
        EnemiesNeeded1.text = neededEnemyKills.ToString();
        EnemiesNeeded2.text = neededEnemyKills.ToString();
        EnemyKills.text = enemyKills.ToString();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = objects.Length;

        if (enemies < lastEnemy)
        {
            enemyKills += 1;

            lastEnemy = enemies;
        }

        if(enemyKills == neededEnemyKills)
        {
            PlayerPrefs.SetInt("proceduralDeath", 2);
            PlayerPrefs.SetInt("missionReward", reward);

            SceneManager.LoadScene("CityOfLight");
        }
    }

    IEnumerator GenStopped()
    {
        yield return new WaitForSeconds(12f);

        lastEnemy = enemies;
    }
}
