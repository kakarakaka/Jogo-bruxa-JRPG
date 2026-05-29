using UnityEngine;

public class StatusEffectManager
{
    public static void ApplyEffect(
        BattleUnit target,
        Skill skill)
    {
        if (skill.effectType ==
            StatusEffectType.None)
        {
            return;
        }

        ActiveStatusEffect effect =
            new ActiveStatusEffect();

        effect.effectType =
            skill.effectType;

        effect.power =
            skill.effectPower;

        effect.remainingTurns =
            skill.effectDuration;

        target.activeEffects.Add(effect);

        Debug.Log(
            target.UnitName +
            " recebeu efeito: " +
            skill.effectType);
    }

    public static void ProcessEffects(
        BattleUnit unit)
    {
        for (int i =
            unit.activeEffects.Count - 1;
            i >= 0;
            i--)
        {
            ActiveStatusEffect effect =
                unit.activeEffects[i];

            switch (effect.effectType)
            {
                case StatusEffectType.Poison:

                    unit.TakeDamage(
                        effect.power);

                    break;
            }

            effect.remainingTurns--;

            if (effect.remainingTurns <= 0)
            {
                unit.activeEffects
                    .RemoveAt(i);
            }
        }
    }
}