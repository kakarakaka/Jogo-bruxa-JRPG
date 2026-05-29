using System.Collections.Generic;
using UnityEngine;

public static class BattleData
{
    // PARTY DO PLAYER
    public static List<GameObject>
        playerParty =
        new List<GameObject>();

    // INIMIGOS DA BATALHA
    public static List<GameObject>
        enemyPrefabs =
        new List<GameObject>();

    // INICIATIVA
    public static bool playerAmbush;

    public static bool enemyAmbush;
}