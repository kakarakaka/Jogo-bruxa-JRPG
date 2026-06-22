using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    public HashSet<string> unlocked = new HashSet<string>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Unlock(string id)
    {
        unlocked.Add(id);
    }

    public bool IsUnlocked(string id)
    {
        return unlocked.Contains(id);
    }
}