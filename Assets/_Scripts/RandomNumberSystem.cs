using System;
using Random = UnityEngine.Random;
public static class RandomNumberSystem
{
    public static int MinNumber { get; private set; }
    public static int MaxNumber { get; private set; }
    public static int CurrentNumber { get; private set; }
    public static Action<int> OnGenerateNumber;

    public static Action<ResultType, int> OnCheckCurrentNumber;
    public static Action OnGuessedCurrentNumber;
    
    public static bool IsPlayerTurn { get; private set; }

    public static void GenerateNewNumber(int min, int max)
    {
        IsPlayerTurn = true;
        MinNumber = min;
        MaxNumber = max;
        
        CurrentNumber = Random.Range(MinNumber, MaxNumber+1);
        OnGenerateNumber?.Invoke(CurrentNumber);
    }

    public static void CheckCurrentNumber(int number)
    {
        if(CurrentNumber == number)
        {
            OnGuessedCurrentNumber?.Invoke();
            return;
        }
        
        IsPlayerTurn = !IsPlayerTurn;
        if(CurrentNumber < number) OnCheckCurrentNumber?.Invoke(ResultType.Less, number);
        else if(CurrentNumber > number) OnCheckCurrentNumber?.Invoke(ResultType.More, number);
    }
}
