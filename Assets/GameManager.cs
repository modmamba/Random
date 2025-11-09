using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;

    [Header("UI Panels")]
    public GameObject pauseMenuUI;  // Assign Pause Menu Panel in Inspector

    void Start()
    {
        // Ensure pause menu is hidden when the game starts
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        // Make sure time runs normally
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Press ESC to toggle pause/resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // 🟢 Resume Game
    public void ResumeGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    // ⏸️ Pause Game
    public void PauseGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    // 🔄 Restart Current Level
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Resume normal time before reloading
        SceneManager.LoadScene(0);
    }

    // 🏠 Load Main Menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // Reset time scale before switching
        SceneManager.LoadScene(0);
    }

    // ❌ Exit Game
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
    public void LoadGameScene()
    {
        Time.timeScale = 1f;  // Ensure time scale is normal
        SceneManager.LoadScene(1);
    }
}
