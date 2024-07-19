using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateHints : MonoBehaviour
{
    [SerializeField] private Transform hitsParent;
    [SerializeField] private TextMeshProUGUI hintPrefab;
    
    private void OnEnable()
    {
        RandomNumberSystem.OnCheckCurrentNumber += UpdateHint;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnCheckCurrentNumber -= UpdateHint;
    }
    
    private void UpdateHint(ResultType type, int number)
    {
        var textHint = Instantiate(hintPrefab, hitsParent);
        textHint.text = $"{type.ToString()} then {number}";
    }
}
