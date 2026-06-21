using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public static class BattleData
{
    public static bool firstGameStart = true;

    // =========================
    // POSIÇÃO DO PLAYER
    // =========================

    public static Vector3 playerPosition;
    public static Quaternion playerRotation;

    // posição salva antes da batalha
    public static Vector3 lastWorldPosition;
    public static Quaternion lastWorldRotation;

    // posição da entrada da dungeon
    public static Vector3 dungeonReturnPosition;
    public static Quaternion dungeonReturnRotation;

    // identifica se o player está no mapa ou dungeon
    public static string lastWorldType = "mapa";

    // cena para retornar após batalha
    public static string returnScene;

    public static int encounterLevel;

    public static List<ItemData>
    pendingBossDrops =
    new List<ItemData>();

    public static Dictionary<string, List<Skill>> savedSkills
    = new Dictionary<string, List<Skill>>();

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