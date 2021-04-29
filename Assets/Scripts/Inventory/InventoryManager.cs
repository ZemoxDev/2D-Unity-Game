using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Public")]
    public Inventory inventory;
    public EquipmentPanel equipmentPanel;


    [Header("Serialize Field")]
    [SerializeField] CraftingWindow craftingWindow;
    [SerializeField] ItemTooltip itemTooltip;
    [SerializeField] Image draggableItem;
    [SerializeField] DropItemArea dropItemArea;
    [SerializeField] QuestionDialog questionDialog;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] StatDisplay statPanel;

    public PlayerCombatController combatController;
    public PlayerController controller;
    public PlayerStats stats;

    private BaseItemSlot draggedSlot;

    private GameObject player;

    private void OnValidate()
    {
        if (itemTooltip == null)
            itemTooltip = FindObjectOfType<ItemTooltip>();
    }

    private void Awake()
    {
        statPanel.UpdateStatValues();

        inventory.OnRightClickEvent += InventoryRightClick;
        equipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;

        inventory.OnPointerEnterEvent += ShowTooltip;
        equipmentPanel.OnPointerEnterEvent += ShowTooltip;
        craftingWindow.OnPointerEnterEvent += ShowTooltip;

        inventory.OnPointerExitEvent += HideTooltip;
        equipmentPanel.OnPointerExitEvent += HideTooltip;
        craftingWindow.OnPointerExitEvent += HideTooltip;

        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;

        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;

        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;

        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;
        dropItemArea.OnDropEvent += DropItemOutsideUI;
    }

    private void Start()
    {
        if (itemSaveManager != null)
        {
            itemSaveManager.LoadEquipment(this);
            itemSaveManager.LoadInventory(this);
        }
    }

    private float nextActionTime = 0.0f;
    private float period = 2f;
    private GameObject gameManagerRespawn;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            itemSaveManager.SaveEquipment(this);
            itemSaveManager.SaveInventory(this);
            Debug.Log("Inventory Saved");
        }

        gameManagerRespawn = GameObject.Find("/GameManager/RespawnPoint");
        if (gameManagerRespawn.transform.childCount > 0)
        {
            player = GameObject.Find("/GameManager/RespawnPoint/Player(Clone)");

            combatController = player.GetComponent<PlayerCombatController>();
            controller = player.GetComponent<PlayerController>();
            stats = player.GetComponent<PlayerStats>();
        }
    }

    private void OnDestroy()
    {
        if (itemSaveManager != null)
        {
            itemSaveManager.SaveEquipment(this);
            itemSaveManager.SaveInventory(this);
        }
    }

    private void ShowTooltip(BaseItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            itemTooltip.ShowTooltip(equippableItem);
        }
    }

    private void HideTooltip(BaseItemSlot itemSlot)
    {
        if (itemTooltip.gameObject.activeSelf)
        {
            itemTooltip.HideTooltip();
        }
    }

    private void BeginDrag(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }


    private void EndDrag(BaseItemSlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(BaseItemSlot itemSlot)
    {
        draggableItem.transform.position = Input.mousePosition;
    }

    private void Drop(BaseItemSlot dropItemSlot)
    {
        if (draggedSlot == null) return;

        if (dropItemSlot.CanAddStack(draggedSlot.Item))
        {
            AddStacks(dropItemSlot);
        }
        else if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
        {
            SwapItems(dropItemSlot);
        }
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.Item.maximumStack - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, draggedSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        draggedSlot.Amount -= stacksToAdd;
    }

    private void SwapItems(BaseItemSlot dropItemSlot)
    {
        EquippableItem dragItem = draggedSlot.Item as EquippableItem;
        EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

        if (dropItemSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Equip(this);
            if (dropItem != null) dropItem.Unequip(this);
        }

        if (draggedSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Unequip(this);
            if (dropItem != null) dropItem.Equip(this);
        }

        statPanel.UpdateStatValues();

        Item draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;

        draggedSlot.Item = dropItemSlot.Item;
        draggedSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    private void DropItemOutsideUI()
    {
        if (draggedSlot == null) return;

        questionDialog.Show();
        BaseItemSlot slot = draggedSlot;
        questionDialog.OnYesEvent += () => DestroyItemInSlot(slot);
    }

    private void DestroyItemInSlot(BaseItemSlot itemSlot)
    {
        if (itemSlot is EquipmentSlot)
        {
            EquippableItem equippableItem = (EquippableItem)itemSlot.Item;
            equippableItem.Unequip(this);
        }

        itemSlot.Item.Destroy();
        itemSlot.Item = null;

        itemSaveManager.SaveEquipment(this);
        itemSaveManager.SaveInventory(this);
    }

    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (inventory.CanAddItem(item) && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem)
        {
            Equip((EquippableItem)itemSlot.Item);
        }
    }

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem)
        {
            Unequip((EquippableItem)itemSlot.Item);
        }
    }
}
