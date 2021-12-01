using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAnimationController playerAnimationController;
    [SerializeField] private HUDManager hudManager;
    [SerializeField] private GameSaver gameSaver;

    [Header("Music")]
    [SerializeField] private MusicPlayer musicPlayer;
    [SerializeField] private HUDAudioController HUDAudioController;    

    [Header("Gameplay")]
    [SerializeField] private float startPlayerSpeed = 10f;
    [SerializeField] private float maxPlayerSpeed = 17f;
    [SerializeField] private float timeToMaxSpeedSeconds = 300f;
    [SerializeField] private float reloadGameDelay = 3;

    [Header("Score")]
    [SerializeField] private float baseScoreMultiplier = 1f;
    /*
    [Header("Countdown")]
    [SerializeField] private int initialCountDownTime = 1;
    [SerializeField] private int endCountdownTime = 5;
    [SerializeField] private float scaleIncrement = 0.1f;
    [SerializeField] private float countdownTime = 0.05f;
    [SerializeField] private int countdownTimeMultiplier = 20;*/
    
    [Header("Pickups")]
    [SerializeField] private int pickupsCount = 0;

    private float score;
    private float distance;

    private bool isGameStarted = false;
    private bool isGamePaused = false;

    private float startGametime;

    public bool IsGameStarted => isGameStarted;
    public bool IsGamePaused => isGamePaused;

    public int Score => Mathf.RoundToInt(score);
    public int Distance => Mathf.RoundToInt(distance);

    public int PickupsCount {
        get { return pickupsCount;  }
        set { pickupsCount = value; } 
    }

    public void OnGameOver()
    {
        if (musicPlayer)
        {
            musicPlayer.PlayDeadMusic();
        }
        if (gameSaver)
        {
            gameSaver.SaveGame(Score, PickupsCount);
        }        
        StartCoroutine(ReloadGameCoroutine());
    }

    private IEnumerator ReloadGameCoroutine()
    {
        //esperar uma frame
        yield return new WaitForSeconds(reloadGameDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Awake()
    {
        if (musicPlayer)
        {
            musicPlayer.PlayStartMenuMusic();
        }
        
        if (playerController)
        {
            playerController.enabled = false;            
        }

        hudManager.SetActiveOverlay(OverlayName.Start);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGameStarted)
            {
                StartGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndResumeGame();
        }

        if (isGameStarted)
        {
            float timePercent = (Time.time - startGametime) / timeToMaxSpeedSeconds;
            UpdateDistanceAndScore(timePercent);
            UpdatePlayerForwardSpeed(timePercent);
            ActivePlayer();
        }
    }

    private void ActivePlayer()
    {
        if (playerAnimationController.GetAnimationTime(PlayerAnimationConstants.StartRun) >= 1)
        {
            playerController.enabled = true;
        }
    }

    private void UpdateDistanceAndScore(float timePercent)
    {
        distance = Mathf.Abs(playerController.transform.position.z - playerController.InitialPosition.z);
        float extraScoreMultiplier = 1 + timePercent;
        score = baseScoreMultiplier * extraScoreMultiplier * distance;
    }

    private void UpdatePlayerForwardSpeed(float timePercent)
    {
        float forwardSpeed = Mathf.Lerp(startPlayerSpeed, maxPlayerSpeed, timePercent);
        playerController.SetSpeed(forwardSpeed);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        hudManager.SetActiveOverlay(OverlayName.Pause);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        hudManager.SetActiveOverlay(OverlayName.MainHud);
    }

    public void StartGame()
    {
        //hudManager.StartCountdown(initialCountDownTime, endCountdownTime, countdownTime, scaleIncrement, countdownTimeMultiplier);
        isGameStarted = true;
        startGametime = Time.time;
        HUDAudioController.PlayButtonPressSound();
        hudManager.SetActiveOverlay(OverlayName.MainHud);

        if (musicPlayer)
        {
            musicPlayer.PlayMainTrackMusic();
        }

        if (playerController && playerAnimationController)
        {
            playerAnimationController.PlayStartGameAnimation();
        }
    }

    public void PauseAndResumeGame()
    {
        HUDAudioController.PlayButtonPressSound();
        if (isGameStarted)
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }        
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Settings()
    {
        hudManager.SetActiveOverlay(OverlayName.Settings);
    }

    public void CloseSettings()
    {
        hudManager.SetActiveOverlay(OverlayName.Start);
    }
}
