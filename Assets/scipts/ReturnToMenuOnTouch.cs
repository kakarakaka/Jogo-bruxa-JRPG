using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuOnTouch : MonoBehaviour
{
    [Header("Nome da cena do menu")]
    public string menuSceneName = "menu principal";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}