using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterHoverInfo :
    MonoBehaviour,
    IPointerEnterHandler
{
    public ItemMenu itemMenu;

    public GameObject character;

    public void OnPointerEnter(
        PointerEventData eventData)
    {
        itemMenu.ShowCharacterInfo(
            character);
    }
}