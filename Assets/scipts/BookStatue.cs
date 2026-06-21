using System.Collections;
using UnityEngine;

public class BookStatue : MonoBehaviour
{


    [Header("Boss")]
    public EnemyController finalBoss;

    [Header("Cutscene")]

    public Texture cutsceneImage;

    [TextArea]
    public string[] cutsceneLines;


    [TextArea]
    public string cutsceneText;



    public void ActivateStatue(Transform player)
    {

        Debug.Log("Todos os artefatos encontrados!");

        StartFinalSequence(player);
    }

    private void StartFinalSequence(Transform player)
    {
        Debug.Log("StartFinalSequence chamado");

        if (BossCutsceneController.Instance == null)
        {
            Debug.LogError("BossCutsceneController não encontrado!");
            return;
        }

        BossCutsceneController.Instance.StartCutscene(
            cutsceneImage,
            cutsceneLines,
            () =>
            {
                Debug.Log("Cutscene terminou");
                finalBoss.StartBattle(true, player);
            });
    }
}