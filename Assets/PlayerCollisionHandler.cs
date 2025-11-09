using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [Header("UI")]
    public GameObject scorePanel; // Assign your Score Panel GameObject

    void Start()
    {
        // Ensure the score panel starts inactive
        if (scorePanel != null)
            scorePanel.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            // Activate score panel
            if (scorePanel != null){

                scorePanel.SetActive(true);
                Time.timeScale = 0f; // Pause the game
            }
        }
    }

    // Optional: For triggers instead of physical collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (scorePanel != null)
                scorePanel.SetActive(true);
        }
    }
}
