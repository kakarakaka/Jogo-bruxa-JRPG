using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BossCutsceneController : MonoBehaviour
{
    public static BossCutsceneController Instance;

    public GameObject panel;

    public TMP_Text dialogueText;

    public RawImage cutsceneImage;

    private string[] currentLines;

    private int currentLine;

    private Action onFinished;

    void Awake()
    {
        Instance = this;

        panel.SetActive(false);
    }

    void Update()
    {
        if (panel.activeSelf &&
            Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }


    public void StartCutscene(
       Texture image,
       string[] lines,
       Action finishCallback)
    {
        Debug.Log(
            "Texto recebido: "
            + lines[0]);

        panel.SetActive(true);

        cutsceneImage.texture = image;

        currentLines = lines;

        currentLine = 0;

        onFinished = finishCallback;

        dialogueText.text =
            currentLines[0];

        Debug.Log(
            "BossCutscene definiu texto: "
            + dialogueText.text);
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine >= currentLines.Length)
        {
            panel.SetActive(false);

            onFinished?.Invoke();

            return;
        }

        dialogueText.text =
            currentLines[currentLine];
    }
}