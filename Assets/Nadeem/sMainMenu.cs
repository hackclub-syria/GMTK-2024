using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (!PlayerPrefs.HasKey("username"))
        {
            UsernamePanel.SetActive(true);
        }
    }
    // load next scene
    public void Play()
    {
        if (PlayerPrefs.HasKey("playedTutorial"))
        {
            SceneManager.LoadScene("game");
        }
        else
        {
            PlayerPrefs.SetInt("playedTutorial", 1);
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
    public InputField usernameText;
    public void SaveUsername()
    {
        SaveUsername(usernameText.text);
        UsernamePanel.SetActive(false);
    }
    public void SaveUsername(string username)
    {
        PlayerPrefs.SetString("uName", username);
        PlayerPrefs.Save(); // Save the changes
        Debug.Log("Username saved: " + username);
    }
    public string LoadUsername()
    {
        if (PlayerPrefs.HasKey("uName"))
        {
            string username = PlayerPrefs.GetString("uName");
            Debug.Log("Username retrieved: " + username);
            return username;
        }
        else
        {
            Debug.Log("No username found!");
            return null;
        }
    }

    // quit game
    public void Quit()
    {
        Application.Quit();
    }
}
