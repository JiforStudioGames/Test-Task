using UnityEngine;

public class ButtonsSpawnSystem : MonoBehaviour
{
    [SerializeField] private Transform buttonParent;
    [SerializeField] private ButtonAnswer buttonPrefab;
    
    private void OnEnable()
    {
        RandomNumberSystem.OnGenerateNumber += SpawnButtons;
    }

    private void OnDisable()
    {
        RandomNumberSystem.OnGenerateNumber -= SpawnButtons;
    }

    private void SpawnButtons(int value)
    {
        for (int i = RandomNumberSystem.MinNumber; i <= RandomNumberSystem.MaxNumber; i++)
        {
            var buttonAnswer = Instantiate(buttonPrefab, buttonParent);

            var i1 = i;
            buttonAnswer.textValue.text = i.ToString();
            buttonAnswer.button.onClick.AddListener(() => RandomNumberSystem.CheckCurrentNumber(i1));
        }
    }
}
