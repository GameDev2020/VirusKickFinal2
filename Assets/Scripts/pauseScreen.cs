// This script is used for Impaired, but can be applied to any pause menu screen by Lauren Stamp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScreen : MonoBehaviour
{

    public GameManager gm; 

    public string restart;

    public string mainMenu;

    public bool isPaused;

    public GameObject pauseMenuCanvas;

    public string currentScene = "level1";

    // Use this for initialization
    void Start()
    {
        isPaused = false;
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

         if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                // activates the pause menu canvas (screen background, text and buttons appear)
                pauseMenuCanvas.SetActive(true);
                // makes the game stop working (character, monster, timer stops)
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                // pause menu isn't visible, game is operational
                pauseMenuCanvas.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }

    [System.Obsolete]
    public void Restart()
    {
        Time.timeScale = 1f;
        // restarts the current scene
        SceneManager.LoadScene(currentScene);
    }

    public void BackToMenu()
    {
        // loads the menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);

    }
}