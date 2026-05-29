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
            TryStartBattle();
        }
    }

    void TryStartBattle()
    {
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                interactDistance);

        foreach (Collider hit in hits)
        {
            EnemyController enemy =
                hit.GetComponent
                <EnemyController>();

            if (enemy != null)
            {
                enemy.StartBattle(true);

                return;
            }
        }
    }
}