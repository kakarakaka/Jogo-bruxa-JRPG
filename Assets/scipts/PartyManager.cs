using System.Collections.Generic;
using UnityEngine;

public class PartyManager :
    MonoBehaviour
{
    public static PartyManager Instance;

    [Header("Party Atual")]
    public List<GameObject>
        currentParty =
        new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}