using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [Header("Units")]
    public List<BattleUnit> units =
        new List<BattleUnit>();

    private Queue<BattleUnit> turnQueue =
        new Queue<BattleUnit>();

    public void GenerateTurnOrder()
    {
        Debug.Log(
    "Units antes da limpeza: "
    + units.Count);

        turnQueue.Clear();

        units.RemoveAll(
            unit =>
            unit == null ||
            unit.IsDead());

        Debug.Log(
    "Units após limpeza: "
    + units.Count);

        if (units.Count == 0)
        {
            Debug.LogError("Nenhuma unidade viva!");
            return;
        }

        int lowestSpeed =
            Mathf.Max(1, LowestSpeed());

        foreach (BattleUnit unit in units)
        {
            int turns =
                Mathf.Max(
                    1,
                    Mathf.RoundToInt(
                        (float)unit.Speed /
                        lowestSpeed));

            for (int i = 0; i < turns; i++)
            {
                turnQueue.Enqueue(unit);
            }
        }

        Debug.Log("Turnos gerados: " + turnQueue.Count);
    }

    int LowestSpeed()
    {
        int lowest = int.MaxValue;

        foreach (BattleUnit unit in units)
        {
            if (unit == null)
                continue;

            lowest =
                Mathf.Min(
                    lowest,
                    Mathf.Max(1, unit.Speed));
        }

        return lowest;
    }

    public BattleUnit GetNextTurn()
    {
        while (true)
        {
            if (turnQueue.Count == 0)
            {
                GenerateTurnOrder();


                if (turnQueue.Count == 0)
                    return null;
            }

            BattleUnit unit =
                turnQueue.Dequeue();

            if (unit == null)
                continue;

            if (unit.IsDead())
                continue;

            return unit;
        }
    }
}