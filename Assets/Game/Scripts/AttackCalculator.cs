using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AttackCalculator : MonoBehaviour
{
    [SerializeField] private VictoryCalculator victoryCalculator;
    [SerializeField] private TextMeshProUGUI attackInfoText;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI victoryText;
    [SerializeField] private Slider attackSlider;
    [SerializeField] private int wavesCount;
    [SerializeField] private float startWaveDuration;
    [SerializeField] private int startEnemyPower;
    [SerializeField] private int minEnemyGrowCount;
    [SerializeField] private int maxEnemyGrowCount;
    private float _timer;
    private float _waveDuration;
    private int _currentWave;

    private void Awake()
    {
        _waveDuration = startWaveDuration;
        attackInfoText.text = $"Атака из: {startEnemyPower.ToString()} врагов, волна: {_currentWave + 1}";
    }
    private void Update()
    {
        if (_timer < _waveDuration && _currentWave < wavesCount)
        {
            _timer += Time.deltaTime;
            attackSlider.value = _timer / _waveDuration;
        }
        else if (_currentWave < wavesCount)
        {
            _timer = 0;
            _currentWave++;
            CalculateWaves();
        }
        else
        {
            victoryCalculator.OnWinEvent();
        }
    }

    private void CalculateWaves()
    {
        int currentPower = resourceManager.Soldier + (resourceManager.Paladin * 3);
        if (startEnemyPower > currentPower)
        {
            int calcLost = _currentWave * 3;
            int coinsLost = Random.Range(8, 20) + calcLost;
            int villagerLost = Random.Range(1, 7);
            int soldierLost = Random.Range(1, 6);
            resourceManager.AddCoins(-coinsLost);
            resourceManager.AddSoldier(-soldierLost);
            resourceManager.AddCivillian(-villagerLost);
            losePanel.SetActive(true);
            loseText.text = $"Потеря монет: {-coinsLost}\nПотеря воинов: {-soldierLost}\nПотеря жителей: {-villagerLost}";
        }
        else
        {
            int soldierLost = Random.Range(1, 4);

            int coinsFound = Random.Range(1, 4);
            resourceManager.AddSoldier(-soldierLost);
            resourceManager.AddCoins(coinsFound);
            victoryPanel.SetActive(true);
            victoryText.text =
                $"Потеря воинов: {-soldierLost}\nНайдено монет: {coinsFound}";
        }
        startEnemyPower += Random.Range(minEnemyGrowCount, maxEnemyGrowCount);
        startEnemyPower += _currentWave * 2;
        attackInfoText.text = $"Атака из: {startEnemyPower.ToString()} врагов, волна: {_currentWave}";
    }
}
