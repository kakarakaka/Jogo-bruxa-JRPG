using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    public TMP_Text goldText;

    void Update()
    {
        goldText.text =
            "cristais de mana: " +
            BattleData.gold;
    }
}