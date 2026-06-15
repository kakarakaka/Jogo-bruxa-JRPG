using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossCutscene : MonoBehaviour
{
    public static FinalBossCutscene Instance;

    [Header("UI")]
    public GameObject panel;

    public Image image;

    public TextMeshProUGUI dialogueText;

    private void Awake()
    {
        Instance = this;

        panel.SetActive(false);
    }

    public IEnumerator PlayCutscene(
        Sprite cutsceneImage,
        string text)
    {
        panel.SetActive(true);

        image.sprite = cutsceneImage;

        dialogueText.text = text;

        yield return new WaitUntil(
            () => Input.GetKeyDown(KeyCode.Space));

        panel.SetActive(false);
    }
}