using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneController : MonoBehaviour
{
    public Texture normalImage;
    public string[] normalLines;

    public Texture secretImage;
    public string[] secretLines;

    public string bookItemName = "Livro do guardião da caverna";

    void Start()
    {
        PlayEnding();
    }

    void PlayEnding()
    {
        bool hasBook = false;

        if (Inventory.Instance != null)
        {
            foreach (var slot in Inventory.Instance.items)
            {
                if (slot.item != null &&
                    slot.item.itemName == bookItemName)
                {
                    hasBook = true;
                    break;
                }
            }
        }

        if (hasBook)
        {
            EndingCutsceneController.Instance.StartCutscene(
                secretImage,
                secretLines,
                GoToMenu
            );
        }
        else
        {
            EndingCutsceneController.Instance.StartCutscene(
                normalImage,
                normalLines,
                GoToMenu
            );
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("menu principal");
    }
}