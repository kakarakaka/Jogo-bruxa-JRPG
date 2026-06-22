using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Collectible", menuName = "Game/Collectible")]
public class CollectibleData : ScriptableObject
{
    public string id;
    public string collectibleName;
    [TextArea(3, 10)]
    public string description;
    public Texture2D icon;
}