using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleLogUI : MonoBehaviour
{
    public TextMeshProUGUI logText;

    public float autoAdvanceTime = 2f;

    Queue<string> messages =
        new Queue<string>();

    bool showingMessage;

    public bool IsShowingMessage
    {
        get
        {
            return showingMessage;
        }
    }

    public void Write(string message)
    {
        messages.Enqueue(message);

        if (!showingMessage)
        {
            StartCoroutine(
                ShowMessages());
        }
    }

    IEnumerator ShowMessages()
    {
        showingMessage = true;

        while (messages.Count > 0)
        {
            logText.text =
                messages.Dequeue();

            float timer = 0f;

            while (timer <
                   autoAdvanceTime)
            {
                timer +=
                    Time.deltaTime;

                if (Input.GetMouseButtonDown(0))
                {
                    break;
                }

                yield return null;
            }
        }

        showingMessage = false;
    }
}