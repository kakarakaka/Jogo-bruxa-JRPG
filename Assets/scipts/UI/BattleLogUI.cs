using TMPro;
using UnityEngine;

public class BattleLogUI : MonoBehaviour
{
    public TextMeshProUGUI logText;

    [Header("Config")]
    public int maxLines = 15;

    public void Write(string message)
    {
        if (logText == null)
            return;

        if (string.IsNullOrEmpty(logText.text))
        {
            logText.text = message;
        }
        else
        {
            logText.text += "\n\n" + message;
        }

        string[] lines =
            logText.text.Split('\n');

        if (lines.Length > maxLines)
        {
            int start =
                lines.Length - maxLines;

            logText.text =
                string.Join(
                    "\n",
                    lines,
                    start,
                    maxLines);
        }
    }

    public void ClearLog()
    {
        if (logText != null)
        {
            logText.text = "";
        }
    }
}