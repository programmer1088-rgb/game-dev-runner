using UnityEngine;

public class obstaclecollider : MonoBehaviour
{
    [SerializeField]
    private Transform[] _obstacle = new Transform[2];
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _xLimit = 10.0f;

    [Header("UI Reference")]
    [SerializeField] private GameObject _gameOverPanel; // Drag your UI Panel here in Inspector

    private void Start()
    {
        // Make sure the Game Over panel is hidden when the game starts
        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(false);
        }

        // Resume time in case it was paused previously
        Time.timeScale = 1f;
    }

    private void Update()
    {
        for (int i = 0; i < _obstacle.Length; i++)
        {
            if (_obstacle[i] == null) continue;

            // Move left
            _obstacle[i].position += Vector3.left * Time.deltaTime * _speed;

            // Off-screen check & respawn
            if (_obstacle[i].position.x < -_xLimit)
            {
                _obstacle[i].position += new Vector3(2 * _xLimit, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        Debug.Log("GAME OVER!");

        // 1. Activate the Game Over Panel UI
        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(true);
        }

        // 2. Pause game physics and movement
        Time.timeScale = 0f;
    }
}