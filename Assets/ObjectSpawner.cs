using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject prefabWithCollider;     // Prefab that has a collider
    public GameObject prefabWithoutCollider;  // Prefab that doesn’t have a collider

    [Header("Player Reference")]
    public Transform player;  // Reference to player transform

    [Header("Spawn Points (X Positions Only)")]
    public float[] spawnPointsX = new float[4]; // 4 spawn X positions

    [Header("Timing")]
    public float spawnInterval = 10f;  // Time between spawns
    public float objectLifetime = 20f; // Time before object is destroyed

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObjects();
            timer = 0f;
        }
    }

    void SpawnObjects()
    {
        // Ensure at least one has no collider
        int indexWithoutCollider = Random.Range(0, spawnPointsX.Length);

        for (int i = 0; i < spawnPointsX.Length; i++)
        {
            Vector3 spawnPos = new Vector3(spawnPointsX[i], player.position.y + 20f, 0f);

            GameObject obj;

            if (i == indexWithoutCollider)
                obj = Instantiate(prefabWithoutCollider, spawnPos, Quaternion.identity);
            else
                obj = Instantiate(prefabWithCollider, spawnPos, Quaternion.identity);

            // Destroy after 20 seconds
            Destroy(obj, objectLifetime);
        }
    }
}
