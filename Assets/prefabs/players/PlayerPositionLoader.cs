using UnityEngine;

public class PlayerPositionLoader : MonoBehaviour
{
    void Start()
    {
        transform.position =
            BattleData.playerPosition;

        transform.rotation =
            BattleData.playerRotation;
    }
}