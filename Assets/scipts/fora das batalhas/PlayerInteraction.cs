using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteraction();
        }
    }

    void TryInteraction()
    {
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                interactDistance);

        foreach (Collider hit in hits)
        {
            ShopTrigger shop =
                hit.GetComponent<ShopTrigger>();

            if (shop != null)
            {
                shop.OpenShop();
                return;
            }

            FinalBossStatue statue =
                hit.GetComponent<FinalBossStatue>();

            if (statue != null)
            {
                statue.ActivateStatue(transform);
                return;
            }

            BossCutsceneTrigger bossTrigger =
                hit.GetComponent<BossCutsceneTrigger>();

            if (bossTrigger != null)
            {
                bossTrigger.ActivateBoss(transform);
                return;
            }

            EnemyController enemy =
                hit.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.StartBattle(
                    true,
                    transform);

                return;
            }

            DungeonEntrance dungeon =
                hit.GetComponent<DungeonEntrance>();

            if (dungeon != null)
            {
                dungeon.EnterDungeon();
                return;
            }

            DungeonExit exit =
                hit.GetComponent<DungeonExit>();

            if (exit != null)
            {
                exit.ExitDungeon();
                return;
            }
        }
    }
}