using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu Principal");
    }
}
