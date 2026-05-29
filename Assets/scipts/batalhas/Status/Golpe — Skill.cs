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

    AttackUp,
    DefenseUp,
    SpeedUp,

    AttackDown,
    DefenseDown,
    SpeedDown,

    Poison,
    Burn,
    Paralysis
}

[System.Serializable]
public class Skill
{
    [Header("Info")]
    public string skillName;

    [TextArea]
    public string description;

    [Header("Tipo")]
    public SkillType skillType;

    [Header("Dano")]
    public int damage;

    [Header("Status")]
    public StatusEffectType effectType;

    public int effectPower;

    public int effectDuration;

    [Header("Equip")]
    public bool equipped;
}