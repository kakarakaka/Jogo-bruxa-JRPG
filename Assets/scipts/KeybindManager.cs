using UnityEngine;
using UnityEngine.InputSystem;

public class KeybindManager : MonoBehaviour
{
    [Header("Personagens")]
    public PlayerMovement[] players;

    private KeybindButton currentButton;

    public void StartRebind(KeybindButton button)
    {
        currentButton = button;

        StartCoroutine(WaitForKey());
    }

    System.Collections.IEnumerator WaitForKey()
    {
        while (true)
        {
            foreach (Key key in System.Enum.GetValues(typeof(Key)))
            {
                if (key == Key.None)
                    continue;

                try
                {
                    if (Keyboard.current[key].wasPressedThisFrame)
                    {
                        ApplyKeyToAll(key);

                        yield break;
                    }
                }
                catch
                {
                    continue;
                }
            }

            yield return null;
        }
    }

    void ApplyKeyToAll(Key key)
    {
        foreach (PlayerMovement player in players)
        {
            if (player == null)
                continue;

            switch (currentButton.keyType)
            {
                case KeyType.Forward:
                    player.moveForwardKey = key;
                    break;

                case KeyType.Backward:
                    player.moveBackwardKey = key;
                    break;

                case KeyType.Left:
                    player.moveLeftKey = key;
                    break;

                case KeyType.Right:
                    player.moveRightKey = key;
                    break;

                case KeyType.Jump:
                    player.jumpKey = key;
                    break;

                case KeyType.Run:
                    player.runKey = key;
                    break;
            }
        }

        if (currentButton != null)
        {
            currentButton.UpdateText(
                key.ToString());
        }
    }
}