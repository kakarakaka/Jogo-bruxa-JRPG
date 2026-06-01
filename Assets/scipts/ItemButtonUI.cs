using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButtonUI :
    MonoBehaviour,
    IPointerEnterHandler
{
    public Image icon;

    public TextMeshProUGUI itemName;

    public TextMeshProUGUI quantityText;

    private ItemData item;

    private ItemMenu menu;

    public void Setup(
        ItemData itemData,
        int quantity,
        ItemMenu itemMenu)
    {
        item = itemData;

        menu = itemMenu;

        if (icon != null)
            icon.sprite = item.icon;

        itemName.text =
            item.itemName;

        quantityText.text =
            "x" + quantity;

        GetComponent<Button>()
            .onClick
            .AddListener(OnClick);
    }

    void OnClick()
    {
        menu.SelectItem(item);
    }

    public void OnPointerEnter(
        PointerEventData eventData)
    {
        menu.SelectItem(item);
    }
}