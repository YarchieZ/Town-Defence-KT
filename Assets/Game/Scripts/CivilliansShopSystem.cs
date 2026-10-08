using UnityEngine;
using UnityEngine.UI;

public class CivilliansShopSystem : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Button civilliansBuyButton;
    [SerializeField] private int civillianPrice;

    private void Awake()
    {
        civilliansBuyButton.onClick.AddListener(OnSoldierBuy);
    }
    private void OnSoldierBuy()
    {
        if (resourceManager.Coins >= civillianPrice)
        {
            resourceManager.AddCoins(-civillianPrice);
            resourceManager.AddCivillian(1);
        }
    }

    private void OnDestroy()
    {
        civilliansBuyButton.onClick.RemoveListener(OnSoldierBuy);
    }
}
