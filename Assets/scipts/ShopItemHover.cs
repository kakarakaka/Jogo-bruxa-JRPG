using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemHover :
    MonoBehaviour,
    IPointerEnterHandler
{
    private ShopItemButton button;

    private void Awake()
    {
        button =
            GetComponent<ShopItemButton>();
    }

    public void OnPointerEnter(
        PointerEventData eventData)
    {
        ShopUI.Instance.ShowItemInfo(
            button.GetItem());
    }
}