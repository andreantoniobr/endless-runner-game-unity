using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainHUD : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;

    private void LateUpdate()
    {
        if (playerController && scoreText && distanceText)
        {
            scoreText.text = $"Score: {playerController.Score}";
            distanceText.text = $"{playerController.Distance}M";
        }        
    }
}
