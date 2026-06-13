using UnityEngine;

public class PlayerInteraction :
    MonoBehaviour
{
    public float interactDistance =
        3f;

    void Update()
    {
        if (Input.GetKeyDown(
            KeyCode.E))
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

            EnemyController enemy =
                hit.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.StartBattle(
    true,
    transform);

                return;
            }
            GameObject player =
    GameObject.FindGameObjectWithTag("Player");

          
        }
    }
}