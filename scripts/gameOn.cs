using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class gameOn  : MonoBehaviour
{
    
    // 1. Load a scene by its name (e.g., "MainMenu", "Level2")
    public void LoadSceneByName(string sceneName)
    {
        Time.timeScale = 1f; // Ensures the game is unpaused when loading
        SceneManager.LoadScene(sceneName);
    }

    //// 2. Load a scene by its build index number (0, 1, 2...)
    //public void LoadSceneByIndex(int sceneIndex)
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(sceneIndex);
    //}

    //// 3. Reload the currently active scene (for Restart buttons)
    //public void ReloadCurrentScene()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    //// 4. Load the next scene in order
    //public void LoadNextScene()
    //{
    //    Time.timeScale = 1f;
    //    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    //    SceneManager.LoadScene(nextSceneIndex);
    //}
}