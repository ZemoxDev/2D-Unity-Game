using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Helmet, 
    Chest,
    Legs,
    Boots,
    Weapon,
    Necklace1,
    Necklace2,
    Ring,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public float StrengthBonus;
    public float AgilityBonus;
    public float IntelligenceBonus;
    public float VitalityBonus;
    [Space]
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float VitalityPercentBonus;
    [Space]
    public EquipmentType EquipmentType;

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(InventoryManager manager)
    {
        manager.combatController.attack1Damage += StrengthBonus;
        manager.stats.maxHealth += VitalityBonus;
        manager.controller.movementSpeed += AgilityBonus;
        manager.controller.dashSpeed += IntelligenceBonus;
    }

    public void Unequip(InventoryManager manager)
    {
        manager.combatController.attack1Damage -= StrengthBonus;
        manager.stats.maxHealth -= VitalityBonus;
        manager.controller.movementSpeed -= AgilityBonus;
        manager.controller.dashSpeed -= IntelligenceBonus;
    }
}

