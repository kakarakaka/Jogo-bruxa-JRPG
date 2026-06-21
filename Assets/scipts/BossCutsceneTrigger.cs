using UnityEngine;

public class BossCutsceneTrigger : MonoBehaviour
{
    [Header("Boss")]
    public EnemyController boss;

    [Header("Cutscene")]
    public Texture cutsceneImage;

    [TextArea]
    public string[] cutsceneLines;

    private bool activated = false;

    public void ActivateBoss(Transform player)
    {
        if (activated)
            return;

        activated = true;

        BossCutsceneController.Instance.StartCutscene(
            cutsceneImage,
            cutsceneLines,
            () =>
            {
                boss.StartBattle(
                    true,
                    player);
            });
    }
}