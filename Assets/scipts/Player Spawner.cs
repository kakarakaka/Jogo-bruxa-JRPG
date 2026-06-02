using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    void Start()
    {
        transform.position = new Vector3(
            transform.position.x,
            40f,
            transform.position.z
        );
    }

}