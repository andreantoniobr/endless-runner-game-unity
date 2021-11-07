using System.Collections;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    [SerializeField] private GameObject hudOverlay;
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject StartOverlay;

    [SerializeField] private TextMeshProUGUI numberCountdown;

    private void Awake()
    {
        SetActiveStartOverlay(true);
    }

    private void Update()
    {
        if (gameMode)
        {
            if (gameMode.IsGameStarted)
            {
                SetActiveStartOverlay(false);
            }                
        }
    }

    private void SetActiveStartOverlay(bool isActive) 
    {
        if (StartOverlay.activeSelf != isActive)
        {
            StartOverlay.SetActive(isActive);
        }
        if (isActive)
        {
            hudOverlay.SetActive(false);
            pauseOverlay.SetActive(false);
        }
    }

    public void ChangeUI(bool isPaused)
    {
        if (hudOverlay && pauseOverlay)
        {
            hudOverlay.SetActive(!isPaused);
            pauseOverlay.SetActive(isPaused);
        }        
    }

    public void StartCountdown(int initialCountDownTime, int endCountdownTime, float countdownTime, float _scaleIncrement, int countdownTimeMultiplier)
    {
        for (int i = initialCountDownTime; i < endCountdownTime; i++)
        {
            StartCoroutine(ResizeObjectEffectCoroutine(countdownTime, _scaleIncrement, countdownTimeMultiplier));
        }
    }

    private IEnumerator ResizeObjectEffectCoroutine(float countdownTime, float _scaleIncrement, int countdownTimeMultiplier)
    {
        float scaleTime = countdownTime * countdownTimeMultiplier;
        float currentTime = 0;
        Vector3 initialScaleSize = numberCountdown.transform.localScale;
        while (currentTime < scaleTime)
        {
            Vector3 scaleSize = numberCountdown.transform.localScale;
            float scaleIncrement = scaleSize.x + _scaleIncrement;
            numberCountdown.transform.localScale = new Vector3(scaleIncrement, scaleIncrement, scaleSize.z);
            currentTime += countdownTime;
            yield return new WaitForSeconds(countdownTime);
        }
        numberCountdown.transform.localScale = initialScaleSize;
    }
}
