using UnityEngine;                          // Gives access to core Unity features
using UnityEngine.SceneManagement;          // Lets us switch between scenes

public class PauseMenuManager : MonoBehaviour
{
    // =========================
    // SCENE SETTINGS
    // =========================

    public string gameSceneName = "GameScene";
    // The name of the gameplay scene.
    // Resume will load this scene.

    public string MainMenu = "MainMenu";
    // The name of the Main Menu scene.
    // This is used when the player wants to leave the pause menu and return to the main menu.

    // =========================
    // RESUME BUTTON
    // =========================

    public void ResumeGame()
    {
        // Loads the game scene again.
        // Since this pause menu is its own scene,
        // this does not return to the exact paused moment.
        // It simply goes back to the gameplay scene.
        SceneManager.LoadScene(gameSceneName);
    }

    // =========================
    // MAIN MENU BUTTON
    // =========================

    public void GoToMainMenu()
    {
        // Loads the Main Menu scene.
        SceneManager.LoadScene(MainMenu);
    }

    // =========================
    // QUIT BUTTON
    // =========================

    public void QuitGame()
    {
        // Shows a message in the Console while testing in Unity.
        Debug.Log("Quit button pressed.");

#if UNITY_EDITOR
        // If you are testing inside Unity,
        // this stops Play Mode.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If the game is built and exported,
        // this closes the application completely.
        Application.Quit();
#endif
    }
}