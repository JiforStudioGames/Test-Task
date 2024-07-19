using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSteps : MonoBehaviour
{
    [SerializeField] private Transform stepsParent;
    [SerializeField] private TextMeshProUGUI stepPrefab;
    
    private void OnEnable()
    {
        RandomNumberSystem.OnCheckCurrentNumber += UpdateStep;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnCheckCurrentNumber -= UpdateStep;
    }
    
    private void UpdateStep(ResultType type, int number)
    {
        var textStep = Instantiate(stepPrefab, stepsParent);
        if (!RandomNumberSystem.IsPlayerTurn)
        {
            textStep.text = $"You select {number}";
            textStep.color = Color.green;
        }
        else
        {
            textStep.text = $"AI select {number}";
            textStep.color = Color.red;
        }
    }
}
