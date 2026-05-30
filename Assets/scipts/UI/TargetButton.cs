using UnityEngine;

public class TargetButton :
    MonoBehaviour
{
    public BattleUnit target;

    BattleSystem battleSystem;

    void Start()
    {
        battleSystem =
            FindFirstObjectByType
            <BattleSystem>();
    }

    public void OnClick()
    {
        if (target == null)
            return;

        battleSystem
            .UseSkillOnTarget(target);
    }
}