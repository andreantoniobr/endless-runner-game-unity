using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainHUD : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;

    private void LateUpdate()
    {
        if (gameMode && scoreText && distanceText)
        {
            scoreText.text = $"Score: {gameMode.Score}";
            distanceText.text = $"{gameMode.Distance}M";
        }        
    }
}
