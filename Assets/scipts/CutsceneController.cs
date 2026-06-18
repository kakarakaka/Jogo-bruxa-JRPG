using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneController : MonoBehaviour
{
    public TMP_Text dialogueText;

    [TextArea]
    public string[] dialogueLines;

    private int currentLine = 0;

    void Start()
    {
        if (dialogueLines.Length > 0)
        {
            dialogueText.text =
                dialogueLines[0];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine >= dialogueLines.Length)
        {
            StartGame();

            return;
        }

        dialogueText.text =
            dialogueLines[currentLine];
    }

    void StartGame()
    {
        BattleData.playerPosition =
            new Vector3(0f, 40f, 0f);

        BattleData.playerRotation =
            Quaternion.identity;

        SceneManager.LoadScene(
    BattleData.returnScene);
    }
}