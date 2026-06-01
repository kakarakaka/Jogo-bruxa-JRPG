using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject characterPanel;

    public GameObject statusPanel;

    public GameObject skillsPanel;

    public GameObject mainButtons;

    public GameObject itemsPanel;
    

    private bool paused = false;

    void Start()
    {
        itemsPanel.SetActive(false);

        pauseMenuUI.SetActive(false);

        characterPanel.SetActive(false);

        statusPanel.SetActive(false);

        skillsPanel.SetActive(false);
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

    // PERSONAGENS
    public void OpenCharacters()
    {
        mainButtons.SetActive(false);

        characterPanel.SetActive(true);
    }

    public void CloseCharacters()
    {
        characterPanel.SetActive(false);

        mainButtons.SetActive(true);
    }

    // STATUS
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

    // GOLPES
    public void OpenSkills()
    {
        mainButtons.SetActive(false);

        skillsPanel.SetActive(true);
    }

    public void CloseSkills()
    {
        skillsPanel.SetActive(false);

        mainButtons.SetActive(true);
    }

    public void SelectCharacter(int index)
    {
        CharacterManager.Instance.SelectCharacter(index);

        Resume();
    }

    public void OpenItems()
    {
        mainButtons.SetActive(false);

        itemsPanel.SetActive(true);
    }

    public void CloseItems()
    {
        itemsPanel.SetActive(false);

        mainButtons.SetActive(true);
    }


}