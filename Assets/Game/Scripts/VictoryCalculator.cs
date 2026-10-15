using TMPro;
using UnityEngine;

public class VictoryCalculator : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject losePanel;

    public void OnWinEvent()
    {
        mainPanel.SetActive(false);
        victoryPanel.SetActive(true);
    }

    public void ExitProgram()
    {
        Application.Quit();
    }

    public void OnLoseEvent(int value)
    {
        loseText.text = $"Финальный счёт (Сумма монет): {value}";
        mainPanel.SetActive(false);
        losePanel.SetActive(true);
    }
    
}
