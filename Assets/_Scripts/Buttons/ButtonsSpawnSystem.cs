using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSpawnSystem : MonoBehaviour
{
    [SerializeField] private Transform buttonParent;
    [SerializeField] private ButtonAnswer[] buttonAnswers; // Предварительно созданные кнопки
    [SerializeField] private Button submitButton;
    [SerializeField] private Button backspaceButton;
    [SerializeField] private TextMeshProUGUI inputDisplay;

    private string _currentInput = "";

    private void OnEnable()
    {
        RandomNumberSystem.OnGenerateNumber += ResetButtons;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnGenerateNumber -= ResetButtons;
    }

    private void ResetButtons(int value)
    {
        _currentInput = "";
        inputDisplay.text = $"Your Answer: {_currentInput}";

        int[] digits = new int[10];
        for (int i = 0; i <= 9; i++)
        {
            digits[i] = i;
        }
        Shuffle(digits);

        for (int i = 0; i < buttonAnswers.Length; i++)
        {
            int digit = digits[i];
            buttonAnswers[i].textValue.text = digit.ToString();
            buttonAnswers[i].button.onClick.RemoveAllListeners();
            buttonAnswers[i].button.onClick.AddListener(() => AddDigit(digit));
        }
        
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(SubmitInput);

        backspaceButton.onClick.RemoveAllListeners();
        backspaceButton.onClick.AddListener(RemoveLastDigit);
    }

    private void AddDigit(int digit)
    {
        _currentInput += digit.ToString();
        inputDisplay.text = $"Your Answer: {_currentInput}";
    }

    private void RemoveLastDigit()
    {
        if (_currentInput.Length > 0)
        {
            _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
            inputDisplay.text = $"Your Answer: {_currentInput}";
        }
    }

    private void SubmitInput()
    {
        if (int.TryParse(_currentInput, out int result))
        {
            RandomNumberSystem.CheckCurrentNumber(result);
            _currentInput = "";
            inputDisplay.text = $"Your Answer: {_currentInput}";
            ResetButtons(0);
        }
    }

    private void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
        }
    }
}
