using UnityEngine;

public enum SkillType
{
    Physical,
    Special,
    Status
}

public enum StatusEffectType
{
    None,

    Poison,

    Burn,

    Sleep,

    Slow,

    AttackUp,

    DefenseUp
}

[System.Serializable]
public class Skill
{
    [Header("Info")]
    public string skillName;

    [TextArea]
    public string description;

    [Header("Battle")]
    public SkillType skillType;

    public int damage;

    public int mpCost;

    [Header("Status Effect")]
    public StatusEffectType effectType;

    public int effectPower;

    public int effectDuration;

    [Header("Equip")]
    public bool equipped;
}