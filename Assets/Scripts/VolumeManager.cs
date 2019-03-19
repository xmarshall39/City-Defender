using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            BGM.volume = 0.65f;
            PlayerPrefs.SetFloat("BGMVolume", 0.65f);
        }
        else
            BGM.volume = PlayerPrefs.GetFloat("BGMVolume");

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.65f);
            SFX.volume = 0.65f;
        }
        else
            SFX.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void ChangeBGMVolume(float vol)
    {
        BGM.volume = vol;
        PlayerPrefs.SetFloat("BGMVolume", vol);
    }

    public void ChangeSFXVolume(float vol)
    {
        SFX.volume = vol;
        SFX.volume = PlayerPrefs.GetFloat("SFXVolume", vol);
        SFX.Play();
    }
}
