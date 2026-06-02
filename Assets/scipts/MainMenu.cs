using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("cutscene inicial");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}