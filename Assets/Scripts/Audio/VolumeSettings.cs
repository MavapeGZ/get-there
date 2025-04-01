using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer audioMixer;
    [SerializeField]    
    private Slider musicSlider;
    [SerializeField]
    private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }        
    }

    public void SetMusicVolume()
    {        
        float volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }

    public void MuteMusic()
    {
        musicSlider.value = 0;
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void MuteSFX()
    {
        SFXSlider.value = 0;
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void UnmuteMusic()
    {
        musicSlider.value = 1;
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void UnmuteSFX()
    {
        SFXSlider.value = 1;
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
}