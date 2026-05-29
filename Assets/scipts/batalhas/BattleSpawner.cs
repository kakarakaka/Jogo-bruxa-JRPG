using System.Collections.Generic;
using UnityEngine;

public class BattleSpawner :
    MonoBehaviour
{
    [Header("Player Spawns")]
    public List<Transform>
        playerSpawns =
        new List<Transform>();

    [Header("Enemy Spawns")]
    public List<Transform>
        enemySpawns =
        new List<Transform>();

    [HideInInspector]
    public List<BattleUnit>
        playerUnits =
        new List<BattleUnit>();

    [HideInInspector]
    public List<BattleUnit>
        enemyUnits =
        new List<BattleUnit>();

    void Awake()
    {
        SpawnPlayers();

        SpawnEnemies();
    }

    // =========================
    // PLAYERS
    // =========================

    void SpawnPlayers()
    {
        for (int i = 0;
            i < BattleData
            .playerParty.Count;
            i++)
        {
            GameObject obj =
                Instantiate(
                    BattleData
                    .playerParty[i],
                    playerSpawns[i]
                    .position,
                    Quaternion.identity);

            BattleUnit unit =
                obj.GetComponent
                <BattleUnit>();

            playerUnits.Add(unit);
        }
    }

    // =========================
    // ENEMIES
    // =========================

    void SpawnEnemies()
    {
        for (int i = 0;
            i < BattleData
            .enemyPrefabs.Count;
            i++)
        {
            GameObject obj =
                Instantiate(
                    BattleData
                    .enemyPrefabs[i],
                    enemySpawns[i]
                    .position,
                    Quaternion.identity);

            EnemyStats stats =
                obj.GetComponent
                <EnemyStats>();

            stats.GenerateStats();

            BattleUnit unit =
                obj.GetComponent
                <BattleUnit>();

            enemyUnits.Add(unit);
        }
    }
}