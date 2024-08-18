using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sMainMenu : MonoBehaviour
{
    
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    // load next scene
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // go to options menu
    public void ViewOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    // quit game
    public void Quit()
    {
        Application.Quit();
    }
}
