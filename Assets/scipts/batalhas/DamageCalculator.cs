using UnityEngine;

public class DamageCalculator
{
    public static int CalculateDamage(
        BattleUnit attacker,
        BattleUnit target,
        Skill skill)
    {
        int finalDamage = 0;

        switch (skill.skillType)
        {
            case SkillType.Physical:

                finalDamage =
                    skill.damage +
                    attacker.Attack;

                break;

            case SkillType.Special:

                finalDamage =
                    skill.damage +
                    attacker.SpecialAttack;

                break;
        }

        finalDamage -= target.Defense;

        finalDamage =
            Mathf.Max(1, finalDamage);

        return finalDamage;
    }
}