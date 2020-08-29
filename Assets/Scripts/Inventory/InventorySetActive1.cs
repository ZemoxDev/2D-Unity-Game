using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySetActive1 : MonoBehaviour
{
    public GameObject inventory;
    public GameObject equipment;

    public bool isPaused;

    void Start()
    {
        inventory.SetActive(false);
        equipment.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPaused)
            {
                Activate();
            }
            else
            {
                Deactivate();
            }
        }
    }
    public void Deactivate()
    {
        inventory.SetActive(false);
        equipment.SetActive(false);
        isPaused = true;
    }

    public void Activate()
    {
       inventory.SetActive(true);
        equipment.SetActive(true);
        isPaused = false;
    }
}