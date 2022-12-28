using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public static class ButtonTexts
{
    public const string deleteDataButtonText = "DELETE DATA";
    public const string deletetButtonText = "DELETED!";
}

public class SettingsOverlay : MonoBehaviour
{
    [SerializeField] private GameAudioManager gameAudioManager;
    [SerializeField] private GameSaver gameSaver;
    [SerializeField] private TextMeshProUGUI deleteDataText;

    [Header("Sliders")]
    [SerializeField] private Slider mainVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    private GameAudioData currentAudioMixerVolume;

    private void OnEnable()
    {
        LoadGameAudioData();
        UpdateSliders();
        SetDeleteDataButtonText();
    }

    private void OnDisable()
    {
        UpdateAudioMixerVolume();
    }

    private void LoadGameAudioData()
    {
        if (gameSaver)
        {
            currentAudioMixerVolume = gameSaver.GameAudioData;
        }
    }

    private void UpdateSliders()
    {
        if (mainVolumeSlider && musicVolumeSlider && SFXVolumeSlider && currentAudioMixerVolume != null)
        {
            mainVolumeSlider.value = currentAudioMixerVolume.MainVolume;
            musicVolumeSlider.value = currentAudioMixerVolume.MusicVolume;
            SFXVolumeSlider.value = currentAudioMixerVolume.SFXVolume;
        }
    }

    private void SetDeleteDataButtonText()
    {
        if (deleteDataText)
        {
            deleteDataText.text = ButtonTexts.deleteDataButtonText;
        }
    }

    private void UpdateDeleteDataButtonText()
    {
        if (deleteDataText)
        {
            deleteDataText.text = ButtonTexts.deletetButtonText;
        }
    }

    private void UpdateAudioMixerVolume()
    {
        if (currentAudioMixerVolume != null)
        {
            gameAudioManager.SetAudioMixerVolume(currentAudioMixerVolume.MainVolume, currentAudioMixerVolume.MusicVolume, currentAudioMixerVolume.SFXVolume);
        }
    }

    public void OnMainVolumeChange(float value)
    {
        if (gameAudioManager)
        {
            currentAudioMixerVolume.MainVolume = value;
            UpdateAudioMixerVolume();
        }
    }

    public void OnMusicVolumeChange(float value)
    {
        if (gameAudioManager)
        {
            currentAudioMixerVolume.MusicVolume = value;
            UpdateAudioMixerVolume();
        }
    }

    public void OnSFXVolumeChange(float value)
    {
        if (gameAudioManager)
        {
            currentAudioMixerVolume.SFXVolume = value;
            UpdateAudioMixerVolume();
        }
    }

    public void DeleteGameData()
    {
        if (gameSaver)
        {
            gameSaver.DeleteGameData();
            currentAudioMixerVolume = gameSaver.GameAudioData;
            UpdateSliders();
            UpdateAudioMixerVolume();
            UpdateDeleteDataButtonText();
        }
    }
}
