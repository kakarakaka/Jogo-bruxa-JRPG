using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyEncounterData
{
    [Header("Level")]
    public int minLevel = 1;
    public int maxLevel = 5;

    [Header("Possíveis inimigos")]
    public int minEnemies = 1;
    public int maxEnemies = 4;
    public List<GameObject> possibleEnemies =
        new List<GameObject>();
}