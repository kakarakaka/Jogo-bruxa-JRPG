using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    public TextMeshProUGUI characterInfoText;

    [Header("Lista")]
    public Transform itemListParent;

    public GameObject itemButtonPrefab;

    [Header("Informações")]
    public TextMeshProUGUI itemNameText;

    public TextMeshProUGUI itemDescriptionText;

    [Header("Botão")]
    public Button useButton;

    [Header("Personagem")]
    private BattleUnit selectedUnit;

    private ItemData selectedItem;

    private void OnEnable()
    {
        UpdateItemList();

        ClearInfo();
    }

    void ClearInfo()
    {
        if (itemNameText != null)
            itemNameText.text = "";

        if (itemDescriptionText != null)
            itemDescriptionText.text = "";
    }

    public void UpdateItemList()
    {
        Debug.Log("Inventory.Instance = " + Inventory.Instance);

        foreach (Transform child in itemListParent)
        {
            Destroy(child.gameObject);
        }

        foreach (InventorySlot slot
            in Inventory.Instance.items)
        {
            GameObject obj =
                Instantiate(
                    itemButtonPrefab,
                    itemListParent);

            ItemButtonUI button =
                obj.GetComponent<ItemButtonUI>();

            button.Setup(
                slot.item,
                slot.quantity,
                this);
        }
    }

    public void SelectItem(
        ItemData item)
    {
        selectedItem = item;

        itemNameText.text =
            item.itemName;

        itemDescriptionText.text =
            item.description;
    }

    public void SelectCharacter(
        GameObject character)
    {
        selectedUnit =
            character.GetComponent<BattleUnit>();

        if (selectedUnit == null)
        {
            Debug.LogError(
                character.name +
                " não possui BattleUnit!");
        }
    }

    public void UseSelectedItem()
    {
        if (selectedItem == null)
        {
            Debug.Log(
                "Nenhum item selecionado.");
            return;
        }

        if (selectedUnit == null)
        {
            Debug.Log(
                "Nenhum personagem selecionado.");
            return;
        }

        selectedUnit.UseItem(
            selectedItem);

        if (selectedItem.consumeOnUse)
        {
            Inventory.Instance
                .RemoveItem(
                    selectedItem,
                    1);
        }

        UpdateItemList();

        Debug.Log(
            selectedUnit.UnitName +
            " usou " +
            selectedItem.itemName);
    }

    public void ShowCharacterInfo(
    GameObject character)
    {
        BattleUnit unit =
            character.GetComponent<BattleUnit>();

        if (unit == null)
            return;

        characterInfoText.text =
            unit.UnitName +
            "\nHP: " +
            unit.currentHP +
            "/" +
            unit.MaxHP +
            "\nMP: " +
            unit.currentMP +
            "/" +
            unit.MaxMP;
    }
}