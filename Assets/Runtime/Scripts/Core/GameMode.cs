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
    [SerializeField] private float reloadGameDelay = 3;

    [Header("Countdown")]
    [SerializeField] private int initialCountDownTime = 1;
    [SerializeField] private int endCountdownTime = 5;
    [SerializeField] private float scaleIncrement = 0.1f;
    [SerializeField] private float countdownTime = 0.05f;
    [SerializeField] private int countdownTimeMultiplier = 20;

    [Header("Music")]
    [SerializeField] private MusicPlayer musicPlayer;
    [SerializeField] private HUDAudioController HUDAudioController;

    private bool isGameStarted = false;
    private bool isGamePaused = false;

    public bool IsGameStarted => isGameStarted;
    public bool IsGamePaused => isGamePaused;

    public void OnGameOver()
    {
        if (musicPlayer)
        {
            musicPlayer.PlayDeadMusic();
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
    }    

    private void Pause()
    {
        Time.timeScale = 0f;
        hudManager.ChangeUI(isGamePaused);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        hudManager.ChangeUI(isGamePaused);
    }

    public void StartGame()
    {
        hudManager.StartCountdown(initialCountDownTime, endCountdownTime, countdownTime, scaleIncrement, countdownTimeMultiplier);

        isGameStarted = true;

        HUDAudioController.PlayButtonPressSound();

        hudManager.ChangeUI(IsGamePaused);

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
}
