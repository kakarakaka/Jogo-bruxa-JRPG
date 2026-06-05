using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;

    private ItemData item;

    public void Setup(ItemData newItem)
    {
        item = newItem;

        itemNameText.text =
            newItem.itemName;
    }

    public void Buy()
    {
        ShopUI.Instance.BuyItem(item);
    }

    public ItemData GetItem()
    {
        return item;
    }
}