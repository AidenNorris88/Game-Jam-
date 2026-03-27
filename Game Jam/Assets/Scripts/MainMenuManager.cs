using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string firstLevelSceneName = "GameScene";
    // The scene that loads when the player starts the game, "GameScene" being the game itself
    public void StartGame()
    {
        // Loads the first level of the game
        SceneManager.LoadScene(firstLevelSceneName);
    }

    public void ContinueGame()
    {
        // For now, this does the same as StartGame
        // Later, this can load saved progress
        SceneManager.LoadScene(firstLevelSceneName);
    }

   

    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // If you're in Unity Editor → stops Play Mode
#else
        Application.Quit();
        // If the game is built → closes the game completely
#endif
    }
}