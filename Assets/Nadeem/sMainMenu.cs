using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class sMainMenu : MonoBehaviour
{
    
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject LeaderboardMenu;
    public GameObject CreditsMenu;
    public GameObject UsernamePanel;

    private void Start()
    {
        if (!SaveGame.Exists("username")){
            UsernamePanel.SetActive(true);
        }
    }
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
    public void ViewCredits()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }
    public Text usernameText;
    public void SaveUsername()
    {
        SaveGame.Save<string>("username", usernameText.text);
        UsernamePanel.SetActive(false);
    }

    // quit game
    public void Quit()
    {
        Application.Quit();
    }
}
