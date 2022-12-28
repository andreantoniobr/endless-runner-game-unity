using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartOverlay : MonoBehaviour
{
    [SerializeField] private GameSaver gameSaver;
    [SerializeField] private TextMeshProUGUI highestScore;
    [SerializeField] private TextMeshProUGUI lastScore;
    [SerializeField] private TextMeshProUGUI cherriesAmount;


    private void OnEnable()
    {
        if (gameSaver)
        {        
            if (highestScore)
            {
                highestScore.text = gameSaver.GameData.HighestScore.ToString();
            }
            if (lastScore)
            {
                lastScore.text = gameSaver.GameData.LastScore.ToString();
            }
            if (cherriesAmount)
            {
                cherriesAmount.text = gameSaver.GameData.CherriesAmount.ToString();
            }
        }
    }
}
