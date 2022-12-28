using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioMixerConstants
{
    public const string MainVolume = "MainVolume";
    public const string MusicVolume = "MusicVolume";
    public const string SFXVolume = "SFXVolume";
}

public class GameAudioData
{
    [Range(0.0f, 1.0f)]
    public float MainVolume = 1f;
    [Range(0.0f, 1.0f)]
    public float MusicVolume = 1f;
    [Range(0.0f, 1.0f)]
    public float SFXVolume = 1f;
}

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameSaver gameSaver;
    
    private readonly float dBMin = -60f;
    private readonly float dBMax = 0f;
    private GameAudioData currentAudioMixerVolume;

    private void Start()
    {
        SetAudioMixerInitialVolume();
    }

    private void SetAudioMixerInitialVolume()
    {
        if (gameSaver)
        {
            currentAudioMixerVolume = gameSaver.GameAudioData;
            SetAudioMixerVolume(currentAudioMixerVolume.MainVolume, currentAudioMixerVolume.MusicVolume, currentAudioMixerVolume.SFXVolume);
        }
    }

    private void SetAudioMixerGroupVolume(string audioMixerGroup, float volumePercent)
    {
        if (audioMixer && volumePercent >= 0f && volumePercent <= 1f)
        {
            audioMixer.SetFloat(audioMixerGroup, ConvertPercentToDB(volumePercent));
        }
    }

    private float ConvertPercentToDB(float percent)
    {        
        return Mathf.Lerp(dBMin, dBMax, percent);
    }

    public void SetAudioMixerVolume(float mainVolume, float musicVolume, float SFXVolume)
    {
        SetAudioMixerGroupVolume(AudioMixerConstants.MainVolume, mainVolume);
        SetAudioMixerGroupVolume(AudioMixerConstants.MusicVolume, musicVolume);
        SetAudioMixerGroupVolume(AudioMixerConstants.SFXVolume, SFXVolume);

        currentAudioMixerVolume = new GameAudioData
        {
            MainVolume = mainVolume,
            MusicVolume = musicVolume,
            SFXVolume = SFXVolume
        };

        if (gameSaver)
        {
            gameSaver.SaveAudioVolumePrefs(mainVolume, musicVolume, SFXVolume);
        }
    }
}
