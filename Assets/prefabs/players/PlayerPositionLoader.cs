using UnityEngine;
using System.Collections;

public class PlayerPositionLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null;

        transform.position =
            BattleData.playerPosition;

        transform.rotation =
            BattleData.playerRotation;
    }
}