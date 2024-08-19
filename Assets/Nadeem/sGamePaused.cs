using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class sGamePaused : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
        
    }
    
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void quitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        // ADD CODE HERE FOR RESTARTING THE GAME
    }
}
