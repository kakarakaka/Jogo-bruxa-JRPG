using TMPro;
using UnityEngine;

public class ShopUI :
    MonoBehaviour
{
    public static ShopUI Instance;

    [Header("UI")]
    public GameObject shopPanel;

    public TextMeshProUGUI goldText;

    public TextMeshProUGUI descriptionText;

    public TextMeshProUGUI priceText;

    [Header("Lista")]
    public Transform itemListParent;

    public GameObject itemButtonPrefab;

    private ShopData currentShop;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        shopPanel.SetActive(false);
    }

    public void OpenShop(
        ShopData shop)
    {
        currentShop = shop;

        RefreshGold();

        GenerateButtons();

        descriptionText.text = "";

        priceText.text = "";

        shopPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void GenerateButtons()
    {
        foreach (Transform child
                 in itemListParent)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemData item
                 in currentShop.items)
        {
            GameObject obj =
                Instantiate(
                    itemButtonPrefab,
                    itemListParent);

            ShopItemButton button =
                obj.GetComponent<ShopItemButton>();

            button.Setup(item);
        }
    }

    public void BuyItem(
        ItemData item)
    {
        if (BattleData.gold <
            item.buyPrice)
        {
            Debug.Log(
                "Gold insuficiente");

            return;
        }

        BattleData.gold -=
            item.buyPrice;

        Inventory.Instance.AddItem(
            item);

        RefreshGold();
    }

    void RefreshGold()
    {
        goldText.text =
            "Gold: " +
            BattleData.gold;
    }

    public void ShowItemInfo(
        ItemData item)
    {
        descriptionText.text =
            item.description;

        priceText.text =
            "Preço: " +
            item.buyPrice +
            " cristal de mana";
    }
}