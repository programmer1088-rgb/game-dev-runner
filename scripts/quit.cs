using UnityEngine;

public class quit : MonoBehaviour
{
    // Call this method from your UI Button's OnClick event
    public void GameOver()
    {
        Debug.Log("Game Over button clicked!");

        // 1. Quits the built application (.exe, .apk, etc.)
        Application.Quit();

        // 2. Stops Play Mode if you are running inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}