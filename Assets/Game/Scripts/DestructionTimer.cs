using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructionTimer : MonoBehaviour
{
    [SerializeField] List<Image> timers = new List<Image>();
    [SerializeField] GameObject destructionPanel;
    [SerializeField] private float timeUntilDestruction;
    [SerializeField] private bool startOnEnable;
    private bool _isDestruction;
    private float _currentTime;

    private void OnEnable()
    {
        if (startOnEnable)
        {
            _isDestruction = true;
        }
    }

    public void StartDestruction(float timer)
    {
        _isDestruction = true;
        timeUntilDestruction = timer;
    }
    private void Update()
    {
        if (_isDestruction && _currentTime < timeUntilDestruction)
        {
            _currentTime += Time.deltaTime;
            foreach (var timer in timers)
            {
                timer.fillAmount = 1f - (_currentTime / timeUntilDestruction);
            }
        }
        else if (_isDestruction && _currentTime >= timeUntilDestruction)
        {
            _currentTime = 0;
            destructionPanel.SetActive(false);
        }
    }
    
    

}
