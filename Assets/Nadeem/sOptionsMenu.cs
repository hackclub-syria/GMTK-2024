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
    
    // VOLUME VARIABLES
    public TextMeshProUGUI masterVol;
    public TextMeshProUGUI SFXVol;
    public TextMeshProUGUI CommVol;
    public TextMeshProUGUI musicVol;

    // BEGINNING OF VOLUME STUFF
    public void setMasterVol(float volume)
    {
        volume = (80 + volume) / 80 * 100;
        masterVol.text = Math.Round(volume).ToString() + "%";
    }

    public void setSFXVol(float volume)
    {
        volume = (80 + volume) / 80 * 100;
        SFXVol.text = Math.Round(volume).ToString() + "%";
    }
    public void setCommVol(float volume)
    {
        volume = (80 + volume) / 80 * 100;
        CommVol.text = Math.Round(volume).ToString() + "%";
    }
    
    public void setMusicVol(float volume)
    {
        volume = (80 + volume) / 80 * 100;
        musicVol.text = Math.Round(volume).ToString() + "%";
    }
    // END OF VOLUME STUFF

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
