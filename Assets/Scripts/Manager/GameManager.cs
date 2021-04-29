using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    public bool respawn;

    private CinemachineVirtualCamera CVC;

    private PlayerStats PS;
    private PlayerCombatController PCC;
    private PlayerController PC;

    private void Start()
    {
        CVC = GameObject.Find("Player Cam").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        CheckRespawn();
    }
    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
    }

    private void CheckRespawn()
    {
        if (Time.time >= respawnTimeStart + respawnTime && respawn)
        {
            var playerTemp = Instantiate(player, respawnPoint);
            respawn = false;
            CVC.m_Follow = playerTemp.transform;
            CVC.m_LookAt = playerTemp.transform;

            NewStats();
        }
    }

    private void NewStats()
    {
        PS = GetComponentInChildren<PlayerStats>();
        PCC = GetComponentInChildren<PlayerCombatController>();
        PC = GetComponentInChildren<PlayerController>();

        PS.maxHealth = PlayerPrefs.GetFloat("health");
        PS.currentHealth = PlayerPrefs.GetFloat("health");
        PCC.attack1Damage = PlayerPrefs.GetFloat("damage");
        PC.movementSpeed = PlayerPrefs.GetFloat("speed");
        PC.dashSpeed = PlayerPrefs.GetFloat("intelligence");
    }
}
