using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class sVolume : MonoBehaviour
{
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
}
