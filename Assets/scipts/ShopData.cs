using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Nova Loja",
    menuName = "JRPG/Shop")]
public class ShopData : ScriptableObject
{
    public List<ItemData> items =
        new List<ItemData>();
}