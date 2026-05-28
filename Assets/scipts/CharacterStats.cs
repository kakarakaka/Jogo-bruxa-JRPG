using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Informações")]
    public string characterName;

    [Header("Status")]
    public int level = 1;

    public int maxHP = 100;
    public int maxMP = 50;

    public int attack = 10;
    public int specialAttack = 15;

    public int speed = 8;
}