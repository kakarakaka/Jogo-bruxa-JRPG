using UnityEngine;

public class FinalBossEnding : MonoBehaviour
{
    [Header("Livro Especial")]
    public ItemData guardianBook;

    [Header("Cutscene Normal")]
    public Texture normalImage;

    [TextArea]
    public string[] normalLines;

    [Header("Cutscene Secreta")]
    public Texture secretImage;

    [TextArea]
    public string[] secretLines;
}