using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Skill ChooseSkill(
        BattleUnit enemy)
    {
        int randomIndex =
            Random.Range(
                0,
                enemy.EquippedSkills.Count);

        return enemy.EquippedSkills[
            randomIndex];
    }
}