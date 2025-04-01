using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private int currentTrackIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return; // Singleton
        }
    }

    private void Start()
    {
        PlayMusicTrack(currentTrackIndex);
    }

    public void PlayMusicTrack(int index)
    {
        if (index >= 0 && index < musicSounds.Length)
        {
            Sound s = musicSounds[index];
            if (s == null)
            {
                Debug.Log("Sound not found");
            }
            else
            {
                musicSource.clip = s.sound;
                musicSource.Play();
                musicSource.loop = false; 
                StartCoroutine(WaitForTrackEnd(s.sound.length));
            }
        }
    }

    private IEnumerator WaitForTrackEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayNextTrack();
    }

    public void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicSounds.Length;
        PlayMusicTrack(currentTrackIndex);
    }

    public void OnButtonClickNextTrack()
    {
        StopCoroutine("WaitForTrackEnd");
        PlayNextTrack();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.soundName == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.sound;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        AudioManager.instance.musicSource.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.soundName == name);

        if (s == null)
        {
            Debug.Log("SFX not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.sound);
        }
    }
}
