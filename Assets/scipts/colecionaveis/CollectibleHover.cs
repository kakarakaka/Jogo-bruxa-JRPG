using UnityEngine;
using UnityEngine.EventSystems;

public class CollectibleHover : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public CollectibleData data;
    public CollectibleMenuUI menu;

    public void OnPointerEnter(PointerEventData eventData)
    {
        menu.ShowInfo(data);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        menu.ClearInfo();
    }
}