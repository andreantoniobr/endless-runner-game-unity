using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

// https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
//https://www.technical-recipes.com/2018/how-to-serialize-and-deserialize-objects-using-newtonsoft-json/

public static class GameSaverConstants
{
    public const string HighestScore = "HighestScore";
    public const string LastScore = "LastScore";
    public const string CherriesAmount = "CherriesAmount";
}

public class GameData
{
    private int highestScore;
    private int lastScore;
    private int cherriesAmount;

    public int HighestScore 
    { 
        get => highestScore;
        set => highestScore = value;
    }

    public int LastScore
    { 
        get => lastScore;
        set => lastScore = value;
    }

    public int CherriesAmount
    {
        get => cherriesAmount;
        set => cherriesAmount = value;
    }
}

public class GameSaver : MonoBehaviour
{
    private GameData gameData;
    private GameAudioData gameAudioData;

    public GameData GameData => gameData;
    public GameAudioData GameAudioData => gameAudioData;


    private string gameDataPath;
    private string gameAudioDataPath;

    private void Awake()
    {
        gameDataPath = $"{Application.persistentDataPath}/GameDataSave.txt";
        gameAudioDataPath = $"{Application.persistentDataPath}/AudioDataSave.txt";
        GetGameData();
    }

    private void GetGameData()
    {
        gameData = GetSaveData(gameDataPath) ?? new GameData();
        gameAudioData = GetAudioSaveData(gameAudioDataPath) ?? new GameAudioData();
    }

    private int GetHighestScoreAmount(int currentScoreAmount)
    {
        int highestScoreAmount = gameData.HighestScore;
        if (currentScoreAmount > highestScoreAmount)
        {
            highestScoreAmount = currentScoreAmount;
        }
        return highestScoreAmount;
    }

    private int GetCherriesAmount(int currentCherriesAmount)
    {
        int cherriesAmount = gameData.CherriesAmount;
        if (cherriesAmount >= 0 && currentCherriesAmount >= 0)
        {
            cherriesAmount += currentCherriesAmount;
        }
        return cherriesAmount;
    }

    public void SaveGame(int currentScoreAmount, int currentCherriesAmount)
    {
        GameData gameData = new GameData
        {
            HighestScore = GetHighestScoreAmount(currentScoreAmount),
            LastScore = currentScoreAmount,
            CherriesAmount = GetCherriesAmount(currentCherriesAmount)
        };
        GenerateSaveFile(gameDataPath, gameData);
    }

    private void GenerateSaveFile(string path, GameData saveData)
    {
        JsonSerializer serializer = new JsonSerializer();
        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (StreamWriter streamWriter = new StreamWriter(stream))
        using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
        {
            serializer.Serialize(jsonWriter, saveData);
        }
    }

    private void GenerateAudioSaveFile(string path, GameAudioData saveData)
    {
        JsonSerializer serializer = new JsonSerializer();
        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (StreamWriter streamWriter = new StreamWriter(stream))
        using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
        {
            serializer.Serialize(jsonWriter, saveData);
        }
    }

    private GameData GetSaveData(string path)
    {
        JsonSerializer serializer = new JsonSerializer();
        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
        using (StreamReader streamReader = new StreamReader(stream))
        using (JsonReader jsonReader = new JsonTextReader(streamReader))
        {
            return serializer.Deserialize<GameData>(jsonReader);
        }
    }

    private GameAudioData GetAudioSaveData(string path)
    {
        JsonSerializer serializer = new JsonSerializer();
        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
        using (StreamReader streamReader = new StreamReader(stream))
        using (JsonReader jsonReader = new JsonTextReader(streamReader))
        {
            return serializer.Deserialize<GameAudioData>(jsonReader);
        }
    }

    private void DeleteSaveFile(string saveFilePath)
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }        
    }   

    public void DeleteGameData()
    {        
        DeleteSaveFile(gameDataPath);
        DeleteSaveFile(gameAudioDataPath);
        gameData = null;
        gameAudioData = null;
        GetGameData();
    }    
    
    public void SaveAudioVolumePrefs(float mainVolume, float musicVolume, float SFXVolume)
    {
        GameAudioData gameAudioSaveData = GenerateGameAudioData(mainVolume, musicVolume, SFXVolume);
        GenerateAudioSaveFile(gameAudioDataPath, gameAudioSaveData);
    }

    private GameAudioData GenerateGameAudioData(float _mainVolume, float _musicVolume, float _SFXVolume)
    {
        return new GameAudioData
        {
            MainVolume = GetAudioGroupVolume(_mainVolume),
            MusicVolume = GetAudioGroupVolume(_musicVolume),
            SFXVolume = GetAudioGroupVolume(_SFXVolume)
        };    
    }
    private float GetAudioGroupVolume(float volumePercent)
    {
        float audioGroupVolumePercent = 0f;
        if (volumePercent >= 0f && volumePercent <= 1f)
        {
            audioGroupVolumePercent = volumePercent;
        }
        return audioGroupVolumePercent;
    }
}
