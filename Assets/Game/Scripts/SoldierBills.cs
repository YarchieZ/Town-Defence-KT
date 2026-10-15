using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoldierBills : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Slider soldierBillsSlider;
    [SerializeField] private TextMeshProUGUI soldierBillsText;
    [SerializeField] private float timeUntilPayment;
    private float _currentTime;
    private void Update()
    {
        int paymentAmount = (resourceManager.Soldier + resourceManager.Paladin) * 2;
        soldierBillsText.text = $"Расходы на армию (Сейчас: {paymentAmount})";
        if (_currentTime < timeUntilPayment)
        {
            _currentTime += Time.deltaTime;
            soldierBillsSlider.value = _currentTime / timeUntilPayment;
        }
        else
        {
            _currentTime = 0;
            resourceManager.AddCoins(paymentAmount * -1);
        }
    }
    
}
