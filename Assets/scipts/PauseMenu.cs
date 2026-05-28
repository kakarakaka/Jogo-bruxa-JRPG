using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject characterPanel;
    public GameObject mainButtons;
    public GameObject statusPanel;

    private bool paused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        characterPanel.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        paused = true;
    }

    public void OpenCharacters()
    {
        if (characterPanel != null)
        {
            mainButtons.SetActive(false);
            characterPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("CharacterPanel não foi atribuído!");
        }
    }

    public void CloseCharacters()
    {
        characterPanel.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void OpenStatus()
    {
        mainButtons.SetActive(false);

        statusPanel.SetActive(true);
    }

    public void CloseStatus()
    {
        statusPanel.SetActive(false);

        mainButtons.SetActive(true);
    }

    public void SelectCharacter(int index)
    {
        CharacterManager.Instance.SelectCharacter(index);

        Resume();
    }
}