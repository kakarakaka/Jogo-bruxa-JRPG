using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController :
    MonoBehaviour
{
    [Header("Save")]
    public string enemyID;

    [Header("Vision")]
    public float viewDistance = 10f;

    public float viewAngle = 90f;

    [Header("Movement")]
    public float patrolRadius = 10f;

    public float patrolSpeed = 2f;

    public float chaseSpeed = 6f;

    private Transform player;

    private NavMeshAgent agent;

    private bool playerVisible;

    private Vector3 patrolPoint;

    void Start()
    {
        player =
            GameObject
            .FindGameObjectWithTag(
                "Player")
            .transform;

        agent =
            GetComponent<NavMeshAgent>();

        PickPatrolPoint();
    }

    void Update()
    {
        CheckVision();

        if (playerVisible)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    // =====================
    // FIELD OF VIEW
    // =====================

    void CheckVision()
    {
        Vector3 dirToPlayer =
            player.position -
            transform.position;

        float distance =
            dirToPlayer.magnitude;

        if (distance > viewDistance)
        {
            playerVisible = false;
            return;
        }

        float angle =
            Vector3.Angle(
                transform.forward,
                dirToPlayer);

        if (angle < viewAngle / 2)
        {
            RaycastHit hit;

            if (Physics.Raycast(
                transform.position +
                Vector3.up,
                dirToPlayer.normalized,
                out hit,
                viewDistance))
            {
                if (hit.transform
                    .CompareTag(
                        "Player"))
                {
                    playerVisible = true;
                    return;
                }
            }
        }

        playerVisible = false;
    }

    // =====================
    // PATROL
    // =====================

    void Patrol()
    {
        agent.speed =
            patrolSpeed;

        agent.SetDestination(
            patrolPoint);

        float distance =
            Vector3.Distance(
                transform.position,
                patrolPoint);

        if (distance < 2f)
        {
            PickPatrolPoint();
        }
    }

    void PickPatrolPoint()
    {
        Vector3 randomPos =
            transform.position +
            Random.insideUnitSphere
            * patrolRadius;

        randomPos.y =
            transform.position.y;

        patrolPoint =
            randomPos;
    }

    // =====================
    // CHASE
    // =====================

    void ChasePlayer()
    {
        agent.speed =
            chaseSpeed;

        agent.SetDestination(
            player.position);
    }

    // =====================
    // BATTLE
    // =====================

    void OnTriggerEnter(
        Collider other)
    {
        if (other.CompareTag(
            "Player"))
        {
            StartBattle(false);
        }
    }

    public void StartBattle(
     bool playerStarted)
    {
        Debug.Log("StartBattle");

        Debug.Log(
            "PartyManager: "
            + PartyManager.Instance);

        Debug.Log(
            "EnemyDatabase: "
            + EnemyDatabase.Instance);

        Debug.Log(
            "Player: "
            + player);

        // PARTY
        BattleData.playerParty =
            PartyManager
            .Instance
            .currentParty;

        // quantidade aleatória
        int enemyCount =
            Random.Range(1, 5);

        BattleData.enemyPrefabs.Clear();

        // gera inimigos
        for (int i = 0;
            i < enemyCount;
            i++)
        {
            GameObject enemy =
                EnemyDatabase
                .Instance
                .GetRandomEnemy();

            BattleData.enemyPrefabs
                .Add(enemy);
        }

        BattleUnit playerUnit =
            player.GetComponent
            <BattleUnit>();

        BattleUnit enemyUnit =
            GetComponent
            <BattleUnit>();

        // iniciativa
        if (playerStarted)
        {
            if (!playerVisible)
            {
                BattleData.playerAmbush =
                    true;

                BattleData.enemyAmbush =
                    false;
            }
            else
            {
                BattleData.playerAmbush =
                    playerUnit.Speed >
                    enemyUnit.Speed;

                BattleData.enemyAmbush =
                    enemyUnit.Speed >
                    playerUnit.Speed;
            }
        }
        else
        {
            BattleData.playerAmbush =
                false;

            BattleData.enemyAmbush =
                true;
        }

        BattleData.currentEnemyID =
    enemyID;

        BattleData.playerPosition =
    player.position;

        BattleData.playerRotation =
            player.rotation;

        Debug.Log(
    "Salvando posição: "
    + player.position);

        SceneManager.LoadScene(
            "BattleScene");

       
    }


}