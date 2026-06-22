using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossEndingSceneController : MonoBehaviour
{
    public EndingCutsceneController cutscene;

    [Header("Cutscenes")]
    public Texture normalImage;
    public string[] normalLines;

    public Texture secretImage;
    public string[] secretLines;

    [Header("Item necessário")]
    public ItemData guardianBook;

    void Start()
    {
        bool hasBook =
            Inventory.Instance != null &&
            Inventory.Instance.GetQuantity(guardianBook) > 0;

        if (hasBook)
        {
            PlaySecretEnding();
        }
        else
        {
            PlayNormalEnding();
        }
    }

    void PlayNormalEnding()
    {
        Debug.Log("TOCANDO FINAL NORMAL");

        cutscene.StartCutscene(
            normalImage,
            normalLines,
            ReturnToMenu);
    }

    void PlaySecretEnding()
    {
        BattleData.gameFinished = true;
        BattleData.endingCutsceneActive = true;

        Debug.Log("TOCANDO FINAL SECRETO");

        cutscene.StartCutscene(
            secretImage,
            secretLines,
            ReturnToMenu);
    }

    void ReturnToMenu()
    {
        Debug.Log("RETORNANDO PARA MENU PRINCIPAL");
        SceneManager.LoadScene("menu principal");
    }
}