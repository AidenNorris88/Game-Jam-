using System.Collections;
using UnityEngine; // Core Unity functions
using UnityEngine.InputSystem;   // New Input System (keyboard/mouse input)
using UnityEngine.SceneManagement;  // Lets us load scenes
using static UnityEngine.Rendering.DebugUI.Table;

public class TitleScreenManager : MonoBehaviour
{
    [Header("Scene")]
    public string MainMenu = "MainMenu";
    //The name of the scene we want to load when a key is pressed
    
    [Header("Fade")]
    public CanvasGroup fadeGroup;   // This controls the transparency of the FadePanel (0 = invisible, 1 = fully black)
    public float fadeDuration = 3f;
    //How long the fade takes(in seconds)
   
    private bool isTransitioning = false;

    void Start()
    {
        // When the scene starts, make sure the screen is NOT black
        if (fadeGroup != null)
        {
            fadeGroup.alpha = 0f;
            // 0 = fully transparent (player can see the title screen)
        }
    }

    void Update()
    {
       
        if (isTransitioning) return;

        // Detects the keyboard input (any key)
        bool keyPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;

        // Detects the mouse click (left button)
        bool mousePressed = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        // If ANY input is detected, start the transition
        if (keyPressed || mousePressed)
        {
            StartCoroutine(FadeToMainMenu());
        }
    }

    IEnumerator FadeToMainMenu()
    {
        isTransitioning = true;
        // Locks input so it doesn’t trigger multiple times

        float time = 0f;
        // Gradually increase the fade over time
        
        while (time < fadeDuration)
        {
            time += Time.deltaTime;  // Time.deltaTime is the amount of time passed since last frame
            float t = Mathf.Clamp01(time / fadeDuration); // Converts time into a value between 0 and 1

            if (fadeGroup != null)
            {
                fadeGroup.alpha = t;
                // Slowly changes transparency:
                // 0 → visible
                // 1 → fully black
            }

            yield return null;
            // Wait until the next frame before continuing the loop
        }

        SceneManager.LoadSceneAsync(MainMenu);  // Once fade is complete, load the Main Menu scene
    }
}