using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonEntrance : MonoBehaviour
{
    public string sceneName = "dungeon";

    public void EnterDungeon()
    {
        Transform player =
            GameObject.FindGameObjectWithTag(
                "Player").transform;

        BattleData.dungeonReturnPosition =
            player.position;

        BattleData.dungeonReturnRotation =
            player.rotation;

        SceneManager.LoadScene(sceneName);
    }
}