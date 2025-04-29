using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverPanel; // "Game Over" message panel
    public float restartDelay = 2f;  // Delay before restarting the scene

    private bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        // If collision with the train and the game is not over yet
        if (!gameOver && collision.gameObject.CompareTag("Train"))
        {
            gameOver = true;
            // Show the "Game Over" panel
            gameOverPanel.SetActive(true);
            // Restart the scene after a delay (if needed)
            Invoke("RestartScene", restartDelay);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

