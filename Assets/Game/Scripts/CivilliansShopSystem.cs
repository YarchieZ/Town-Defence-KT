using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CivilliansShopSystem : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private TextMeshProUGUI civillianCounterText;
    [SerializeField] private Button civilliansBuyButton;
    [SerializeField] private int civillianPrice;

    private void Awake()
    {
        civilliansBuyButton.onClick.AddListener(OnSoldierBuy);
    }
    private void OnSoldierBuy()
    {
        if (resourceManager.Wheat >= civillianPrice)
        {
            resourceManager.AddWheat(-civillianPrice);
            resourceManager.AddCivillian(1);
            civillianCounterText.text = resourceManager.Civillian.ToString();
        }
    }

    private void Update()
    {
        civillianCounterText.text = resourceManager.Civillian.ToString();
    }

    private void OnDestroy()
    {
        civilliansBuyButton.onClick.RemoveListener(OnSoldierBuy);
    }
}
