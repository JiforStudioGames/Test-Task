using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnswer : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI textValue;

    private void OnEnable()
    {
        RandomNumberSystem.OnCheckCurrentNumber += SetButtonState;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnCheckCurrentNumber -= SetButtonState;
    }

    private void SetButtonState(ResultType result ,int value)
    {
        button.interactable = RandomNumberSystem.IsPlayerTurn;
    }
}
