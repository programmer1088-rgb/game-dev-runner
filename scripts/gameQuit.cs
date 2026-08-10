using UnityEngine;

public class gameQuit : MonoBehaviour
{
    void Update()
    {
        // Optional: Press 'Escape' key to quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    // Call this method from UI Buttons or other scripts
    public void QuitGame()
    {
        Debug.Log("Quitting Application...");

        // 1. Quits the standalone application (Windows/Mac/Android/iOS build)
        Application.Quit();

        // 2. Stops Play mode if you are testing inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}