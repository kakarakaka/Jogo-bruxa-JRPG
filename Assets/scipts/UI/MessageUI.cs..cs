using System.Collections;
using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance;

    public GameObject panel;
    public TextMeshProUGUI messageText;

    private Coroutine currentRoutine;

    private void Awake()
    {
        Instance = this;

        panel.SetActive(false);
    }

    public void ShowMessage(string message, float duration = 3f)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(
            ShowRoutine(message, duration));
    }

    IEnumerator ShowRoutine(string message, float duration)
    {
        messageText.text = message;

        panel.SetActive(true);

        yield return new WaitForSeconds(duration);

        panel.SetActive(false);
    }
}