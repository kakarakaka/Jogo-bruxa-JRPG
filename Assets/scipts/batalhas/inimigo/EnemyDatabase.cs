using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase :
    MonoBehaviour
{
    public static EnemyDatabase Instance;

    [Header("Enemy Prefabs")]
    public List<GameObject>
        enemyPrefabs =
        new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetRandomEnemy()
    {
        int random =
            Random.Range(
                0,
                enemyPrefabs.Count);

        return enemyPrefabs[random];
    }
}