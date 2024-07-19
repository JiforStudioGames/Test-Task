using TMPro;
using UnityEngine;

public class UpdateGameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textInfoGenerated;

    private void OnEnable()
    {
        RandomNumberSystem.OnGenerateNumber += UpdateInfoGame;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnGenerateNumber -= UpdateInfoGame;
    }

    private void UpdateInfoGame(int value)
    {
        textInfoGenerated.text =
            $"The system generated a number from {RandomNumberSystem.MinNumber} to {RandomNumberSystem.MaxNumber}. Try to guess this number...";
    }
}
