using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonExit : MonoBehaviour
{
    public string sceneName = "Mapa";

    public void ExitDungeon()
    {
        Debug.Log(
            "SAINDO DA DUNGEON PARA: "
            + BattleData.dungeonReturnPosition);

        BattleData.playerPosition =
            BattleData.dungeonReturnPosition;

        BattleData.playerRotation =
            BattleData.dungeonReturnRotation;

        SceneManager.LoadScene(sceneName);
    }
}