using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    public GameObject[] characters;

    public ThirdPersonCamera cameraController;

    private int currentCharacterIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Desativa todos
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        // Ativa primeiro personagem
        characters[0].SetActive(true);

        cameraController.target = characters[0].transform;
    }

    public void SelectCharacter(int index)
    {
        if (index == currentCharacterIndex)
            return;

        if (index < 0 || index >= characters.Length)
            return;

        GameObject currentCharacter =
            characters[currentCharacterIndex];

        // SALVA POSIÇÃO E ROTAÇÃO
        Vector3 oldPosition =
            currentCharacter.transform.position;

        Quaternion oldRotation =
            currentCharacter.transform.rotation;

        // DESATIVA PERSONAGEM ATUAL
        currentCharacter.SetActive(false);

        // NOVO PERSONAGEM
        GameObject newCharacter =
            characters[index];

        // MOVE NOVO PERSONAGEM
        newCharacter.transform.position = oldPosition;
        newCharacter.transform.rotation = oldRotation;

        // ATIVA NOVO PERSONAGEM
        newCharacter.SetActive(true);

        // CÂMERA
        cameraController.target =
            newCharacter.transform;

        currentCharacterIndex = index;

        Debug.Log("Personagem atual: " +
                  newCharacter.name);
    }
}