using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AttackCalculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackInfoText;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI victoryText;
    [SerializeField] private Slider attackSlider;
    [SerializeField] private int wavesCount;
    [SerializeField] private float difficultyMultiplier;
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
        attackInfoText.text = $"Атака из: {startEnemyPower.ToString()} врагов";
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
            _waveDuration *= difficultyMultiplier;
            startEnemyPower += Random.Range(minEnemyGrowCount, maxEnemyGrowCount);
            attackInfoText.text = $"Атака из: {startEnemyPower.ToString()} врагов";
            _currentWave++;
            CalculateWaves();
        }
        else
        {
            
        }
    }

    private void CalculateWaves()
    {
        int currentPower = resourceManager.Soldier + (resourceManager.Paladin * 3);
        if (startEnemyPower > currentPower)
        {
            currentPower -= startEnemyPower;
            int coinsLost = currentPower += Random.Range(1, 5);
            int soldierLost = Random.Range(1, 3);
            resourceManager.AddCoins(-coinsLost);
            resourceManager.AddSoldier(-soldierLost);
            losePanel.SetActive(true);
            loseText.text = $"Потеря монет: {coinsLost}\nПотеря воинов: {soldierLost}";
        }
        else
        {
            int soldierLost = Random.Range(1, 2);
            int villagersFound = 1;
            int coinsFound = Random.Range(1, 4);
            resourceManager.AddSoldier(-soldierLost);
            resourceManager.AddCivillian(villagersFound);
            resourceManager.AddCoins(coinsFound);
            victoryPanel.SetActive(true);
            victoryText.text =
                $"Потеря воинов: {soldierLost}\nНайдено крестьян: {villagersFound}\nНайдено монет: {coinsFound}";
        }
    }
}
