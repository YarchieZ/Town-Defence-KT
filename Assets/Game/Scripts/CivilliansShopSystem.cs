using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CivilliansShopSystem : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private TextMeshProUGUI civillianCounterText;
    [SerializeField] private TextMeshProUGUI soldierCounterText;
    [SerializeField] private Transform root;
    [SerializeField] private GameObject progresBarPrefab;
    [SerializeField] private Button civilliansBuyButton;
    [SerializeField] private int civillianPrice;
    [SerializeField] private Button soldierBuyButton;
    [SerializeField] private int soldierPrice;
    [SerializeField] float civilliansSpawnDuration;
    [SerializeField] float soldierSpawnDuration;


    private void Awake()
    {
        civilliansBuyButton.onClick.AddListener(OnVillagerBuy);
        soldierBuyButton.onClick.AddListener(OnSoldierBuy);
    }
    private void OnVillagerBuy()
    {
        if (resourceManager.Wheat >= civillianPrice)
        {
            var hiringBar = Instantiate(progresBarPrefab, root);
            hiringBar.TryGetComponent(out HiringPanel script);
            if (script != null)
            {
                script.OnPanelSpawn(civilliansSpawnDuration, false, resourceManager);
            }
        }
    }
    private void OnSoldierBuy()
    {
        if (resourceManager.Wheat >= soldierPrice)
        {
            var hiringBar = Instantiate(progresBarPrefab, root);
            hiringBar.TryGetComponent(out HiringPanel script);
            if (script != null)
            {
                script.OnPanelSpawn(soldierSpawnDuration, true, resourceManager);
            }
        }
    }

    private void Update()
    {
        civillianCounterText.text = resourceManager.Civillian.ToString();
    }

    private void OnDestroy()
    {
        civilliansBuyButton.onClick.RemoveListener(OnSoldierBuy);
        soldierBuyButton.onClick.RemoveListener(OnSoldierBuy);
    }
}
