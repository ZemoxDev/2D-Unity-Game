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

    public void UpdateStatValues()
    {
        StrengthNumber.text = combatController.attack1Damage.ToString();
        AgilityNumber.text = controller.movementSpeed.ToString();
        IntelligenceNumber.text = controller.dashSpeed.ToString();
        RobustnessNumber.text = stats.maxHealth.ToString();
    }
}
