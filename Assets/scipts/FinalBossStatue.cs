using System.Collections;
using UnityEngine;

public class FinalBossStatue : MonoBehaviour
{
    [Header("Itens Necessários")]
    public ItemData item1;
    public ItemData item2;
    public ItemData item3;
    public ItemData item4;
    public ItemData item5;

    [Header("Boss")]
    public EnemyController finalBoss;

    [Header("Cutscene")]

    public Texture cutsceneImage;

    [TextArea]
    public string[] cutsceneLines;


    [TextArea]
    public string cutsceneText;

    public bool HasAllItems()
    {
        return
            Inventory.Instance.GetQuantity(item1) > 0 &&
            Inventory.Instance.GetQuantity(item2) > 0 &&
            Inventory.Instance.GetQuantity(item3) > 0 &&
            Inventory.Instance.GetQuantity(item4) > 0 &&
            Inventory.Instance.GetQuantity(item5) > 0;
    }

    public void ActivateStatue(Transform player)
    {
        if (!HasAllItems())
        {
            Debug.Log("Faltam artefatos.");
            return;
        }

        Debug.Log("Todos os artefatos encontrados!");

        StartFinalSequence(player);
    }

    private void StartFinalSequence(
    Transform player)
    {
        Debug.Log("Iniciando sequência final");

        Debug.Log(
            "BossCutsceneController = "
            + BossCutsceneController.Instance);

        BossCutsceneController.Instance
            .StartCutscene(
                cutsceneImage,
                cutsceneLines,
                () =>
                {
                    finalBoss.StartBattle(
                        true,
                        player);
                });
    }
}