using UnityEngine;

[System.Serializable]
public class Skill
{
    public string skillName;

    [TextArea]
    public string description;

    public int damage;

    public string type;

    public bool equipped;
}