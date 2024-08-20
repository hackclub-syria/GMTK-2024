using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sCredits : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject CreditsMenu;
    // link to github
    public void GithubLink()
    {
        Application.OpenURL("https://github.com/hackclub-syria/");
    }

    public void InstagramLink()
    {
        Application.OpenURL("https://www.instagram.com/hackclub.syria/");
    }

    public void Back()
    {
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(false);
    }
}
