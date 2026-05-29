using System.Collections.Generic;
using UnityEngine;

public class TurnManager :
    MonoBehaviour
{
    [Header("Units")]
    public List<BattleUnit>
        units =
        new List<BattleUnit>();

    private Queue<BattleUnit>
        turnQueue =
        new Queue<BattleUnit>();

    // =========================
    // GERA TURNOS
    // =========================

    public void GenerateTurnOrder()
    {
        turnQueue.Clear();

        if (units.Count <= 0)
        {
            Debug.LogError(
                "Nenhuma unidade!");

            return;
        }

        foreach (BattleUnit unit in units)
        {
            int turns =
                Mathf.Max(
                    1,
                    Mathf.RoundToInt(
                        (float)unit.Speed /
                        (float)LowestSpeed()
                    )
                );

            for (int i = 0;
                i < turns;
                i++)
            {
                turnQueue.Enqueue(unit);
            }
        }

        Debug.Log(
            "Turnos: "
            + turnQueue.Count);
    }

    int LowestSpeed()
    {
        int lowest = 999999;

        foreach (BattleUnit unit in units)
        {
            if (unit.Speed < lowest)
            {
                lowest = unit.Speed;
            }
        }

        return lowest;
    }

    // =========================
    // PRÓXIMO TURNO
    // =========================

    public BattleUnit GetNextTurn()
    {
        if (turnQueue.Count <= 0)
        {
            GenerateTurnOrder();
        }

        if (turnQueue.Count <= 0)
        {
            Debug.LogError(
                "Fila vazia!");

            return null;
        }

        return turnQueue.Dequeue();
    }
}