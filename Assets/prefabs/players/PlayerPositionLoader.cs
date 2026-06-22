using UnityEngine;
using System.Collections;

public class PlayerPositionLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null;

        if (BattleData.gameFinished)
        {
            yield break; 
        }

        Debug.Log("POSIÇÃO CARREGADA: " + BattleData.playerPosition);
        Debug.Log("ROTAÇÃO CARREGADA: " + BattleData.playerRotation);

        transform.position = BattleData.playerPosition;
        transform.rotation = BattleData.playerRotation;
    }
}