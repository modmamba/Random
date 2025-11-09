using UnityEngine;
using TMPro;

public class CameraFollowY : MonoBehaviour
{
    public Transform player;   // Reference to the player's transform
    public float smoothSpeed = 5f; // Optional smoothing for smooth camera movement

    private float initialX; // To keep the camera's X position fixed
    private float initialZ; // To keep the camera's Z position fixed
    public TextMeshProUGUI Score1,Score2;

    void Start()
    {
        // Store the camera’s initial X and Z positions
        initialX = transform.position.x;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired Y position based on player
            float targetY = player.position.y;

            // Smoothly interpolate to the new Y position
            float newY = Mathf.Lerp(transform.position.y, targetY, smoothSpeed * Time.deltaTime);

            // Update camera position
            transform.position = new Vector3(initialX, newY, initialZ);
            Score1.text =  Mathf.FloorToInt(player.position.y/10).ToString();
            Score2.text =  Mathf.FloorToInt(player.position.y/10).ToString();
        }
    }
}
