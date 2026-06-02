using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public TextMeshProUGUI partyStatusText;

    public BattleUnit[] partyMembers;

    public GameObject pauseMenuUI;

    public GameObject characterPanel;

    public GameObject statusPanel;

    public GameObject skillsPanel;

    public GameObject mainButtons;

    public GameObject itemsPanel;

    public GameObject settingsPanel;


    private bool paused = false;

    void Start()
    {
        itemsPanel.SetActive(false);

        pauseMenuUI.SetActive(false);

        characterPanel.SetActive(false);

        statusPanel.SetActive(false);

        skillsPanel.SetActive(false);

        settingsPanel.SetActive(false);
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
        UpdatePartyStatus();

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

    void UpdatePartyStatus()
    {
        if (partyStatusText == null)
            return;

        string info = "";

        foreach (BattleUnit unit
                 in partyMembers)
        {
            if (unit == null)
                continue;

            info +=
                unit.UnitName +
                "   HP " +
                unit.currentHP +
                "/" +
                unit.MaxHP +
                "   MP " +
                unit.currentMP +
                "/" +
                unit.MaxMP +
                "\n";
        }

        partyStatusText.text = info;
    }

    public void OpenSettings()
    {
        mainButtons.SetActive(false);

        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);

        mainButtons.SetActive(true);
    }

}