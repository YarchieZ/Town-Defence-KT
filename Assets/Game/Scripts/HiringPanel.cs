using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiringPanel : MonoBehaviour
{
    
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private string soldierName;
    [SerializeField] private string villagerName;
    private ResourceManager resourceManager;
    private float _currTime;
    private bool _isHiring = false;
    private bool _type;
    private float _duration;


    public void OnPanelSpawn(float dur, bool type, ResourceManager manager)
    {
        _duration = dur;
        _isHiring = true;
        resourceManager = manager;
        if (type)
        {
            nameText.text = soldierName;
        }
        else
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
            if (_type)
            {
                resourceManager.AddSoldier(1);

            }
            else
            {
                resourceManager.AddCivillian(1);
            }
            Destroy(gameObject);
        }
    }
}
