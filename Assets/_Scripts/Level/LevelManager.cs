using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int minRandomNumber;
    [SerializeField] private int maxRandomNumber;
    private void Start()
    {
        RandomNumberSystem.GenerateNewNumber(minRandomNumber, maxRandomNumber);
    }

    private void OnEnable()
    {
        RandomNumberSystem.OnGuessedCurrentNumber += CompleteGame;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnGuessedCurrentNumber -= CompleteGame;
    }

    private void CompleteGame()
    {
        Invoke(nameof(ReloadScene), 3f);
    }
    
    private void ReloadScene() => SceneManager.LoadScene(0);
}
