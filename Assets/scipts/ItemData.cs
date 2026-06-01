using UnityEngine;

[CreateAssetMenu(menuName = "JRPG/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;

    public string description;

    public Sprite icon;

    public bool consumable;

    public int healHP;

    public int healMP;
}