using System.Collections.Generic;
using UnityEngine;

public class BattleSpawner : MonoBehaviour
{
    [Header("Player Spawns")]
    public List<Transform> playerSpawns =
        new List<Transform>();

    [Header("Enemy Spawns")]
    public List<Transform> enemySpawns =
        new List<Transform>();

    [HideInInspector]
    public List<BattleUnit> playerUnits =
        new List<BattleUnit>();

    [HideInInspector]
    public List<BattleUnit> enemyUnits =
        new List<BattleUnit>();

    void Awake()
    {
        SpawnPlayers();
        SpawnEnemies();
    }

    void SpawnPlayers()
    {
        playerUnits.Clear();

        if (BattleData.playerParty == null)
        {
            Debug.LogError(
                "playerParty NULL");

            return;
        }

        int amount =
            Mathf.Min(
                BattleData.playerParty.Count,
                playerSpawns.Count);

        for (int i = 0; i < amount; i++)
        {
            if (BattleData.playerParty[i] == null)
                continue;

            GameObject obj =
                Instantiate(
                    BattleData.playerParty[i],
                    playerSpawns[i].position,
                    Quaternion.identity);

            BattleUnit unit =
     obj.GetComponent<BattleUnit>();

            if (unit != null)
            {
                unit.Initialize();
                playerUnits.Add(unit);
            }
        }

        Debug.Log(
            "Players spawnados: "
            + playerUnits.Count);
    }

    void SpawnEnemies()
    {
        enemyUnits.Clear();

        if (BattleData.enemyPrefabs == null)
        {
            Debug.LogError(
                "enemyPrefabs NULL");

            return;
        }

        int amount =
            Mathf.Min(
                BattleData.enemyPrefabs.Count,
                enemySpawns.Count);

        for (int i = 0; i < amount; i++)
        {
            if (BattleData.enemyPrefabs[i] == null)
                continue;

            GameObject obj =
                Instantiate(
                    BattleData.enemyPrefabs[i],
                    enemySpawns[i].position,
                    Quaternion.identity);

            EnemyStats stats =
                obj.GetComponent<EnemyStats>();

            if (stats != null)
            {
                stats.GenerateStats();
            }

            BattleUnit unit =
    obj.GetComponent<BattleUnit>();

            if (unit != null)
            {
                unit.Initialize();
                enemyUnits.Add(unit);
            }
        }

        Debug.Log(
            "Enemies spawnados: "
            + enemyUnits.Count);
    }
}