using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class sOptionsMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    // Back to main menu
    public void Back()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
