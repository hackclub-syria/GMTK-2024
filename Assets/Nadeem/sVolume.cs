using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.Audio;

public class sVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public TextMeshProUGUI masterVol;
    public TextMeshProUGUI SFXVol;
    public TextMeshProUGUI CommVol;
    public TextMeshProUGUI musicVol;

    // BEGINNING OF VOLUME STUFF
    public void setMasterVol(float volume)
    {
        // set the audio level according to volume variable
        mixer.SetFloat("MasterVol", volume);
        //edit volume variable to view UI changes out of 100%
        volume = (80 + volume) / 80 * 100;
        masterVol.text = Math.Round(volume).ToString() + "%";
    }

    public void setSFXVol(float volume)
    {
        // set the audio level according to volume variable
        mixer.SetFloat("SFXVol", volume);
        //edit volume variable to view UI changes out of 100%
        volume = (80 + volume) / 80 * 100;
        SFXVol.text = Math.Round(volume).ToString() + "%";
    }
    public void setCommVol(float volume)
    {
        // set the audio level according to volume variable
        mixer.SetFloat("CommVol", volume);
        //edit volume variable to view UI changes out of 100%
        volume = (80 + volume) / 80 * 100;
        CommVol.text = Math.Round(volume).ToString() + "%";
    }

    public void setMusicVol(float volume)
    {
        // set the audio level according to volume variable
        mixer.SetFloat("MusicVol", volume);
        //edit volume variable to view UI changes out of 100%
        volume = (80 + volume) / 80 * 100;
        musicVol.text = Math.Round(volume).ToString() + "%";
    }
    // END OF VOLUME STUFF
}
