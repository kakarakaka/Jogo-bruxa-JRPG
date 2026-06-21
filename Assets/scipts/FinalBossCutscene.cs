using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossCutscene : MonoBehaviour
{
    public static FinalBossCutscene Instance;

    [Header("UI")]
    public GameObject panel;

    public RawImage image;

    public TextMeshProUGUI dialogueText;

    private void Awake()
    {
        Instance = this;

        panel.SetActive(false);
    }

    public IEnumerator PlayCutscene(
     Texture cutsceneImage,
     string text)
    {
        panel.SetActive(true);

        image.texture = cutsceneImage;

        dialogueText.text = text;

        yield return new WaitUntil(
            () => Input.GetKeyDown(KeyCode.Space));

        panel.SetActive(false);
    }
}