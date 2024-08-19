using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using System;

public class sOptionsMenu : MonoBehaviour
{
    
    // Back method variables
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    
    // Set full screen
    public void setFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    // Back to main menu
    public void Back()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
