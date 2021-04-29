using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] GameObject buttonPressText;
    [SerializeField] KeyCode[] toggleInventoryKeys;

    void Awake()
    {
        StartCoroutine(InventoryStart());
        HideMouseCursor();
    }

    void Update()
    {
        for(int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);

                if (inventoryGameObject.activeSelf)
                {
                    ShowMouseCursor();
                }
                else
                {
                    HideMouseCursor();
                }
                break;
            }
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator InventoryStart()
    {
        inventoryGameObject.SetActive(true);
        buttonPressText.SetActive(true);

        yield return new WaitForSeconds(0.005f);

        buttonPressText.SetActive(false);
        inventoryGameObject.SetActive(false);
    }
}
