using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HiringPeopleSystem : MonoBehaviour
{
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Transform root;
    [SerializeField] private GameObject progressBarPrefab;
    [SerializeField] private int maxUnitsHiring;
    [SerializeField] private UnitType hireUnitType;
    [SerializeField] private float spawnDuration;
    [SerializeField] private int unitPrice;
    private Button _buyButton;
    private void Awake()
    {
        _buyButton = GetComponent<Button>();
        _buyButton.onClick.AddListener(OnUnitHire);
    }
    private void OnUnitHire()
    {
        if (resourceManager.Coins >= unitPrice && root.childCount < maxUnitsHiring)
        {
            resourceManager.AddCoins(-unitPrice);
            GameObject unit = Instantiate(progressBarPrefab, root);
            HiringPanel script  = unit.GetComponent<HiringPanel>();
            script.OnPanelSpawn(spawnDuration, hireUnitType,  resourceManager);
        }
    }

    private void OnDestroy()
    {
        _buyButton.onClick.RemoveListener(OnUnitHire);
    }
}
