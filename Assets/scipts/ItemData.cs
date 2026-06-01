using UnityEngine;

[CreateAssetMenu(
    fileName = "Novo Item",
    menuName = "JRPG/Item")]
public class ItemData : ScriptableObject
{
    [Header("Informações")]
    public string itemName;

    [TextArea(3, 5)]
    public string description;

    public Sprite icon;

    [Header("Efeitos")]

    public int healHP;

    public int healMP;

    public int addAttack;

    public int addDefense;

    public int addSpeed;

    [Header("Consumível")]
    public bool consumeOnUse = true;
}