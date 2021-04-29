using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    public TextMeshProUGUI StrengthNumber;
    public TextMeshProUGUI AgilityNumber;
    public TextMeshProUGUI IntelligenceNumber;
    public TextMeshProUGUI RobustnessNumber;

    [SerializeField] PlayerCombatController combatController;
    [SerializeField] PlayerController controller;
    [SerializeField] PlayerStats stats;

    private GameObject player;
    private GameObject gameManagerRespawn;

    public void UpdateStatValues()
    {
        StrengthNumber.text = combatController.attack1Damage.ToString();
        AgilityNumber.text = controller.movementSpeed.ToString();
        IntelligenceNumber.text = controller.dashSpeed.ToString();
        RobustnessNumber.text = stats.maxHealth.ToString();
    }

    private void Update()
    {
        gameManagerRespawn = GameObject.Find("/GameManager/RespawnPoint");
        if(gameManagerRespawn.transform.childCount > 0)
        {
            player = GameObject.Find("/GameManager/RespawnPoint/Player(Clone)");

            combatController = player.GetComponent<PlayerCombatController>();
            controller = player.GetComponent<PlayerController>();
            stats = player.GetComponent<PlayerStats>();
        }
    }
}
