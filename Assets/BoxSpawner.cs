using UnityEngine;

public class DualBoxSpawner : MonoBehaviour
{
    [Header("Assign Prefabs")]
    public GameObject boxType1;   // First box prefab
    public GameObject boxType2;   // Second box prefab

    [Header("Spawn Points")]
    public float xPoint1 = -3f;   // X position for boxType1
    public float xPoint2 = 3f;    // X position for boxType2

    [Header("Spawn Settings")]
    public float startY = 0f;         // Initial Y position
    public float yGap = 5f;           // Vertical gap between boxes
    public float spawnInterval = 10f; // Time between spawns
    public float lifeTime = 20f;      // Destroy time

    private float nextY;  // Keeps track of the next Y position

    void Start()
    {
        nextY = startY;
        InvokeRepeating(nameof(SpawnBothBoxes), 1f, spawnInterval);
    }

    void SpawnBothBoxes()
    {
        // Box 1
        Vector3 pos1 = new Vector3(xPoint1, nextY, 0f);
        GameObject newBox1 = Instantiate(boxType1, pos1, Quaternion.identity);
        Destroy(newBox1, lifeTime);

        // Box 2 (Y + yGap)
        Vector3 pos2 = new Vector3(xPoint2, nextY + yGap, 0f);
        GameObject newBox2 = Instantiate(boxType2, pos2, Quaternion.identity);
        Destroy(newBox2, lifeTime);

        // Increase next spawn Y height
        nextY += yGap;
    }
}
