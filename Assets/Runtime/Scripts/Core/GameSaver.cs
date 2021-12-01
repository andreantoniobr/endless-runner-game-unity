using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSaverConstants
{
    public const string HighestScore = "HighestScore";
    public const string LastScore = "LastScore";
    public const string CherriesAmount = "CherriesAmount";
}

public class GameData
{
    public int highestScore;
    public int lastScore;
    public int cherriesAmount;
}

public class GameSaver : MonoBehaviour
{
    private GameData gameData;
    private GameAudioData gameAudioData;

    public GameData GameData => GetGameData();
    public GameAudioData GameAudioData => GetGameAudioData();

    private void SaveHighestScore(int scoreAmount)
    {
        int highestScoreData = GameData.highestScore;
        if (highestScoreData < scoreAmount)
        {
            PlayerPrefs.SetInt(GameSaverConstants.HighestScore, scoreAmount);
        }        
    }

    private void SaveLastScore(int scoreAmount)
    {
        PlayerPrefs.SetInt(GameSaverConstants.LastScore, scoreAmount);
    }

    private void SaveCherriesAmount(int cherriesAmount)
    {
        int cherriesAmountData = GameData.cherriesAmount;
        PlayerPrefs.SetInt(GameSaverConstants.CherriesAmount, cherriesAmountData + cherriesAmount);
    }

    private void SaveAudioGroupVolume(string audioMixerGroup, float volumePercent)
    {
        if (volumePercent >= 0f && volumePercent <= 1f)
        {
            PlayerPrefs.SetFloat(audioMixerGroup, volumePercent);
        }
    }

    private GameData GetGameData()
    {
        gameData = new GameData
        {
            highestScore = PlayerPrefs.GetInt(GameSaverConstants.HighestScore, 0),
            lastScore = PlayerPrefs.GetInt(GameSaverConstants.LastScore, 0),
            cherriesAmount = PlayerPrefs.GetInt(GameSaverConstants.CherriesAmount, 0)
        };
        return gameData;
    }

    private GameAudioData GetGameAudioData()
    {
        gameAudioData = new GameAudioData
        {
            mainVolume = PlayerPrefs.GetFloat(AudioMixerConstants.MainVolume, 1f),
            musicVolume = PlayerPrefs.GetFloat(AudioMixerConstants.MusicVolume, 1f),
            SFXVolume = PlayerPrefs.GetFloat(AudioMixerConstants.SFXVolume, 1f)
        };
        return gameAudioData;
    }

    public void SaveGame(int scoreAmount, int cherriesAmount)
    {
        SaveHighestScore(scoreAmount);
        SaveLastScore(scoreAmount);
        SaveCherriesAmount(cherriesAmount);
    }

    public void SaveAudioVolumePrefs(float mainVolume, float musicVolume, float SFXVolume)
    {
        SaveAudioGroupVolume(AudioMixerConstants.MainVolume, mainVolume);
        SaveAudioGroupVolume(AudioMixerConstants.MusicVolume, musicVolume);
        SaveAudioGroupVolume(AudioMixerConstants.SFXVolume, SFXVolume);
    }

    public void DeleteGameData()
    {
        gameData = null;
        gameAudioData = null;
        PlayerPrefs.DeleteAll();
    }
}
