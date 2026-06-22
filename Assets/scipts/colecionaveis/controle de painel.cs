using UnityEngine;

public class controledepainel : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        panel.SetActive(true);
    }

    public void CloseMenu()
    {
        panel.SetActive(false);
    }
}