using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class EventTypes
{
    public string name;
    public string description;
    public int coinsAmount;
    public int soldiersAmount;
    public int villagersAmount;
}
public class RandomEvents : MonoBehaviour
{
    [SerializeField] private List<EventTypes> eventTypesList = new List<EventTypes>();
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Slider untilEventSlider;
    [SerializeField] private float timeUntilEvent;
    [SerializeField] private GameObject eventPanel;
    [SerializeField] private TextMeshProUGUI eventName;
    [SerializeField] private TextMeshProUGUI eventDescription;
    [SerializeField] private TextMeshProUGUI statisticsText;
    private float _currentTime;
    private int _previousEvent;

    private void Update()
    {
        if (_currentTime < timeUntilEvent)
        {
            _currentTime += Time.deltaTime;
            untilEventSlider.value = _currentTime / timeUntilEvent;
        }
        else
        {
            EventStartLogic();
        }
        
    }

    private void EventStartLogic()
    {
        
        eventName.text = "";
        _currentTime = 0;
        statisticsText.text = "";
        int randomEventNum = Random.Range(0, eventTypesList.Count);
        while (randomEventNum == _previousEvent)
        {
            randomEventNum = Random.Range(0, eventTypesList.Count);
        }
        int index = 0;
        foreach (EventTypes eventType in eventTypesList)
        {
            if (index == randomEventNum)
            {
                eventName.text = eventType.name;
                eventDescription.text = eventType.description;
                if (eventType.coinsAmount != 0)
                {
                    resourceManager.AddCoins(eventType.coinsAmount);
                    statisticsText.text += $"Монеты: {eventType.coinsAmount}\n";
                }
                if (eventType.soldiersAmount != 0)
                {
                    resourceManager.AddSoldier(eventType.soldiersAmount);
                    statisticsText.text += $"Воины: {eventType.soldiersAmount}\n";
                }
                if (eventType.villagersAmount != 0)
                {
                    resourceManager.AddCivillian(eventType.villagersAmount);
                    statisticsText.text += $"Крестьяне: {eventType.villagersAmount}\n";
                }
            }
            index++;
        }
        eventPanel.SetActive(true);
        _previousEvent = randomEventNum;
    }
}
