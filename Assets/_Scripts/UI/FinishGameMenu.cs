using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject finishGameMenu;

    [SerializeField] private TextMeshProUGUI textFinishGame;
    private void OnEnable()
    {
        RandomNumberSystem.OnGuessedCurrentNumber += ActivateFinishGameMenu;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnGuessedCurrentNumber -= ActivateFinishGameMenu;
    }

    private void ActivateFinishGameMenu()
    {
        finishGameMenu.SetActive(true);
        if (!RandomNumberSystem.IsPlayerTurn)
        {
            textFinishGame.text = $"AI Win! Generated number is {RandomNumberSystem.CurrentNumber}";
            textFinishGame.color = Color.red;
        }
        else
        {
            textFinishGame.text = $"You Win! Generated number is {RandomNumberSystem.CurrentNumber}";
            textFinishGame.color = Color.green;
        }
    }
}
