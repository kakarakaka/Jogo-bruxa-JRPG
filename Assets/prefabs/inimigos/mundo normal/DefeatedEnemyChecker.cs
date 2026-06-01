using UnityEngine;

public class DefeatedEnemyChecker :
    MonoBehaviour
{
    void Start()
    {
        EnemyController controller =
            GetComponent<EnemyController>();

        if (controller == null)
            return;

        if (BattleData.defeatedEnemies
            .Contains(controller.enemyID))
        {
            Destroy(gameObject);
        }
    }
}