using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatFarm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wheatCounterText;
    [SerializeField] private Image imageTimer;
    [SerializeField] private float incomeTimer;
    [SerializeField] private int IncomePerCivillian;
    private float _timer;
    public int wheat { get; private set; }

    private void Update()
    {
        WheatCounter();
    }
    private void WheatCounter()
    {
        if (_timer < incomeTimer)
        {
            _timer += Time.deltaTime;
            imageTimer.fillAmount = _timer / incomeTimer;
        }
        else
        {
            _timer = 0;
            wheat += IncomePerCivillian;
            wheatCounterText.text = $"Запас пшеницы: {wheat.ToString()}"; 
        }
    }

    
}
