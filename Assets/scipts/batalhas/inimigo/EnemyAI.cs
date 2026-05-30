using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Skill ChooseSkill(
        BattleUnit enemy)
    {
        if (enemy == null)
            return null;

        if (enemy.EquippedSkills == null)
            return null;

        if (enemy.EquippedSkills.Count == 0)
        {
            Debug.LogError(
                enemy.UnitName +
                " não possui skills.");

            return null;
        }

        int randomIndex =
            Random.Range(
                0,
                enemy.EquippedSkills.Count);

        return enemy.EquippedSkills[
            randomIndex];
    }
}