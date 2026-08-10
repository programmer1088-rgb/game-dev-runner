using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the scene

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Transform[] _obstacle = new Transform[2];
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _xLimit = 10.0f;

    void Update()
    {
        for (int i = 0; i < _obstacle.Length; i++)
        {
            // Safeguard in case an element isn't assigned
            if (_obstacle[i] == null) continue;

            // Move left instead of right
            _obstacle[i].position += Vector3.left * Time.deltaTime * _speed;

            // When the obstacle moves off-screen to the left (-_xLimit)
            if (_obstacle[i].position.x < -_xLimit)
            {
                // Respawn it on the far right side (+_xLimit)
                _obstacle[i].position += new Vector3(2 * _xLimit, 0, 0);
            }
        }
    }

    // Called when the player physically hits the collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }

    // Called if your obstacle collider has "Is Trigger" checked
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // 1. Log Game Over to console
        Debug.Log("GAME OVER! Restarting scene...");

        // 2. Ensure normal time scale (if paused previously)
        Time.timeScale = 1f;

        // 3. Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}