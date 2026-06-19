using UnityEngine;
using System.Collections;

public class PlayerPositionLoader : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(
            "PlayerPositionLoader Awake -> "
            + gameObject.name);
    }

    IEnumerator Start()
    {
        yield return null;

        Debug.Log(
            "Aplicando posição em -> "
            + gameObject.name);

        Debug.Log(
            "Posição salva -> "
            + BattleData.playerPosition);

        transform.position =
            BattleData.playerPosition;

        transform.rotation =
            BattleData.playerRotation;
    }
}