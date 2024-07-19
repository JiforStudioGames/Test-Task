using System.Collections;
using UnityEngine;

public class AIGuesser : MonoBehaviour
{
    [SerializeField] private float aiDelayCheck;
    
    private int _aiMin;
    private int _aiMax;
    private int _aiGuess;

    private void OnEnable()
    {
        RandomNumberSystem.OnGenerateNumber += OnGenerateNumber;
        RandomNumberSystem.OnCheckCurrentNumber += AICheckCurrentNumber;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnGenerateNumber -= OnGenerateNumber;
        RandomNumberSystem.OnCheckCurrentNumber -= AICheckCurrentNumber;
    }
    
    private void OnGenerateNumber(int number)
    {
        _aiMin = RandomNumberSystem.MinNumber;
        _aiMax = RandomNumberSystem.MaxNumber;
    }

    private void AICheckCurrentNumber(ResultType resultType, int number)
    {
        if(RandomNumberSystem.IsPlayerTurn) return;
        
        if (resultType == ResultType.Less)
        {
            _aiMax = number - 1;
        }
        else if (resultType == ResultType.More)
        {
            _aiMin = number + 1;
        }

        StartCoroutine(AICheckNumber());
    }

    private IEnumerator AICheckNumber()
    {
        yield return new WaitForSeconds(aiDelayCheck);
        
        if (_aiMin <= _aiMax)
        {
            _aiGuess = (_aiMin + _aiMax) / 2;
            RandomNumberSystem.CheckCurrentNumber(_aiGuess);
        }
    }
}
