using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberCountdown;

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
