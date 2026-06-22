using UnityEngine;

public class GameUtilities : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Fechando jogo...");

        Application.Quit();
    }
}