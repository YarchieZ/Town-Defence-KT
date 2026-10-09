using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiringPanel : MonoBehaviour
{
    
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private string soldierName;
    [SerializeField] private string villagerName;
    private UnitType _unitType;
    private ResourceManager _resourceManager;
    private float _currTime;
    private bool _isHiring;
    private float _duration;
    public void OnPanelSpawn(float dur, UnitType type, ResourceManager manager)
    {
        _duration = dur;
        _isHiring = true;
        _unitType = type;
        _resourceManager = manager;
        if (type == UnitType.Soldier)
        {
            nameText.text = soldierName;
        }
        else if (type == UnitType.Villager)
        {
            nameText.text = villagerName;
        }
    }
    private void Update()
    {
        HiringProcess();
    }
    private void HiringProcess()
    {
        if (_isHiring && _currTime < _duration)
        {
            _currTime += Time.deltaTime;
            progressBar.value = _currTime / _duration;
        }
        else if (_isHiring)
        {
            if (_unitType == UnitType.Soldier)
            {
                _resourceManager.AddSoldier(1);
            }
            else if (_unitType == UnitType.Villager)
            {
                _resourceManager.AddCivillian(1);
            }
            Destroy(gameObject);
        }
    }
}
