using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleMenuUI : MonoBehaviour
{
    [System.Serializable]
    public class CollectibleSlot
    {
        public string id;
        public RawImage icon;
        public CollectibleData data;
    }

    public CollectibleSlot[] slots;

    [Header("Hover UI")]
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            bool unlocked =
                CollectibleManager.Instance.IsUnlocked(slot.id);

            slot.icon.gameObject.SetActive(unlocked);
        }

        nameText.text = "";
        descriptionText.text = "";
    }

    public void ShowInfo(CollectibleData data)
    {
        nameText.text = data.collectibleName;
        descriptionText.text = data.description;
    }

    public void ClearInfo()
    {
        nameText.text = "";
        descriptionText.text = "";
    }
}