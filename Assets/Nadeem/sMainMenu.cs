using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class sMainMenu : MonoBehaviour
{
    
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject LeaderboardMenu;

    // load next scene
    public void Play()
    {
        if (SaveGame.Exists("playedTutorial")){
            SceneManager.LoadScene("game");
        }
        else
        {
            SaveGame.Save<bool>("playedTutorial", true);
            SceneManager.LoadScene("tutorial");
        }
    }

    // go to options menu
    public void ViewOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void ViewLeaderboard()
    {
        MainMenu.SetActive(false);
        LeaderboardMenu.SetActive(true);
    }

    // quit game
    public void Quit()
    {
        Application.Quit();
    }
}
