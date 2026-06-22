using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public CollectibleData data;

    public void Interact()
    {
        CollectibleManager.Instance.Unlock(data.id);

        Debug.Log("Coletável desbloqueado: " + data.collectibleName);

        Destroy(gameObject);
    }
}