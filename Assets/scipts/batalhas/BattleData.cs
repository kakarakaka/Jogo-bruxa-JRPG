using System.Collections.Generic;
using UnityEngine;


public static class BattleData
{
    public static bool firstGameStart = true;

    public static Vector3 playerPosition;

    public static Quaternion playerRotation;

    // =========================
    // PARTY
    // =========================

    public static List<GameObject>
        playerParty =
        new List<GameObject>();

    // =========================
    // ENEMIES
    // =========================

    public static List<GameObject>
        enemyPrefabs =
        new List<GameObject>();

    // =========================
    // AMBUSH
    // =========================

    public static bool playerAmbush;

    public static bool enemyAmbush;

    // =========================
    // HP / MP PERSISTENTE
    // =========================

    public static Dictionary<string, int>
        savedHP =
        new Dictionary<string, int>();

    public static Dictionary<string, int>
        savedMP =
        new Dictionary<string, int>();

    // =========================
    // INIMIGO DA BATALHA
    // =========================

    public static string currentEnemyID;

    // =========================
    // INIMIGOS DERROTADOS
    // =========================

    public static HashSet<string>
        defeatedEnemies =
        new HashSet<string>();

    // =========================
    // DINHEIRO
    // =========================

    public static int gold = 999999999;

}