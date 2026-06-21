using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<InventorySlot> items =
        new List<InventorySlot>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(
        ItemData item,
        int amount = 1)
    {
        InventorySlot slot =
            items.Find(
                x => x.item == item);

        if (slot != null)
        {
            slot.quantity += amount;
        }
        else
        {
            items.Add(
                new InventorySlot(
                    item,
                    amount));
        }
    }

    public void RemoveItem(
        ItemData item,
        int amount = 1)
    {
        InventorySlot slot =
            items.Find(
                x => x.item == item);

        if (slot == null)
            return;

        slot.quantity -= amount;

        if (slot.quantity <= 0)
        {
            items.Remove(slot);
        }
    }

    public int GetQuantity(
        ItemData item)
    {
        InventorySlot slot =
            items.Find(
                x => x.item == item);

        if (slot == null)
            return 0;

        return slot.quantity;
    }
}