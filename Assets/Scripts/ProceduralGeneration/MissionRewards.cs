using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionRewards : MonoBehaviour
{
    public GameObject grasslandEasy;
    public GameObject grasslandMedium;
    public GameObject grasslandHard;
    public GameObject cavesEasy;
    public GameObject cavesMedium;
    public GameObject cavesHard;
    public GameObject castleEasy;
    public GameObject castleMedium;
    public GameObject castleHard;
    public GameObject mointaintopEasy;
    public GameObject mointaintopMedium;
    public GameObject mointaintopHard;


    void Start()
    {
        if(PlayerPrefs.GetInt("missionReward") == 1)
        {
            grasslandEasy.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 2)
        {
            grasslandMedium.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 3)
        {
            grasslandHard.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 4)
        {
            cavesEasy.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 5)
        {
            cavesMedium.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 6)
        {
            cavesHard.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 7)
        {
            castleEasy.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 8)
        {
            castleMedium.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 9)
        {
            castleHard.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 10)
        {
            mointaintopEasy.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 11)
        {
            mointaintopMedium.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

        if (PlayerPrefs.GetInt("missionReward") == 12)
        {
            mointaintopHard.SetActive(true);

            PlayerPrefs.SetInt("missionReward", 0);
        }

    }
}
