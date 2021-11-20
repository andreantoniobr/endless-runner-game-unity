using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainHUD : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI pickupText;

    private void LateUpdate()
    {
        if (gameMode)
        {
            if (scoreText && distanceText)
            {
                scoreText.text = $"Score: {gameMode.Score}";
                distanceText.text = $"{gameMode.Distance}M";
            }
            if (pickupText)
            {
                pickupText.text = $"{gameMode.PickupsCount}";
            }
        }
    }
}
