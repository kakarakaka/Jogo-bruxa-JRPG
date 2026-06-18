using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonExit : MonoBehaviour
{
    public string sceneName = "Mapa";

    public void ExitDungeon()
    {
        BattleData.playerPosition =
            BattleData.dungeonReturnPosition;

        BattleData.playerRotation =
            BattleData.dungeonReturnRotation;

        SceneManager.LoadScene(sceneName);
    }
}