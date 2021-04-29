using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySetActive1 : MonoBehaviour
{
    public GameObject inventory;
    public GameObject equipment;
    public GameObject statSection;
    public GameObject tooltip;

    public bool isPaused;

    void Start()
    {
        StartCoroutine(InventoryStart());
        equipment.SetActive(false);
        statSection.SetActive(false);
        tooltip.SetActive(false);
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
        statSection.SetActive(false);
        tooltip.SetActive(false);
        isPaused = true;
    }

    public void Activate()
    {
       inventory.SetActive(true);
       equipment.SetActive(true);
       statSection.SetActive(true);
       tooltip.SetActive(true);
       isPaused = false;
    }

    IEnumerator InventoryStart()
    {
        inventory.SetActive(true);

        yield return new WaitForSeconds(0.05f);

        inventory.SetActive(false);
    }
}