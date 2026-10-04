using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatFarm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wheatCounterText;
    [SerializeField] private Image imageTimer;
    [SerializeField] private float incomeTimer;
    [SerializeField] private int incomePerCivillian;
    [SerializeField] ResourceManager resourceManager;
    private float _timer;

    private void Awake()
    {
        resourceManager.AddCivillian(1);
    }
    private void Update()
    {
        WheatCounter();
    }
    private void WheatCounter()
    {
        wheatCounterText.text = $"Запас пшеницы:\n{resourceManager.Wheat.ToString()}"; 
        if (_timer < incomeTimer)
        {
            _timer += Time.deltaTime;
            imageTimer.fillAmount = _timer / incomeTimer;
        }
        else
        {
            _timer = 0;
            resourceManager.AddWheat(resourceManager.Civillian * incomePerCivillian);
        }
    }

    
}
