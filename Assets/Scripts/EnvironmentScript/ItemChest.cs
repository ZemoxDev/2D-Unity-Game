using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item[] item;
    [SerializeField] int amount = 1;
    [SerializeField] Inventory inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.E;
    [SerializeField] ParticleSystem gold;
    [SerializeField] GameObject ButtonPressText;

    private Animator anim;

    private bool isInRange;
    private bool isEmpty;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("chestOpen", false);
        gold.Stop();
    }

    private void Update()
    {
        int randomIndex = Random.Range(0, item.Length);
        if(isInRange && !isEmpty && Input.GetKeyDown(itemPickupKeyCode))
        {
            Item itemCopy = item[randomIndex].GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                amount--;
                if (amount == 0)
                {
                    isEmpty = true;
                    gold.Play();
                }
                anim.SetBool("chestOpen", true);
            }
            else
            {
                itemCopy.Destroy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInRange = true;
            ButtonPressText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
            ButtonPressText.SetActive(false);
        }
    }
}
